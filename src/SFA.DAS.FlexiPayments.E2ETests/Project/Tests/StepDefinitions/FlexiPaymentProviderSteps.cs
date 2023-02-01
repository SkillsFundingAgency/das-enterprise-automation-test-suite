using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Transfers.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FlexiPaymentProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly TransfersProviderStepsHelper _providerStepsHelper;
        private ProviderApproveApprenticeDetailsPage _providerApproveApprenticeDetailsPage;

        public FlexiPaymentProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new TransfersProviderStepsHelper(context);
        }


        [Given(@"provider logs in to review the cohort")]
        public void GivenProviderLogsInToReviewTheCohort() => _providerApproveApprenticeDetailsPage = _providerStepsHelper.CurrentCohortDetails();

        [When(@"the Provider approves the cohort")]
        public void WhenProviderApprovesTheCohort() => _providerStepsHelper.Approve();

        [Given(@"the provider adds Ulns and opts the learners out of the pilot")]
        [When(@"the provider adds Ulns and opts the learners out of the pilot")]
        public void WhenTheProviderAddsUlnsAndOptsTheLearnersOutOfThePilot() => _providerApproveApprenticeDetailsPage = _providerStepsHelper.ApproveFlexiPilotCohort(false);

        [When(@"Provider successfully approves the cohort")]
        [Then(@"Provider successfully approves the cohort")]
        public void ThenProviderApprovesTheCohort() => _providerApproveApprenticeDetailsPage.SubmitApprove();

        [Given(@"the provider adds Ulns and Opt the learners into the pilot")]
        [When(@"the provider adds Ulns and Opt the learners into the pilot")]
        public void ThenTheProviderAddsUlnsAndOptTheLearnersIntoThePilot() => _providerApproveApprenticeDetailsPage = _providerStepsHelper.ApproveFlexiPilotCohort(true);

        [Given(@"the provider adds Uln and Opt learner (.*) into the pilot")]
        public void GivenTheProviderAddsUlnAndOptLearnerIntoThePilot(int learnerNumber) => _providerStepsHelper.EditSpecificFlexiPaymentsPilotApprentice(_providerApproveApprenticeDetailsPage, learnerNumber, true);

        [Given(@"the provider adds Uln and Opt learner (.*) out of the pilot")]
        public void GivenTheProviderAddsUlnAndOptLearnerOutOfThePilot(int learnerNumber) => _providerStepsHelper.EditSpecificFlexiPaymentsPilotApprentice(_providerApproveApprenticeDetailsPage, learnerNumber, false);

        [When(@"pilot provider approves the cohort")]
        public void WhenPilotProviderApprovesCohort() => new ProviderApproveApprenticeDetailsPage(_context).SubmitApprove();
    }
}
