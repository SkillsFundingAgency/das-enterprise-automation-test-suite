using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private ProviderApproveApprenticeDetailsPage _providerApproveApprenticeDetailsPage;

        public ProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);
        }

        [Given(@"the provider update the email address")]
        public void GivenTheProviderUpdateTheEmailAddress() => _providerStepsHelper.AddEmailAndSentToEmployerForApproval();

        [Then(@"the provider approves the cohorts")]
        public void ThenTheProviderApprovesTheCohorts() => _providerStepsHelper.CurrentCohortDetails().SubmitApprove();

        [When(@"the provider adds (.*) apprentices and sends to employer to review")]
        public void WhenTheProviderAddsApprenticesAndSendsToEmployerToReview(int numberOfApprentices)
        {
            _providerStepsHelper
                .AddApprentice(numberOfApprentices)
                .SubmitSendToEmployerToReview();
        }

        [When(@"the provider adds (.*) apprentices approves them and sends to employer to approve")]
        public void WhenTheProviderAddsApprenticesApprovesThemAndSendsToEmployerToApprove(int numberOfApprentices)
        {
            _providerStepsHelper.AddApprenticeAndSendToEmployerForApproval(numberOfApprentices);
        }

        [Then(@"the provider adds Ulns and approves the cohorts")]
        public void TheProviderAddsUlnsAndApprovesTheCohorts() => _providerStepsHelper.Approve();

        [When(@"the provider adds Ulns and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsAndApprovesTheCohortsAndSendsToEmployer() => _providerStepsHelper.EditApprentice().SubmitApprove();

        [When(@"the provider adds Ulns confirms courses are standards and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsConfirmsCoursesAreStandardsAndApprovesTheCohortsAndSendsToEmployer() => _providerStepsHelper.EditApprentice(true).SubmitApprove();


        [Then(@"Provider is able to view the cohort with employer")]
        public void ThenProviderIsAbleToViewTheCohortWithEmployer()
        {
            _providerStepsHelper.GoToProviderHomePage();

            new ProviderApprenticeRequestsPage(_context, true)
                    .GoToCohortsWithEmployers()
                    .SelectViewCurrentCohortDetails();
        }

        [Then(@"Provider is able to view all apprentice details when the cohort with employer")]
        public void ThenProviderIsAbleToViewAllApprenticeDetailsWhenTheCohortWithEmployer() => _providerStepsHelper.ViewApprentices();

        [When(@"Provider adds (.*) apprentices and saves without sending to the employer")]
        public void WhenProviderAddsApprenticesAndSavesWithoutSendingToTheEmployer(int numberOfApprentices)
        {
            _providerStepsHelper.AddApprenticeAndSavesWithoutSendingEmployerForApproval(numberOfApprentices);
            _providerApproveApprenticeDetailsPage = _providerStepsHelper.EditApprentice();
        }

        [Then(@"Provider is able to edit all apprentices before approval")]
        public void ThenProviderIsAbleToEditAllApprenticesBeforeApproval()
        {
            _providerApproveApprenticeDetailsPage = _providerStepsHelper.EditAllDetailsOfApprentice(_providerApproveApprenticeDetailsPage);
        }

        [Then(@"Provider is able to delete all apprentices before approval")]
        public void ThenProviderIsAbleToDeleteAllApprenticesBeforeApproval()
        {
            _providerApproveApprenticeDetailsPage = _providerStepsHelper.DeleteApprentice(_providerApproveApprenticeDetailsPage);
        }

        [Then(@"Provider is able to delete the cohort before approval")]
        public void ThenProviderIsAbleToDeleteTheCohortBeforeApproval() => _providerStepsHelper.DeleteCohort(_providerApproveApprenticeDetailsPage);

        [When(@"Provider add (.*) apprentice details using bulk upload and sends to employer for approval")]
        public void WhenProviderAddApprenticeDetailsUsingBulkUploadAndSendsToEmployerForApproval(int numberOfApprentices)
        {
            _providerStepsHelper.AddApprenticeViaBulkUpload(numberOfApprentices);
        }
    }
}