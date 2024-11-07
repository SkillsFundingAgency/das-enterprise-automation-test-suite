using SFA.DAS.FAA.UITests.Project.Tests.Pages;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAAWWSStepDefinitions(ScenarioContext context)
    {

        private readonly IWebDriver;
        private readonly ScenarioContext _context = context;
        private readonly FAASignedInLandingBasePage _signedInLandingPage;

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