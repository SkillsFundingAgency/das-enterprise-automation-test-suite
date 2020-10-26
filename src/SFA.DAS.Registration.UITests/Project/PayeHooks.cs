using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project
{
    [Binding]
    public class PayeHooks
    {
        private enum FundType { LevyFund, TransferFund }
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private LoginCredentialsHelper _loginCredentialsHelper;
        private MongoDbDataGenerator _mongoDbDataGenerator;
        private MongoDbDataGenerator _anotherMongoDbDataGenerator;
        private List<string> _empRefs;

        public PayeHooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 23)]
        [Scope(Tag = "addpayedetails"), Scope(Tag = "levypaye"), Scope(Tag = "nonlevypaye")]
        public void SetUpMongoDbHelpers()
        {
            _mongoDbDataGenerator = new MongoDbDataGenerator(_context);

            _mongoDbDataGenerator.AddGatewayUsers(0);

            var registrationDatahelpers = _context.Get<RegistrationDataHelper>();

            _loginCredentialsHelper = _context.Get<LoginCredentialsHelper>();

            _loginCredentialsHelper.SetLoginCredentials(registrationDatahelpers.RandomEmail, registrationDatahelpers.Password);

            _objectContext.SetUserCreds(registrationDatahelpers.RandomEmail, registrationDatahelpers.Password, registrationDatahelpers.CompanyTypeOrg, 0);
        }

        [BeforeScenario(Order = 24)]
        [Scope(Tag = "addtransferslevyfunds")]
        public void AddTransfersLevyFunds() => AddFunds(_mongoDbDataGenerator, FundType.TransferFund);

        [BeforeScenario(Order = 25)]
        [Scope(Tag = "addlevyfunds")]
        public void AddLevyFunds() => AddFunds(_mongoDbDataGenerator, FundType.LevyFund);

        [BeforeScenario(Order = 26)]
        [Scope(Tag = "addanothernonlevypayedetails")]
        public void SetUpAnotherNonLevyPayeDetails() => AddAnotherPayeDetails();

        [BeforeScenario(Order = 27)]
        [Scope(Tag = "addanotherlevypayedetails")]
        public void SetUpAnotherLevyPayeDetails()
        {
            AddAnotherPayeDetails();

            AddFunds(_anotherMongoDbDataGenerator, FundType.LevyFund);
        }

        private void AddAnotherPayeDetails()
        {
            _objectContext.SetDataHelper(new DataHelper(_context.ScenarioInfo.Tags));

            _anotherMongoDbDataGenerator = new MongoDbDataGenerator(_context);

            _anotherMongoDbDataGenerator.AddGatewayUsers(1);
        }

        private void AddFunds(MongoDbDataGenerator mongoDbDataGenerator, FundType fundType)
        {
            var (fraction, calculatedAt, levyDeclarations) = fundType == FundType.TransferFund ? LevyDeclarationDataHelper.TransferslevyFunds() : LevyDeclarationDataHelper.LevyFunds();

            mongoDbDataGenerator.AddLevyDeclarations(fraction, calculatedAt, levyDeclarations);

            _loginCredentialsHelper.SetIsLevy();
        }

        [AfterScenario(Order = 21)]
        [Scope(Tag = "addpayedetails"), Scope(Tag = "levypaye"), Scope(Tag = "nonlevypaye")]
        public void DeletePayeDetails()
        {
            _empRefs = _objectContext.GetMongoDbDataHelpers().Select(x => x.EmpRef).ToList();

            foreach (var empRef in _empRefs)
            {
                if (_context.TryGetValue($"{typeof(DeclarationsDataGenerator).FullName}_{empRef}", out MongoDbHelper levyDecMongoDbHelper))
                {
                    levyDecMongoDbHelper.AsyncDeleteData().Wait();
                    TestContext.Progress.WriteLine($"Declarations Deleted for, EmpRef: {empRef}");

                    if (_context.TryGetValue($"{typeof(EnglishFractionDataGenerator).FullName}_{empRef}", out MongoDbHelper englishFractionMongoDbHelper))
                    {
                        englishFractionMongoDbHelper.AsyncDeleteData().Wait();
                        TestContext.Progress.WriteLine($"English Fraction Deleted for, EmpRef: {empRef}");
                    }
                }

                if (_context.TryGetValue($"{typeof(EmpRefLinksDataGenerator).FullName}_{empRef}", out MongoDbHelper emprefMongoDbHelper))
                {
                    emprefMongoDbHelper.AsyncDeleteData().Wait();
                    TestContext.Progress.WriteLine($"EmpRef Links Deleted, EmpRef: {empRef}");
                }

                if (_context.TryGetValue($"{typeof(GatewayUserDataGenerator).FullName}_{empRef}", out MongoDbHelper gatewayusermongoDbHelper))
                {
                    gatewayusermongoDbHelper.AsyncDeleteData().Wait();
                    TestContext.Progress.WriteLine($"Gateway User Deleted, EmpRef: {empRef}");
                }
            }
        }
    }
}
