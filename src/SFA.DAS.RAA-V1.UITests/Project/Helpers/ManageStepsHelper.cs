using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class ManageStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        private readonly RestartWebDriverHelper _helper;
        private readonly TabHelper _tabHelper;
        private const string _applicationName = "Manage";

        public ManageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _helper = new RestartWebDriverHelper(context);
            _tabHelper = context.Get<TabHelper>();
            _config = context.GetRAAV1Config<RAAV1Config>();
        }

        public Manage_HomePage GoToManageHomePage()
        {
            _helper.RestartWebDriver(_config.ManageBaseUrl, _applicationName);

            return LoginToManageApplication();
        }

        public Manage_AdminFunctionsPage GoToManageAdminFunctionsPage()
        {
            _tabHelper.GoToUrl(_config.ManageBaseUrl);

            var manage_AdminFunctionsPage = LoginToManageApplication();
            return manage_AdminFunctionsPage.ClickAdminLink();
        }

        private Manage_HomePage LoginToManageApplication()
        {
            return new Manage_IndexPage(_context)
                .ClickAgencyButton()
                .ManageStaffIdams()
                .SubmitManageLoginDetails();
        }
    }
}