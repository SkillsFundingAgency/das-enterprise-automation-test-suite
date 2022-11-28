using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using NUnit.Framework;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSteps
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        protected readonly ProviderConfig _providerConfig;
        #endregion

        private ProviderApproveApprenticeDetailsPage _providerApproveApprenticeDetailsPage;
        private ProviderAddApprenticeDetailsViaSelectJourneyPage providerAddApprenticeDetailsViaSelectJourneyPage;
        private readonly RetryAssertHelper _assertHelper;

        public ProviderSteps(ScenarioContext context)
        {
            _context = context;
            _assertHelper = context.Get<RetryAssertHelper>();
            _providerStepsHelper = new ProviderStepsHelper(context);           
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
            _providerConfig = context.GetProviderConfig<ProviderConfig>();
        }

        [Then(@"the provider will no longer be able to change the email address")]
        public void ThenTheProviderWillNoLongerBeAbleToChangeTheEmailAddress() => _providerStepsHelper.VerifyReadOnlyEmail();

        [Given(@"the provider update the email address")]
        public void GivenTheProviderUpdateTheEmailAddress() => _providerStepsHelper.AddEmailAndSentToEmployerForApproval();

        [Then(@"the provider approves the cohorts")]
        public void ThenTheProviderApprovesTheCohorts() => _providerStepsHelper.CurrentCohortDetails().SubmitApprove();

        [When(@"the provider adds (.*) apprentices and sends to employer to review")]
        public void WhenTheProviderAddsApprenticesAndSendsToEmployerToReview(int numberOfApprentices) => _providerStepsHelper.AddApprentice(numberOfApprentices).SubmitSendToEmployerToReview();

        [When(@"the provider adds (.*) apprentices approves them and sends to employer to approve")]
        public void WhenTheProviderAddsApprenticesApprovesThemAndSendsToEmployerToApprove(int numberOfApprentices) => _providerStepsHelper.AddApprenticeAndSendToEmployerForApproval(numberOfApprentices);

        [When(@"the provider selects Flexi-job agency radio button on Select Delivery Model screen")]
        public void WhenTheProviderSelectsFlexi_JobAgencyRadioButtonOnSelectDeliveryModelScreen() => _providerStepsHelper.AddFlexiJobApprentice();

        [When(@"the provider opts (.*) learner into the pilot")]
        public void WhenTheProviderOptsLearnerIntoThePilot(int numberOfApprentices) => _providerApproveApprenticeDetailsPage = _providerStepsHelper.AddApprenticeForFlexiPaymentsProvider(numberOfApprentices, true);

        [Given(@"the provider adds Ulns and opts the learners out of the pilot")]
        [When(@"the provider adds Ulns and opts the learners out of the pilot")]
        public void WhenTheProviderAddsUlnsAndOptsTheLearnersOutOfThePilot() => _providerApproveApprenticeDetailsPage = _providerStepsHelper.ApproveFlexiPilotCohort(false);

        [When(@"the provider opts (.*) learner out of the pilot")]
        public void WhenTheProviderOptsLearnerOutOfThePilot(int numberOfApprentices) => _providerApproveApprenticeDetailsPage = _providerStepsHelper.AddApprenticeForFlexiPaymentsProvider(numberOfApprentices, false);

        [When(@"the provider sends the cohort to employer to approve")]
        public void WhenTheProviderSendsTheCohortToEmployerToApprove() => _providerApproveApprenticeDetailsPage.SubmitSendToEmployerToReview();

        [Then(@"provider validate Flexi-job agency content on Add Apprentice Details page and submit valid details")]
        public void ThenProviderValidateFlexi_JobAgencyContentOnAddApprenticeDetailsPageAndSubmitValidDetails() => _providerStepsHelper.ValidateFlexiJobAgencyContentAndAddApprenticeDetails();

        [Then(@"the provider adds Ulns and approves the cohorts")]
        public void TheProviderAddsUlnsAndApprovesTheCohorts() => _providerStepsHelper.Approve();

        [Then(@"the provider validates Flexi-job content, adds Uln and approves the cohorts")]
        public void ThenTheProviderValidatesFlexi_JobContentAddsUlnAndApprovesTheCohorts() => _providerStepsHelper.ValidateFlexiJobContentAndApproveCohort();

        [When(@"the provider adds Ulns and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsAndApprovesTheCohortsAndSendsToEmployer() => _providerStepsHelper.EditApprentice().SubmitApprove();

        [When(@"the provider adds Ulns confirms courses are standards and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsConfirmsCoursesAreStandardsAndApprovesTheCohortsAndSendsToEmployer() => _providerStepsHelper.EditApprentice(true).SubmitApprove();
        
        [When(@"the provider adds Ulns")]
        public void WhenTheProviderAddsUlns() => _providerStepsHelper.EditApprentice(true);

        [Given(@"the provider adds Ulns and Opt the learners into the pilot")]
        [When(@"the provider adds Ulns and Opt the learners into the pilot")]
        public void ThenTheProviderAddsUlnsAndOptTheLearnersIntoThePilot() => _providerApproveApprenticeDetailsPage = _providerStepsHelper.ApproveFlexiPilotCohort(true);

        [When(@"Provider successfully approves the cohort")]
        [Then(@"Provider successfully approves the cohort")]
        public void ThenProviderApprovesTheCohort() => _providerApproveApprenticeDetailsPage.SubmitApprove();

        [When(@"Provider uses BulkUpload to add (.*) apprentice details into existing cohort")]
        public void WhenProviderUsesBulkUploadToAddApprenticeDetailsIntoExistingCohortAndApprenticeDetailsIntoA_ExistingCohort(int numberOfApprentices)
        {
            _providerStepsHelper.AddApprenticeViaBulkUploadV2(numberOfApprentices, 0);
        }

        [Then(@"Provider is able to view the cohort with employer")]
        public void ThenProviderIsAbleToViewTheCohortWithEmployer()
        {
            _providerStepsHelper.GoToProviderHomePage();

            new ProviderApprenticeRequestsPage(_context, true).GoToCohortsWithEmployers().SelectViewCurrentCohortDetails();
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
        public void ThenProviderIsAbleToEditAllApprenticesBeforeApproval() => _providerApproveApprenticeDetailsPage = _providerStepsHelper.EditAllDetailsOfApprentice(_providerApproveApprenticeDetailsPage);

        [Then(@"Provider is able to delete all apprentices before approval")]
        public void ThenProviderIsAbleToDeleteAllApprenticesBeforeApproval() => _providerApproveApprenticeDetailsPage = _providerStepsHelper.DeleteApprentice(_providerApproveApprenticeDetailsPage);

        [Then(@"Provider is able to delete the cohort before approval")]
        public void ThenProviderIsAbleToDeleteTheCohortBeforeApproval() => _providerStepsHelper.DeleteCohort(_providerApproveApprenticeDetailsPage);

        [When(@"Provider add (.*) apprentice details using bulk upload and sends to employer for approval")]
        public void WhenProviderAddApprenticeDetailsUsingBulkUploadAndSendsToEmployerForApproval(int numberOfApprentices) => _providerStepsHelper.AddApprenticeViaBulkUpload(numberOfApprentices);

        [When(@"Provider add (.*) apprentice details using bulk upload and sends to non-levy employer for approval")]
        public void WhenProviderAddApprenticeDetailsUsingBulkUploadAndSendsToNonLevyEmployerForApproval(int numberOfApprentices) => _providerStepsHelper.AddApprenticeViaBulkUpload(numberOfApprentices);

        [Given(@"the Provider has some apprentices in ready to review and draft status")]
        public void GivenTheProviderHasSomeApprenticesInReadyToReviewAndDraftStatus() => Assert.IsNotNull(GetProvidersDraftAndReadyForReviewCohortsCount(), $"No cohorts found in 'Draft' or 'Ready to review' status for the UKPRN: [{_providerConfig.Ukprn}]!");

        [Given(@"the Provider navigates to Choose a cohort page via the Home page")]
        public void GivenTheProviderNavigatesToChooseACohortPageViaTheHomePage() => _providerStepsHelper.NavigateToChooseACohortPage();

        [Then(@"the Provider should only see apprentices with status Draft or Ready to review excluding apprentices related to change of party")]
        public void ThenTheProviderShouldOnlySeeApprenticesWithStatusDraftOrReadyToReviewExcludingApprenticesRelatedToChangeOfParty()
        {
            _assertHelper.RetryOnNUnitException(() =>
            {
                var expected = GetProvidersDraftAndReadyForReviewCohortsCount();

                var actual = new ProviderChooseACohortPage(_context).GetDataRowsCount();

                Assert.AreEqual(expected, actual, $"Incorrect number of cohorts displayed, expected {expected} from db but {actual} displayed in the UI ");
            });
        }

        [Then(@"User should be able to add or edit apprentice details on any cohort")]
        public void ThenUserShouldBeAbleToAddOrEditApprenticeDetailsOnAnyCohort()
        {
            var employerUser = _context.GetUser<LevyUser>();
            var organisationName = employerUser.OrganisationName.Substring(0, 3) + "%";
            int employerAccountId = _context.Get<AccountsDbSqlHelper>().GetEmployerAccountId(employerUser.Username, organisationName);
            var cohortReference = _commitmentsSqlDataHelper.GetOldestEditableCohortReference(Convert.ToInt32(_providerConfig.Ukprn), employerAccountId);

            var providerApproveApprenticeDetailsPage = new ProviderChooseACohortPage(_context).SelectCohort(cohortReference);            
            var existingapprentices = providerApproveApprenticeDetailsPage.GetNumberOfEditableApprentices();
            if (existingapprentices > 0)
            {
                _context.Get<ObjectContext>().SetNoOfApprentices(Convert.ToInt32(existingapprentices));
                _providerStepsHelper.DeleteApprentice(providerApproveApprenticeDetailsPage);
            }

            providerApproveApprenticeDetailsPage.SelectAddAnApprentice()
                .ProviderSelectsAStandard()
                .SubmitValidPersonalDetails()
                .SubmitValidTrainingDetails()
                .SubmitApprove();
        }

        [Given(@"Provider creates a new cohort")]
        public void GivenProviderCreatesANewCohort()
        {
            providerAddApprenticeDetailsViaSelectJourneyPage = _providerStepsHelper
               .GoToProviderHomePage(true)
               .GotoSelectJourneyPage()
               .SelectAddManually();
        }

        [Given(@"provider add leaners details and opts them into the pilot")]
        public void GivenOptsLeanerIntoThePilot()
        {
            _providerApproveApprenticeDetailsPage = providerAddApprenticeDetailsViaSelectJourneyPage
                .SelectOptionCreateNewCohort()
                .ChooseAnEmployer("Levy")
                .ConfirmEmployer()
                .ProviderSelectsAStandard()
                .SubmitValidPersonalDetails(true)
                .SubmitValidTrainingDetails();
        }

        private int? GetProvidersDraftAndReadyForReviewCohortsCount() => _commitmentsSqlDataHelper.GetProvidersDraftAndReadyForReviewCohortsCount(_providerConfig.Ukprn);
    }
}