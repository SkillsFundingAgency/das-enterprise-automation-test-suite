using SFA.DAS.SupportConsole.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        private readonly ScenarioContext _context;
        private readonly StepsHelper _stepsHelper;

        public CommonSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new StepsHelper(_context);
        }

        [Given(@"the User is logged into Support Console")]
        public void GivenTheUserIsLoggedIntoSupportConsole()
        {
            _stepsHelper.LoginToSupportConsole();
        }

        [Given(@"the User is on the Account details page")]
        public void GivenTheUserIsOnTheAccountDetailsPage()
        {
            _stepsHelper.SearchAndViewAccount();
        }
    }
}