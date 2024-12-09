using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ObjectContext _objectContext;
        private readonly DbConfig _dbConfig;
        private readonly ScenarioContext _scenarioContext;
        private readonly EarlyConnectSqlHelper _sqlHelper;

        public Hooks(ScenarioContext context)
        {
            _scenarioContext = context;
            _objectContext = context.Get<ObjectContext>();
            _dbConfig = context.Get<DbConfig>();
            _sqlHelper = new EarlyConnectSqlHelper(_objectContext, _dbConfig);
        }

        [BeforeScenario(Order = 21)]
        public void FirstBeforeScenario()
        {
            var name = _sqlHelper.GetAnEducationalOrganisation();

            var datahelper = new EarlyConnectDataHelper(_scenarioContext.Get<MailosaurUser>(), name);

            _scenarioContext.Set(datahelper);

            _objectContext.SetDebugInformation($"'{datahelper.Email}' is used");

            _scenarioContext.Get<TabHelper>().GoToUrl(UrlConfig.EarlyConnect_BaseUrl());
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var datahelper = _scenarioContext.Get<EarlyConnectDataHelper>();
            var email = datahelper.Email;

            _sqlHelper.DeleteStudentDataAndAnswersByEmail(email);
        }
    }
}