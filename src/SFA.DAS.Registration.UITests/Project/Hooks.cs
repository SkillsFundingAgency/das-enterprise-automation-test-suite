using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project
{
    [Binding]
    public class Hooks          
    {
        private readonly ScenarioContext _context;
        private readonly ProjectConfig _config;
        private readonly MongoDbConfig _mongoDbConfig;
        private readonly IWebDriver _webDriver;
        private MongoDbHelper _addGatewayUserData;
        private MongoDbHelper _addempRefLinksData;
        private MongoDbConnectionHelper _mongodbConnectionHelper;
        private readonly ObjectContext _objectContext;
        private DataHelper _dataHelper;
        private string _empRef;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _config = context.GetProjectConfig<ProjectConfig>();
            _mongoDbConfig = _context.GetMongoDbConfig();
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
            var mongoDbDataHelper = new MongoDbDataHelper(_dataHelper);

            _context.Set(mongoDbDataHelper);

            _objectContext.SetGatewayCreds(mongoDbDataHelper.GatewayId, mongoDbDataHelper.GatewayPassword, mongoDbDataHelper.EmpRef);

            _empRef = _objectContext.GetGatewayPaye();

            _mongodbConnectionHelper = new MongoDbConnectionHelper(_mongoDbConfig);

            _context.Set(_mongodbConnectionHelper);

            _addGatewayUserData = new MongoDbHelper(_mongodbConnectionHelper, new GatewayUserDataGenerator(mongoDbDataHelper));

            _addempRefLinksData = new MongoDbHelper(_mongodbConnectionHelper, new EmpRefLinksDataGenerator(mongoDbDataHelper));

        }

        [BeforeScenario(Order = 24)]
        [Scope(Tag = "addpayedetails")]
        public void AddPayeDetails()
        {
            TestContext.Progress.WriteLine($"Connecting to MongoDb Database : {_mongoDbConfig.Database}");

            _addGatewayUserData.AsyncCreateData().Wait();
            TestContext.Progress.WriteLine($"Gateway Id Created : {_objectContext.GetGatewayId()}");
            TestContext.Progress.WriteLine($"Gateway User Created, EmpRef: {_empRef}");

            _addempRefLinksData.AsyncCreateData().Wait();
            TestContext.Progress.WriteLine($"EmpRef Links Created, EmpRef: {_empRef}");
        }

        //[AfterScenario(Order = 21)]
        //[Scope(Tag = "addpayedetails")]
        public void DeletePayeDetails()
        {
            if (_context.TryGetValue(typeof(DeclarationsDataGenerator).FullName, out MongoDbHelper mongoDbHelper))
            {
                var deleteDeclarationsResults = mongoDbHelper.AsyncDeleteData();
                deleteDeclarationsResults.Wait();
                TestContext.Progress.WriteLine($"Declarations Deleted for, EmpRef: {_empRef}");

                if (_context.TryGetValue(typeof(EnglishFractionDataGenerator).FullName, out MongoDbHelper englishFractionMongoDbHelper))
                {
                    var englishFranctionResults = englishFractionMongoDbHelper.AsyncDeleteData();
                    englishFranctionResults.Wait();
                    TestContext.Progress.WriteLine($"English Fraction Deleted for, EmpRef: {_empRef}");
                }                
            }

            var deleteemprefLinksrResults = _addempRefLinksData.AsyncDeleteData();
            deleteemprefLinksrResults.Wait();
            TestContext.Progress.WriteLine($"EmpRef Links Deleted, EmpRef: {_empRef}");

            var deletegatewayUserResults = _addGatewayUserData.AsyncDeleteData();
            deletegatewayUserResults.Wait();
            TestContext.Progress.WriteLine($"Gateway User Deleted, EmpRef: {_empRef}");
        }
    }
}
