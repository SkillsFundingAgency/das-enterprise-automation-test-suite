using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    internal class RoatpApplyLoginHelpers
    {
        private readonly ScenarioContext _context;

        public RoatpApplyLoginHelpers(ScenarioContext context) => _context = context;

        internal SignInToRegisterPage SignInToRegisterPage() => ApplyNow().SelectOptionToSignInToASAccountAndContinue();

        internal CreateAnAccountPage CreateAnAccountPage() => ApplyNow().SelectNoCreateAccountAndContinue();

        private UsedThisServiceBeforePage ApplyNow() => new RoatpServiceStartPage(_context).ClickApplyNow();
    }
}
