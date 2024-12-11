using SFA.DAS.API.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EarlyConnect.APITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnect.APITests.Project.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ObjectContext _objectContext;
        private readonly DbConfig _dbConfig;
        private readonly ScenarioContext _context;
        private readonly EarlyConnectSqlHelper _sqlHelper;
        private readonly ApprenticePPIDataHelper _dataHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dbConfig = context.Get<DbConfig>();
            _sqlHelper = new EarlyConnectSqlHelper(_objectContext, _dbConfig);
            _dataHelper = _context.Get<ApprenticePPIDataHelper>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _context.Set(_dataHelper);
            _context.SetRestClient(new Outer_EarlyConnectAPIClient(_objectContext, _context.GetOuter_ApiAuthTokenConfig()));
        }

        [AfterScenario]
        public void CleanTestData()
        {
            _sqlHelper.DeleteStudentData(_dataHelper.ApprenticeEmail);
            _sqlHelper.DeleteMetricsData();
        }
    }
}
