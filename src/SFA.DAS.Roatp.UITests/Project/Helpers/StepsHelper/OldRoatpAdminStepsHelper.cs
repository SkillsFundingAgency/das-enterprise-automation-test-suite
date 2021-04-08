using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    public class OldRoatpAdminStepsHelper : RoatpAdminStepsHelper
    {
        private readonly ScenarioContext _context;

        public OldRoatpAdminStepsHelper(ScenarioContext context) : base(context) => _context = context;

        public override RoatpAdminHomePage GoToRoatpAdminHomePage() => new RoatpAdminHomePage(_context);
    }
}
