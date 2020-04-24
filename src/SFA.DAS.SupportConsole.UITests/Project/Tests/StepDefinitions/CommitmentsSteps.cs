using NUnit.Framework;
using SFA.DAS.SupportConsole.UITests.Project.Helpers;
using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CommitmentsSteps
    {
        private readonly ScenarioContext _context;
        private readonly StepsHelper _stepsHelper;
        private readonly SupportConsoleConfig _config;

        public CommitmentsSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new StepsHelper(_context);
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
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
            var commitmentsSearchPage = new CommitmentsSearchPage(_context);
            Assert.AreEqual(commitmentsSearchPage.GetCommitmentsSearchPageErrorText(), commitmentsSearchPage.UlnSearchErrorMessage, "Uln search Error message mismatch in CommitmentsSearchPage");
        }

        [When(@"the User searches for a Cohort")]
        public void WhenTheUserSearchesForACohort()
        {
            _stepsHelper.SearchForCohort();
        }

        [When(@"the User clicks on 'View this cohort' button")]
        public void WhenTheUserClicksOnButton()
        {
            var cohortSummaryPage = new CohortSummaryPage(_context);
            Assert.AreEqual(cohortSummaryPage.GetCohortRefNumber(), _config.CohortRef, "Cohort reference mismatch in CohortSummaryPage");
            cohortSummaryPage.ClickViewThisCohortButton();
        }

        [When(@"the user chooses to view Uln of the Cohort")]
        public void WhenTheUserChoosesToViewUlnOfTheCohort()
        {
            var cohortDetailsPage = new CohortDetailsPage(_context);
            Assert.AreEqual(cohortDetailsPage.GetCohortRefNumber(), _config.CohortRef, "Cohort reference mismatch in CohortDetailsPage");
            cohortDetailsPage.ClickViewUlnLink();
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
            var commitmentsSearchPage = new CommitmentsSearchPage(_context);
            Assert.AreEqual(commitmentsSearchPage.GetCommitmentsSearchPageErrorText(), commitmentsSearchPage.CohortSearchErrorMessage, "Cohort search Error message mismatch in CommitmentsSearchPage");
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
            var commitmentsSearchPage = new CommitmentsSearchPage(_context);
            Assert.AreEqual(commitmentsSearchPage.GetCommitmentsSearchPageErrorText(), commitmentsSearchPage.UnauthorisedCohortSearchErrorMessage, "Cohort search Error message mismatch in CommitmentsSearchPage");
        }
    }
}