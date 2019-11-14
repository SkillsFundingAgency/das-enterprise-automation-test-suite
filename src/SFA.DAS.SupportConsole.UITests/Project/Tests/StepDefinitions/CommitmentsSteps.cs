using SFA.DAS.SupportConsole.UITests.Project.Helpers;
using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class CommitmentsSteps
    {
        private readonly ScenarioContext _context;
        private readonly StepsHelper _stepsHelper;

        public CommitmentsSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new StepsHelper(_context);
        }

        [When(@"the User searches for an ULN")]
        public void WhenTheUserSearchesForAnULN()
        {
            _stepsHelper.SearchForUln();
        }

        [Then(@"the ULN details are displayed")]
        public void ThenTheULNDetailsAreDisplayed()
        {
            var ulnSearchResultsPage = new UlnSearchResultsPage(_context);

            ulnSearchResultsPage.SelectULN()
                .VerifyUlnDetailsPageHeaders();
        }
    }
}