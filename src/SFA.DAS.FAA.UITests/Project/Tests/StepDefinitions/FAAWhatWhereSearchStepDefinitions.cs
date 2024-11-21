using SFA.DAS.FAA.UITests.Project.Tests.Pages;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAAWhatWhereSearchStepDefinitions(ScenarioContext context)
    {
        private readonly ScenarioContext _context = context;

        [Given(@"the candidate can login in to faa")]
        public void GivenTheCandidateCanLoginInToFaa()
        {
            new FAAStepsHelper(_context).GoToFAAHomePage();
        }

        [When(@"the user does a what and where search '(.*)','(.*)'")]
        public void WhenTheUserDoesAWhatAndWhereSearch(string whatText, string whereText)
        {
            new FAASignedInLandingBasePage(_context).SearchByWhatWhere(whatText, whereText);
        }

        [Then(@"the user is presented with search results")]
        public void ThenTheUserIsPresentedWithSearchResults()
        {
            new FAASearchResultPage(_context).VerifySuccessfulResults();
        }
    }
}