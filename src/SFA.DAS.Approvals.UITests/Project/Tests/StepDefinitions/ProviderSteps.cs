using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private ProviderReviewYourCohortPage _providerReviewYourCohortPage;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;

        public ProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);
            _objectContext = context.Get<ObjectContext>();
            _tabHelper = context.Get<TabHelper>();
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

        [Given(@"the Provider approves the apprenticeship request")]
        [Then(@"the provider adds Ulns and approves the cohorts")]
        public void TheProviderAddsUlnsAndApprovesTheCohorts()
        {
            _providerStepsHelper.Approve();

            if (_objectContext.GetIsEIJourney())
            {
                _tabHelper.SwitchToFirstTab();
                new HomePage(_context, true);
            }
        }

        [When(@"the provider adds Ulns and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsAndApprovesTheCohortsAndSendsToEmployer()
        {
            var providerReviewYourCohortPage = _providerStepsHelper.EditApprentice();

            providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

        [When(@"the provider adds Ulns confirms courses are standards and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsConfirmsCoursesAreStandardsAndApprovesTheCohortsAndSendsToEmployer()
        {
            var providerReviewYourCohortPage = _providerStepsHelper.EditApprentice(true);

            providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }


        [Then(@"Provider is able to view the cohort with employer")]
        public void ThenProviderIsAbleToViewTheCohortWithEmployer()
        {
            var providerHomePage = _providerStepsHelper.GoToProviderHomePage();

            new ProviderYourCohortsPage(_context, true)
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
            _providerReviewYourCohortPage = _providerStepsHelper.EditApprentice();
        }

        [Then(@"Provider is able to edit all apprentices before approval")]
        public void ThenProviderIsAbleToEditAllApprenticesBeforeApproval()
        {
            _providerReviewYourCohortPage = _providerStepsHelper.EditAllDetailsOfApprentice(_providerReviewYourCohortPage);
        }

        [Then(@"Provider is able to delete all apprentices before approval")]
        public void ThenProviderIsAbleToDeleteAllApprenticesBeforeApproval()
        {
            _providerReviewYourCohortPage = _providerStepsHelper.DeleteApprentice(_providerReviewYourCohortPage);
        }

        [Then(@"Provider is able to delete the cohort before approval")]
        public void ThenProviderIsAbleToDeleteTheCohortBeforeApproval()
        {
            _providerStepsHelper.DeleteCohort(_providerReviewYourCohortPage);
        }

        [When(@"Provider add (.*) apprentice details using bulk upload and sends to employer for approval")]
        public void WhenProviderAddApprenticeDetailsUsingBulkUploadAndSendsToEmployerForApproval(int numberOfApprentices)
        {
            _providerStepsHelper.AddApprenticeViaBulkUpload(numberOfApprentices);
        }
    }
}