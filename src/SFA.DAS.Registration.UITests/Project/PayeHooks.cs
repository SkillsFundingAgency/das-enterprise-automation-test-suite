using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project
{
    [Binding]
    public class PayeHooks
    {
        private enum FundType { NonLevyFund, LevyFund, TransferFund }
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TryCatchExceptionHelper _tryCatch;
        private LoginCredentialsHelper _loginCredentialsHelper;
        private bool _isAddPayeDetails;

        public PayeHooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchExceptionHelper>();
        }

        [BeforeScenario(Order = 23)]
        [Scope(Tag = "addnonlevyfunds")]
        public void AddNonLevyFunds() => AddPayeDetails(FundType.NonLevyFund);

        [BeforeScenario(Order = 24)]
        [Scope(Tag = "addtransferslevyfunds")]
        public void AddTransfersLevyFunds() => AddPayeDetails(FundType.TransferFund);

        [BeforeScenario(Order = 25)]
        [Scope(Tag = "addlevyfunds")]
        public void AddLevyFunds() => AddPayeDetails(FundType.LevyFund);

        [BeforeScenario(Order = 26)]
        [Scope(Tag = "addanothernonlevypayedetails")]
        public void SetUpAnotherNonLevyPayeDetails() => AddAnotherPayeDetails(FundType.NonLevyFund);

        [BeforeScenario(Order = 27)]
        [Scope(Tag = "addanotherlevyfunds")]
        public void SetUpAnotherLevyPayeDetails() => AddAnotherPayeDetails(FundType.LevyFund);

        private void AddPayeDetails(FundType fundType)
        {
            _isAddPayeDetails = true;

            var mongoDbDataGenerator = new MongoDbDataGenerator(_context);

            mongoDbDataGenerator.AddGatewayUsers(0);

            var registrationDatahelpers = _context.Get<RegistrationDataHelper>();

            _loginCredentialsHelper = _context.Get<LoginCredentialsHelper>();

            _loginCredentialsHelper.SetLoginCredentials(registrationDatahelpers.RandomEmail, registrationDatahelpers.Password);

            _objectContext.SetUserCreds(registrationDatahelpers.RandomEmail, registrationDatahelpers.Password, registrationDatahelpers.CompanyTypeOrg, 0);

            AddFunds(mongoDbDataGenerator, fundType);
        }

        private void AddAnotherPayeDetails(FundType fundType)
        {
            _objectContext.SetDataHelper(new DataHelper(_context.ScenarioInfo.Tags));

            var anotherMongoDbDataGenerator = new MongoDbDataGenerator(_context);

            anotherMongoDbDataGenerator.AddGatewayUsers(1);

            AddFunds(anotherMongoDbDataGenerator, fundType);
        }

        private void AddFunds(MongoDbDataGenerator mongoDbDataGenerator, FundType fundType)
        {
            if (fundType == FundType.NonLevyFund) { return; }

            var (fraction, calculatedAt, levyDeclarations) = fundType == FundType.TransferFund ? LevyDeclarationDataHelper.TransferslevyFunds() : LevyDeclarationDataHelper.LevyFunds();

            mongoDbDataGenerator.AddLevyDeclarations(fraction, calculatedAt, levyDeclarations);

            _loginCredentialsHelper.SetIsLevy();
        }

        [AfterScenario(Order = 21)]
        public void DeletePayeDetails()
        {
            if (!_isAddPayeDetails) { return; }

            _tryCatch.AfterScenarioException(() => 
            {
                var empRefs = _objectContext.GetMongoDbDataHelpers().Select(x => x.EmpRef).ToList();

                foreach (var empRef in empRefs)
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
            });
        }
    }
}
