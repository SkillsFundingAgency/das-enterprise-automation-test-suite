using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

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

        [Then(@"Provider is able to view the cohort with employer")]
        public void ThenProviderIsAbleToViewTheCohortWithEmployer()
        {
            var providerHomePage = _providerStepsHelper.GoToProviderHomePage();

            providerHomePage.GoToProviderYourCohortsPage()
                    .GoToCohortsWithEmployers()
                    .SelectViewCurrentCohortDetails();
        }

        [Then(@"Provider is able to view all apprentice details when the cohort with employer")]
        public void ThenProviderIsAbleToViewAllApprenticeDetailsWhenTheCohortWithEmployer()
        {
            _providerStepsHelper.ViewApprentices();
        }

        [When(@"Provider adds (.*) apprentices and saves without sending to the employer")]
        public void WhenProviderAddsApprenticesAndSavesWithoutSendingToTheEmployer(int numberOfApprentices)
        {
            _providerStepsHelper.AddApprenticeAndSavesWithoutSendingEmployerForApproval(numberOfApprentices);
        }

        [Then(@"Provider is able to edit all apprentices before approval")]
        public void ThenProviderIsAbleToEditAllApprenticesBeforeApproval()
        {
            _providerStepsHelper.EditAllDetailsOfApprentice();
        }

        [Then(@"Provider is able to delete all apprentices before approval")]
        public void ThenProviderIsAbleToDeleteAllApprenticesBeforeApproval()
        {
            _providerStepsHelper.DeleteApprentice();
        }

        [Then(@"Provider is able to delete the cohort before approval")]
        public void ThenProviderIsAbleToDeleteTheCohortBeforeApproval()
        {
            _providerStepsHelper.DeleteCohort();
        }

    }
}