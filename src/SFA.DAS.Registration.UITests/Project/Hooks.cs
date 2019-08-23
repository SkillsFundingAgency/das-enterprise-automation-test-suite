using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers.MongoDb;
using SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project
{
    [Binding]
    public class Hooks          
    {
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly IWebDriver _webDriver;
        private readonly ObjectContext _objectContext;
        private DataHelper _dataHelper;
        private string _empRef;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetProjectConfig<ProjectConfig>();
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 21)]
        public void Navigate()
        {
            var url = _config.RE_BaseUrl;
            _webDriver.Navigate().GoToUrl(url);
        }

        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers()
        {
            var domainName = _context.ScenarioInfo.Tags.Contains("eoiaccount") ? "eoi.com" : "gmail.com";

            _dataHelper = new DataHelper(_config.TwoDigitProjectCode, domainName);

            _context.Set(_dataHelper);

            TestContext.Progress.WriteLine($"Email : {_dataHelper.RandomEmail}");
        }

        [BeforeScenario(Order = 23)]
        [Scope(Tag = "addpayedetails")]
        public void SetUpMongoDbHelpers()
        {
            var datagenerator = new MongoDbDataGenerator(_context);

            datagenerator.AddGatewayUsers();

            _empRef = _objectContext.GetGatewayPaye();
        }

        [AfterScenario(Order = 21)]
        [Scope(Tag = "addpayedetails")]
        public void DeletePayeDetails()
        {
            if (_context.TryGetValue(typeof(DeclarationsDataGenerator).FullName, out MongoDbHelper levyDecMongoDbHelper))
            {
                levyDecMongoDbHelper.AsyncDeleteData().Wait();
                TestContext.Progress.WriteLine($"Declarations Deleted for, EmpRef: {_empRef}");

                if (_context.TryGetValue(typeof(EnglishFractionDataGenerator).FullName, out MongoDbHelper englishFractionMongoDbHelper))
                {
                    englishFractionMongoDbHelper.AsyncDeleteData().Wait();
                    TestContext.Progress.WriteLine($"English Fraction Deleted for, EmpRef: {_empRef}");
                }                
            }

            if (_context.TryGetValue(typeof(EmpRefLinksDataGenerator).FullName, out MongoDbHelper emprefMongoDbHelper))
            {
                emprefMongoDbHelper.AsyncDeleteData().Wait();
                TestContext.Progress.WriteLine($"EmpRef Links Deleted, EmpRef: {_empRef}");
            }

            if (_context.TryGetValue(typeof(GatewayUserDataGenerator).FullName, out MongoDbHelper gatewayusermongoDbHelper))
            {
                gatewayusermongoDbHelper.AsyncDeleteData().Wait();
                TestContext.Progress.WriteLine($"Gateway User Deleted, EmpRef: {_empRef}");
            }
        }
    }
}
