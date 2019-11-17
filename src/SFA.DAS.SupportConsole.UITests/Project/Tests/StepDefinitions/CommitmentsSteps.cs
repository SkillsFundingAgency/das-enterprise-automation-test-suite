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

        [When(@"the User searches with a invalid ULN")]
        public void WhenTheUserSearchesWithAInvalidULN()
        {
            _stepsHelper.SearchWithInvalidUln(false);
        }

        [When(@"the User searches with a invalid ULN having special characters")]
        public void WhenTheUserSearchesWithAInvalidULNHavingSpecialCharacters()
        {
            _stepsHelper.SearchWithInvalidUln(true);
        }

        [Then(@"appropriate ULN error message is shown to the user")]
        public void ThenAppropriateUlnErrorMessageIsShownToTheUser()
        {
            new CommitmentsSearchPage(_context).VerifyUlnErrorMessage();
        }

        [When(@"the User searches for a Cohort")]
        public void WhenTheUserSearchesForACohort()
        {
            _stepsHelper.SearchForCohort();
        }

        [Then(@"the Cohort Summary page is displayed")]
        public void ThenTheCohortSummaryPageIsDisplayed()
        {
            new CohortSummaryPage(_context).IsPageDisplayed();
        }

        [When(@"the User clicks on 'View this cohort' button")]
        public void WhenTheUserClicksOnButton()
        {
            new CohortSummaryPage(_context).ClickViewThisCohortButton();
        }

        [Then(@"the Cohort Details page is displayed")]
        public void ThenTheCohortDetailsPageIsDisplayed()
        {
            new CohortDetailsPage(_context).IsPageDisplayed();
        }

        [When(@"the user chooses to view Uln of the Cohort")]
        public void WhenTheUserChoosesToViewUlnOfTheCohort()
        {
            new CohortDetailsPage(_context).ClickViewUlnLink();
        }

        [Then(@"the ULN details page is displayed")]
        public void ThenTheULNDetailsPageIsDisplayed()
        {
            new UlnDetailsPage(_context).VerifyUlnDetailsPageHeaders();
        }

        [When(@"the User searches with a invalid Cohort Ref")]
        public void WhenTheUserSearchesWithAInvalidCohortRef()
        {
            _stepsHelper.SearchWithInvalidCohort(false);
        }

        [Then(@"appropriate Cohort error message is shown to the user")]
        public void ThenAppropriateCohortErrorMessageIsShownToTheUser()
        {
            new CommitmentsSearchPage(_context).VerifyCohortErrorMessage();
        }

        [When(@"the User searches with a invalid Cohort Ref having special characters")]
        public void WhenTheUserSearchesWithAInvalidCohortRefHavingSpecialCharacters()
        {
            _stepsHelper.SearchWithInvalidCohort(true);
        }

        [When(@"the user tries to view another Employer's Cohort Ref")]
        public void WhenTheUserTriesToViewAnotherEmployerSCohortRef()
        {
            _stepsHelper.SearchWithUnauthorisedCohortAccess();
        }

        [Then(@"unauthorised Cohort access error message is shown to the user")]
        public void ThenUnauthorisedCohortAccessErrorMessageIsShownToTheUser()
        {
            new CommitmentsSearchPage(_context).VerifyUnauthorisedCohortAccessErrorMessage();
        }
    }
}