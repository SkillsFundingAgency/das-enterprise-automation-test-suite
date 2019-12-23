using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Configuration;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project
{
    [Binding]
    public class Hooks          
    {
        private readonly ScenarioContext _context;
        private readonly RegistrationConfig _config;
        private readonly IWebDriver _webDriver;
        private readonly ObjectContext _objectContext;
        private List<string> _empRefs;
        private RegistrationDatahelpers _registrationDatahelpers;
        private LoginCredentialsHelper _loginCredentialsHelper;
        private MongoDbDataGenerator _mongoDbDataGenerator;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetRegistrationConfig<RegistrationConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 21)]
        public void Navigate()
        {
            var url = _config.EmployerApprenticeshipServiceBaseURL;
            _webDriver.Navigate().GoToUrl(url);
        }

        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers()
        {
            var domainName = _context.ScenarioInfo.Tags.Contains("eoiaccount") ? "eoi.com" : "gmail.com";

            var dataHelper = new DataHelper(_config.TwoDigitProjectCode);

            _objectContext.SetDataHelper(dataHelper);

            _registrationDatahelpers = new RegistrationDatahelpers(dataHelper.GatewayUsername, _config.RE_AccountPassword, domainName);

            _context.Set(_registrationDatahelpers);

            _loginCredentialsHelper = new LoginCredentialsHelper(_objectContext);

            _context.Set(_loginCredentialsHelper);

            _objectContext.SetOrganisationName(_config.RE_OrganisationName);
        }

        [BeforeScenario(Order = 23)]
        [Scope(Tag = "addpayedetails")]
        public void SetUpMongoDbHelpers()
        {
            _mongoDbDataGenerator = new MongoDbDataGenerator(_context);

            _mongoDbDataGenerator.AddGatewayUsers();

            _loginCredentialsHelper.SetLoginCredentials(_registrationDatahelpers.RandomEmail, _registrationDatahelpers.Password);
        }

        [BeforeScenario(Order = 24)]
        [Scope(Tag = "addtransferslevyfunds")]
        public void AddTransfersLevyFunds()
        {
            var (fraction, calculatedAt, levyDeclarations) = LevyDeclarationDataHelper.TransferslevyFunds();
            _mongoDbDataGenerator.AddLevyDeclarations(fraction, calculatedAt, levyDeclarations);
            _loginCredentialsHelper.SetIsLevy();
        }

        [BeforeScenario(Order = 25)]
        [Scope(Tag = "addlevyfunds")]
        public void AddLevyFunds()
        {
            var (fraction, calculatedAt, levyDeclarations) = LevyDeclarationDataHelper.LevyFunds();
            _mongoDbDataGenerator.AddLevyDeclarations(fraction, calculatedAt, levyDeclarations);
            _loginCredentialsHelper.SetIsLevy();
        }

        [AfterScenario(Order = 21)]
        [Scope(Tag = "addpayedetails")]
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
