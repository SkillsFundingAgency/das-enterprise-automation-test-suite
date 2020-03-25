using SFA.DAS.RAA_V2_QA.UITests.Project.Helpers;
using SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2_QA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ReviewerSteps
    {
        private readonly ReviewerStepsHelper _reviewerStepsHelper;
        private Reviewer_HomePage reviewer_HomePage;

        public ReviewerSteps(ScenarioContext context) => _reviewerStepsHelper = new ReviewerStepsHelper(context);

        [When(@"Reviewer is logged into QA Application")]
        public void WhenReviewerIsLoggedIntoQAApplication() => reviewer_HomePage = _reviewerStepsHelper.GoToReviewerHomePage(false);

        [Then(@"the Reviewer is able to approve the next available vacancy")]
        public void ThenTheReviewerIsAbleToApproveTheNextAvailableVacancy() => reviewer_HomePage.ReviewNextVacancy().Approve();

        [Given(@"the Reviewer Approves the vacancy")]
        [When(@"the Reviewer Approves the vacancy")]
        [Then(@"the Reviewer Approves the vacancy")]
        public void TheReviewerApprovesTheVacancy() => _reviewerStepsHelper.VerifyEmployerNameAndApprove(false);
       
        [Given(@"the Reviewer Refer the vacancy")]
        public void GivenTheReviewerReferTheVacancy() => _reviewerStepsHelper.Refer(false);


        [Then(@"the Reviewer verifies disability confident and approves the vacancy")]
        public void ThenTheReviewerVerifiesDisabilityConfidentAndApprovesTheVacancy() => _reviewerStepsHelper.VerifyDisabilityConfidenceAndApprove(false);
    }
}
