using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages
{
   public class StaffDashboardPage : RoatpAdminBasePage
    {
        protected override string PageTitle => "Staff dashboard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly RoatpConfig _config;
        #endregion

        public StaffDashboardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetRoatpConfig<RoatpConfig>();
        }
    }
}
