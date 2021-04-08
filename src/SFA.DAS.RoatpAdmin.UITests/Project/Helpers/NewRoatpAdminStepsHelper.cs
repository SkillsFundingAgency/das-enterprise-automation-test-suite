using SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers
{
    public class NewRoatpAdminStepsHelper : RoatpAdminStepsHelper
    {
        private readonly ScenarioContext _context;

        public NewRoatpAdminStepsHelper(ScenarioContext context) : base(context) => _context = context;

        public override RoatpAdminHomePage GoToRoatpAdminHomePage() => new StaffDashboardPage(_context, true).SearchForATrainingProvider();
    }
}