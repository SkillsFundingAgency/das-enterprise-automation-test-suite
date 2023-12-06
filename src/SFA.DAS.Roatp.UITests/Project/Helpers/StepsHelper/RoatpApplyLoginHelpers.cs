using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.StubPages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    internal class RoatpApplyLoginHelpers
    {
        private readonly ScenarioContext _context;

        public RoatpApplyLoginHelpers(ScenarioContext context) => _context = context;

        internal void SubmitValidUserDetails() => ApplyNow().SubmitValidUserDetails().Continue();

        internal void CreateAnAccountPage()
        {
            ApplyNow().CreateAccount().Continue();

            new StubAddYourUserDetailsPage(_context).EnterNameAndContinue();
        }

        private StubSignInApplyPage ApplyNow() => new RoatpServiceStartPage(_context).ClickApplyNow();
    }
}
