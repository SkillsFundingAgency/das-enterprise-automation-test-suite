using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ObjectContext _objectContext;
        private readonly DbConfig _dbConfig;
        private readonly ScenarioContext _context;
        private readonly EarlyConnectSqlHelper _sqlHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dbConfig = context.Get<DbConfig>();
            _sqlHelper = new EarlyConnectSqlHelper(_objectContext, _dbConfig);
        }

        [BeforeScenario(Order = 31)]
        public void SetUpHelpers()
        {
            var name = new EarlyConnectSqlHelper(_objectContext, _dbConfig).GetAnEducationalOrganisation();

            var email = _context.Get<MailosaurUser>().GetEmailList().FirstOrDefault().Email;

            var datahelper = new EarlyConnectDataHelper(email, name);

            _context.Set(datahelper);

            _objectContext.SetDebugInformation($"'{datahelper.Email}' is used");

            _context.Get<TabHelper>().GoToUrl(UrlConfig.EarlyConnect_BaseUrl());
        }

        [AfterScenario(Order = 31)]
        public void DeleteStudentData()
        {
            _sqlHelper.DeleteStudentDataAndAnswersByEmail(_context.Get<EarlyConnectDataHelper>().Email);
        }
    }
}