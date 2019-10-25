using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class ManageStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;
        private readonly RAAV1Config _config;
        public ManageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tabHelper = context.Get<TabHelper>();
            _config = context.GetRAAV1Config<RAAV1Config>();
        }

        public Manage_HomePage GoToManageHomePage()
        {
            _tabHelper.CloseAndOpenInNewTab(_config.ManageBaseUrl);
            return new Manage_IndexPage(_context)
                .ClickAgencyButton()
                .ManageStaffIdams()
                .SubmitManageLoginDetails();
        }
    }
}
