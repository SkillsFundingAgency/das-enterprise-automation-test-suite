using SFA.DAS.SupportConsole.UITests.Project.Helpers;
using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MaSteps
    {
        private readonly ScenarioContext _context;
        private ChallengePage _challengePage;
        
        public MaSteps(ScenarioContext context) => _context = context;
        
        [When(@"the user navigates to finance page")]
        public void WhenTheUserNavigatesToFinancePage() => new AccountOverviewPage(_context).ClickFinanceMenuLink();

        [Then(@"the user is redirected to a challenge page")]
        public void ThenTheUserIsRedirectedToAChallengePage() => _challengePage = new ChallengePage(_context);

        [When(@"the user enters invalid payscheme")]
        public void WhenTheUserEntersInvalidPayscheme() => _challengePage.EnterIncorrectPaye();

        [When(@"enters correct levybalance")]
        public void WhenEntersCorrectLevybalance() => _challengePage.EnterCorrectLevybalance();

        [When(@"the user submits the challenge")]
        public void WhenTheUserSubmitsTheChallenge() => _challengePage.Submit();

        [Then(@"the user should see the error message (.*)")]
        public void ThenTheUserShouldSeeTheErrorMessage(string message) => _challengePage.VerifyChallengeResponseErrorMessage(message);

        [When(@"the user enters valid payscheme and levybalance")]
        public void WhenTheUserEntersValidPayschemeAndLevybalance()
        {
            _challengePage.EnterCorrectPaye();
            _challengePage.EnterCorrectLevybalance();
        }
        
        [Then(@"the user is redirected to finance page")]
        public void ThenTheUserIsRedirectedToFinancePage() => new FinancePage(_context);
    }
}
