using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ReviewerSteps
    {
        private readonly ReviewerStepsHelper _reviewerStepsHelper;

        public ReviewerSteps(ScenarioContext context) => _reviewerStepsHelper = new ReviewerStepsHelper(context);

        [Given(@"the Reviewer Approves the vacancy")]
        [When(@"the Reviewer Approves the vacancy")]
        public void TheReviewerApprovesTheVacancy() => _reviewerStepsHelper.VerifyEmployerNameAndApprove(false);

        [Then(@"the Reviewer verifies disability confident and approves the vacancy")]
        public void ThenTheReviewerVerifiesDisabilityConfidentAndApprovesTheVacancy() => _reviewerStepsHelper.VerifyDisabilityConfidenceAndApprove(false);
    }
}
