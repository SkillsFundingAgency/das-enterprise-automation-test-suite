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
        private readonly StepsHelper _stepsHelper;
        private readonly SupportConsoleConfig _config;
        private ChallengePage _challengePage;
        
        public MaSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new StepsHelper(_context);
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
        }
        
        [When(@"the user navigates to finance page")]
        public void WhenTheUserNavigatesToFinancePage() => new AccountOverviewPage(_context).ClickFinanceMenuLink();

        [Then(@"the user is redirected to a challenge page")]
        public void ThenTheUserIsRedirectedToAChallengePage() => _challengePage = new ChallengePage(_context);

        [When(@"the user enters invalid payscheme")]
        public void WhenTheUserEntersInvalidPayscheme() => _challengePage.EnterChallenge("1", "1");

        [When(@"enters correct levybalance")]
        public void WhenEntersCorrectLevybalance() => _challengePage.EnterCurrentLevybalance(_config.CurrentLevyBalance);

        [Then(@"the user should see the error message (.*)")]
        public void ThenTheUserShouldSeeTheErrorMessage(string message)
        {
            throw new PendingStepException();
        }

    }
}
