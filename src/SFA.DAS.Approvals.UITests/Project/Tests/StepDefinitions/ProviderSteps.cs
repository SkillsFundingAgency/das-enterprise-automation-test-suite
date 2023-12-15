using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderSteps(ScenarioContext context)
    {

        #region Helpers and Context
        private readonly ProviderStepsHelper _providerStepsHelper = new(context);
        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper = new(context);
        private readonly ProviderApproveStepsHelper _providerApproveStepsHelper = new(context);
        private readonly ProviderEditStepsHelper _providerEditStepsHelper = new(context);
        private readonly ProviderDeleteStepsHelper _providerDeleteStepsHelper = new(context);
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper = new(context.Get<ObjectContext>(), context.Get<DbConfig>());
        private readonly ProviderConfig _providerConfig = context.GetProviderConfig<ProviderConfig>();
        #endregion

        private ProviderApproveApprenticeDetailsPage _providerApproveApprenticeDetailsPage;
        private readonly RetryAssertHelper _assertHelper = context.Get<RetryAssertHelper>();

        [Then(@"the provider will no longer be able to change the email address")]
        public void ThenTheProviderWillNoLongerBeAbleToChangeTheEmailAddress() => _providerEditStepsHelper.ProviderEditApprentice().VerifyReadOnlyEmail();

        [Given(@"the provider update the email address")]
        public void GivenTheProviderUpdateTheEmailAddress() => _providerEditStepsHelper.ProviderEditApprentice().AddValidEmailAndContinue().AcceptChangesAndSubmit();

        [Then(@"the provider approves the cohorts")]
        public void ThenTheProviderApprovesTheCohorts() => _providerApproveStepsHelper.Approve();

        [When(@"the provider adds (.*) apprentices and sends to employer to review")]
        public void WhenTheProviderAddsApprenticesAndSendsToEmployerToReview(int numberOfApprentices) => _providerStepsHelper.AddApprentice(numberOfApprentices).SubmitSendToEmployerToReview();

        [When(@"the provider adds (.*) apprentices approves them and sends to employer to approve")]
        public void WhenTheProviderAddsApprenticesApprovesThemAndSendsToEmployerToApprove(int numberOfApprentices) => _providerStepsHelper.AddApprenticeAndSendToEmployerForApproval(numberOfApprentices);

        [When(@"the provider opts (.*) learner into the pilot")]
        public void WhenTheProviderOptsLearnerIntoThePilot(int numberOfApprentices) => _providerApproveApprenticeDetailsPage = _providerStepsHelper.AddApprentice(numberOfApprentices);

        [When(@"the provider opts (.*) learner out of the pilot")]
        public void WhenTheProviderOptsLearnerOutOfThePilot(int numberOfApprentices) => _providerApproveApprenticeDetailsPage = _providerStepsHelper.AddApprentice(numberOfApprentices);

        [When(@"the provider sends the cohort to employer to approve")]
        public void WhenTheProviderSendsTheCohortToEmployerToApprove() => _providerApproveApprenticeDetailsPage.SubmitSendToEmployerToReview();

        [Then(@"the provider adds Ulns and approves the cohorts")]
        public void TheProviderAddsUlnsAndApprovesTheCohorts() => _providerApproveStepsHelper.EditAndApprove();

        [When(@"the provider adds Ulns and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsAndApprovesTheCohortsAndSendsToEmployer() => _providerEditStepsHelper.EditApprentice().SubmitApprove();

        [When(@"the provider adds Ulns confirms courses are standards and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsConfirmsCoursesAreStandardsAndApprovesTheCohortsAndSendsToEmployer() => _providerEditStepsHelper.CheckCoursesAreStandardsAndEditApprentice().SubmitApprove();

        [When(@"the provider adds Ulns")]
        public void WhenTheProviderAddsUlns() => _providerEditStepsHelper.EditApprentice();

        [Then(@"Provider is able to view the cohort with employer")]
        public void ThenProviderIsAbleToViewTheCohortWithEmployer()
        {
            _providerCommonStepsHelper.GoToProviderHomePage();

            new ProviderApprenticeRequestsPage(context, true).GoToCohortsWithEmployers().SelectViewCurrentCohortDetails();
        }

        [Then(@"Provider is able to view all apprentice details when the cohort with employer")]
        public void ThenProviderIsAbleToViewAllApprenticeDetailsWhenTheCohortWithEmployer()
        {
            ProvideViewApprenticesDetailsPage _providerViewYourCohortPage = new(context);

            int totalApprentices = _providerViewYourCohortPage.TotalNoOfApprentices();

            for (int i = 0; i < totalApprentices; i++) _providerViewYourCohortPage.SelectViewApprentice(i).SelectReturnToCohortView();
        }

        [When(@"Provider adds (.*) apprentices and saves without sending to the employer")]
        public void WhenProviderAddsApprenticesAndSavesWithoutSendingToTheEmployer(int numberOfApprentices)
        {
            _providerStepsHelper.AddApprentice(numberOfApprentices).SubmitSaveButDontSendToEmployer();

            _providerApproveApprenticeDetailsPage = _providerEditStepsHelper.EditApprentice();
        }

        [Then(@"Provider is able to edit all apprentices before approval")]
        public void ThenProviderIsAbleToEditAllApprenticesBeforeApproval() => _providerApproveApprenticeDetailsPage = _providerEditStepsHelper.EditAllDetailsOfApprentice(_providerApproveApprenticeDetailsPage);

        [Then(@"Provider is able to delete all apprentices before approval")]
        public void ThenProviderIsAbleToDeleteAllApprenticesBeforeApproval() => _providerApproveApprenticeDetailsPage = _providerDeleteStepsHelper.DeleteApprentice(_providerApproveApprenticeDetailsPage);

        [Then(@"Provider is able to delete the cohort before approval")]
        public void ThenProviderIsAbleToDeleteTheCohortBeforeApproval() => ProviderDeleteStepsHelper.DeleteCohort(_providerApproveApprenticeDetailsPage);

        [Given(@"the Provider has some apprentices in ready to review and draft status")]
        public void GivenTheProviderHasSomeApprenticesInReadyToReviewAndDraftStatus() => Assert.IsNotNull(GetProvidersDraftAndReadyForReviewCohortsCount(), $"No cohorts found in 'Draft' or 'Ready to review' status for the UKPRN: [{_providerConfig.Ukprn}]!");

        [Given(@"the Provider navigates to Choose a cohort page via the Home page")]
        public void GivenTheProviderNavigatesToChooseACohortPageViaTheHomePage() => _providerCommonStepsHelper.GoToProviderHomePage(false).GotoSelectJourneyPage().SelectAddManually().SelectOptionAddToAnExistingCohort();

        [Then(@"the Provider should only see apprentices with status Draft or Ready to review excluding apprentices related to change of party")]
        public void ThenTheProviderShouldOnlySeeApprenticesWithStatusDraftOrReadyToReviewExcludingApprenticesRelatedToChangeOfParty()
        {
            _assertHelper.RetryOnNUnitException(() =>
            {
                var expected = GetProvidersDraftAndReadyForReviewCohortsCount();

                var actual = new ProviderChooseACohortPage(context).GetDataRowsCount();

                Assert.AreEqual(expected, actual, $"Incorrect number of cohorts displayed, expected {expected} from db but {actual} displayed in the UI ");
            });
        }

        [Then(@"User should be able to add or edit apprentice details on any cohort")]
        public void ThenUserShouldBeAbleToAddOrEditApprenticeDetailsOnAnyCohort()
        {
            var employerUser = context.GetUser<LevyUser>();
            var organisationName = employerUser.OrganisationName[..3] + "%";
            int employerAccountId = context.Get<AccountsDbSqlHelper>().GetEmployerAccountId(employerUser.Username, organisationName);
            var cohortReference = _commitmentsSqlDataHelper.GetOldestEditableCohortReference(Convert.ToInt32(_providerConfig.Ukprn), employerAccountId);

            var providerApproveApprenticeDetailsPage = new ProviderChooseACohortPage(context).SelectCohort(cohortReference);
            var existingapprentices = providerApproveApprenticeDetailsPage.GetNumberOfEditableApprentices();
            if (existingapprentices > 0)
            {
                context.Get<ObjectContext>().SetNoOfApprentices(Convert.ToInt32(existingapprentices));
                _providerDeleteStepsHelper.DeleteApprentice(providerApproveApprenticeDetailsPage);
            }

            providerApproveApprenticeDetailsPage.SelectAddAnApprentice()
                .ProviderSelectsAStandard()
                .SubmitValidApprenticeDetails()
                .SubmitApprove();
        }

        [Given(@"Provider creates a new cohort")]
        public void GivenProviderCreatesANewCohort() => _providerCommonStepsHelper.GoToProviderHomePage().GotoSelectJourneyPage().SelectAddManually();

        [Then(@"the provider validates flexi-job content and approves cohort")]
        [Then(@"the provider validates Flexi-job content, adds Uln and approves the cohorts")]
        public void ThenTheProviderValidatesFlexi_JobContentAndApprovesCohort() => _providerApproveStepsHelper.ValidateFlexiJobContentAndApproveCohort();

        [When(@"the provider adds an apprentice on the Regular Delivery Model and sends to Employer for approval")]
        public void WhenTheProviderAddsAnApprenticeOnTheRegularDeliveryModelAndSendsToEmployerForApproval() => _providerStepsHelper.AddApprenticeAndSelectRegularDeliveryModel();

        private int? GetProvidersDraftAndReadyForReviewCohortsCount() => _commitmentsSqlDataHelper.GetProvidersDraftAndReadyForReviewCohortsCount(_providerConfig.Ukprn);

        [Then(@"provider navigates to Approve Apprentice page and deletes Cohort before approval")]
        public void ThenProviderNavigatesToApproveApprenticePageAndDeletesCohortBeforeApproval() => _providerCommonStepsHelper.ViewCurrentCohortDetails().SelectDeleteCohort().ConfirmDeleteAndSubmit();

        [Then(@"the provider can no longer approve the draft cohort")]
        public void ThenTheProviderCanNoLongerApproveTheDraftCohort() => _providerCommonStepsHelper.ViewCurrentCohortDetails().ValidateProviderCannotApproveCohort();

    }
}