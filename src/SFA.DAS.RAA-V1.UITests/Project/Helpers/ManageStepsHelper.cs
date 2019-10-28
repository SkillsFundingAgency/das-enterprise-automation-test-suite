using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class ManageStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RAAV1Config _config;
        private readonly RestartWebDriverHelper _helper;
        private const string _applicationName = "Manage";

        public ManageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _helper = new RestartWebDriverHelper(context);
            _config = context.GetRAAV1Config<RAAV1Config>();
        }

        public Manage_HomePage GoToManageHomePage()
        {
            _helper.RestartWebDriver(_config.ManageBaseUrl, _applicationName);

            return new Manage_IndexPage(_context)
                .ClickAgencyButton()
                .ManageStaffIdams()
                .SubmitManageLoginDetails();
        }
    }
}
