using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSteps
    {
        private readonly ProviderStepsHelper _providerStepsHelper;

        public ProviderSteps(ScenarioContext context)
        {
            _providerStepsHelper = new ProviderStepsHelper(context);
        }

        [Then(@"the provider approves the cohorts")]
        public void ThenTheProviderApprovesTheCohorts()
        {
            _providerStepsHelper.CurrentCohortDetails()
                .SelectContinueToApproval()
                .SubmitApprove();
        }


        [When(@"the provider adds (.*) apprentices and sends to employer to review")]
        public void WhenTheProviderAddsApprenticesAndSendsToEmployerToReview(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = _providerStepsHelper.AddApprentice(numberOfApprentices);

            providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitSendToEmployerToReview()
                .SendInstructionsToEmployerForCohortToReview();
        }

        [When(@"the provider adds (.*) apprentices approves them and sends to employer to approve")]
        public void WhenTheProviderAddsApprenticesApprovesThemAndSendsToEmployerToApprove(int numberOfApprentices)
        {
            _providerStepsHelper.AddApprenticeAndSendToEmployerForApproval(numberOfApprentices);
        }


        [Then(@"the provider adds Ulns and approves the cohorts")]
        public void TheProviderAddsUlnsAndApprovesTheCohorts()
        {
            _providerStepsHelper.Approve();
        }

        [When(@"the provider adds Ulns and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsAndApprovesTheCohortsAndSendsToEmployer()
        {
            var providerReviewYourCohortPage = _providerStepsHelper.EditApprentice();

            providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }
    }
}
