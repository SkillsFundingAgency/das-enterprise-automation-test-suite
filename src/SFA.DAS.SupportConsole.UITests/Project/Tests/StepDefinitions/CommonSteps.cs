using SFA.DAS.SupportConsole.UITests.Project.Helpers;
using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        private readonly ScenarioContext context;
        private readonly StepsHelper _stepsHelper;

        public CommonSteps(ScenarioContext context)
        {
            context = context;
            _stepsHelper = new StepsHelper(context);
        }

        [Given(@"the Tier 1 User is logged into Support Console")]
        public void GivenTheTierUserIsLoggedIntoSupportConsole() => _stepsHelper.Tier1LoginToSupportConsole();

        [Given(@"the User is logged into Support Console")]
        [Given(@"the Tier 2 User is logged into Support Console")]
        public void GivenTheUserIsLoggedIntoSupportConsole() => _stepsHelper.Tier2LoginToSupportConsole();

        [Given(@"the User is on the Account details page")]
        public void GivenTheUserIsOnTheAccountDetailsPage() => _stepsHelper.SearchAndViewAccount();
    }
}