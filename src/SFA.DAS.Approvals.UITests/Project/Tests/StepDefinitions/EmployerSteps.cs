using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        private readonly EmployerStepsHelper _employerStepsHelper;
        
        public EmployerSteps(ScenarioContext context)
        {
            _employerStepsHelper = new EmployerStepsHelper(context);
        }

        [When(@"the Employer approves (\d) cohort and sends to provider")]
        public void TheEmployerApprovesCohortAndSendsToProvider(int numberOfApprentices)
        {
            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(numberOfApprentices);

            _employerStepsHelper.SetCohortReference(cohortReference);
        }

        [When(@"the Employer approves the cohort and sends to provider")]
        public void WhenTheEmployerApprovesTheCohortAndSendsToProvider()
        {
            var employerReviewYourCohortPage = _employerStepsHelper.EmployerReviewCohort();

            employerReviewYourCohortPage
                .SaveAndContinue()
                .SubmitApproveAndSendToTrainingProvider()
                .SendInstructionsToProviderForAnApprovedCohort();
        }


        [When(@"the Employer create a cohort and send to provider to add apprentices")]
        public void WhenTheEmployerCreateACohortAndSendToProviderToAddApprentices()
        {
            _employerStepsHelper.EmployerCreateCohortAndSendsToProvider(false);
        }

        [When(@"the Employer adds (.*) cohort and sends to provider")]
        public void WhenTheEmployerAddsCohortAndSendsToProvider(int numberOfApprentices)
        {
            var employerReviewYourCohortPage = _employerStepsHelper.EmployerAddApprentice(numberOfApprentices, false);

            var cohortReference = employerReviewYourCohortPage.SaveAndContinue()
                .SubmitSendToTrainingProviderForReview()
                .SendInstructionsToProviderForCohortToBeReviewed()
                .CohortReference();

            _employerStepsHelper.SetCohortReference(cohortReference);
        }

        [Then(@"the Employer approves the cohorts")]
        public void ThenTheEmployerApprovesTheCohorts()
        {
            _employerStepsHelper.Approve();
        }
    }
}
