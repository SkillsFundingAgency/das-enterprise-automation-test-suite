using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class ManageStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RAAV1Config _config;
        private readonly RestartWebDriverHelper _helper;
        private readonly TabHelper _tabHelper;
        private const string _applicationName = "Manage";

        public ManageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _helper = new RestartWebDriverHelper(context);
            _tabHelper = context.Get<TabHelper>();
            _config = context.GetRAAV1Config<RAAV1Config>();
        }

        public void ApproveAVacancy(bool restart)
        {
            GoToManageHomePage(restart)
            .ReviewAVacancy()
            .ApproveAVacancy();
        }
       
        public Manage_HomePage GoToManageHomePage(bool restart)
        {
            if (restart)
            {
                _helper.RestartWebDriver(_config.ManageBaseUrl, _applicationName);
            }
            else
            {
                GoToManageHomePage();
            }

            return new Manage_IndexPage(_context)
               .ClickAgencyButton()
               .ManageStaffIdams()
               .SubmitManageLoginDetails();
        }

        private void GoToManageHomePage()
        {
            _objectContext.SetCurrentApplicationName(_applicationName);
            _tabHelper.GoToUrl(_config.ManageBaseUrl);
        }
    }
}
