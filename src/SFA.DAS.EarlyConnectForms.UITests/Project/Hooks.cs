using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        private readonly DbConfig _dbConfig = context.Get<DbConfig>();

        [BeforeScenario(Order = 21)]
        public void FirstBeforeScenario()
        {
            var name = new EarlyConnectSqlHelper(_objectContext, _dbConfig).GetAnEducationalOrganisation();

            var datahelper = new EarlyConnectDataHelper(context.Get<MailosaurUser>(), name);

            context.Set(datahelper);

            _objectContext.SetDebugInformation($"'{datahelper.Email}' is used");

            context.Get<TabHelper>().GoToUrl(UrlConfig.EarlyConnect_BaseUrl());
        }
    }
}