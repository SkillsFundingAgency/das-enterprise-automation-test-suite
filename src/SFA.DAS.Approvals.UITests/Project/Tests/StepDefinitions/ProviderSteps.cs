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
using SFA.DAS.Login.Service.Helpers;

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

        public ProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);           
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
            _providerConfig = context.GetProviderConfig<ProviderConfig>();
        }

        [Then(@"the provider approves the cohorts")]
        public void ThenTheProviderApprovesTheCohorts()
        {
            _providerStepsHelper
                .CurrentCohortDetails()
                .SubmitApprove();
        }

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
        public void TheProviderAddsUlnsAndApprovesTheCohorts()
        {
            _providerStepsHelper.Approve();
        }

        [When(@"the provider adds Ulns and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsAndApprovesTheCohortsAndSendsToEmployer()
        {
            _providerStepsHelper
                .EditApprentice()
                .SubmitApprove();
        }

        [When(@"the provider adds Ulns confirms courses are standards and approves the cohorts and sends to employer")]
        public void WhenTheProviderAddsUlnsConfirmsCoursesAreStandardsAndApprovesTheCohortsAndSendsToEmployer()
        {
            _providerStepsHelper
                .EditApprentice(true)
                .SubmitApprove();
        }


        [Then(@"Provider is able to view the cohort with employer")]
        public void ThenProviderIsAbleToViewTheCohortWithEmployer()
        {
            _providerStepsHelper.GoToProviderHomePage();

            new ProviderApprenticeRequestsPage(_context, true)
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
        public void ThenProviderIsAbleToDeleteTheCohortBeforeApproval()
        {
            _providerStepsHelper.DeleteCohort(_providerApproveApprenticeDetailsPage);
        }

        [When(@"Provider add (.*) apprentice details using bulk upload and sends to employer for approval")]
        public void WhenProviderAddApprenticeDetailsUsingBulkUploadAndSendsToEmployerForApproval(int numberOfApprentices)
        {
            _providerStepsHelper.AddApprenticeViaBulkUpload(numberOfApprentices);
        }

        [Given(@"the Provider has some apprentices in ready to review and draft status")]
        public void GivenTheProviderHasSomeApprenticesInReadyToReviewAndDraftStatus()
        {
            var _expectedCohorts = _commitmentsSqlDataHelper.GetProvidersDraftAndReadyForReviewCohortsCount(Convert.ToInt32(_providerConfig.Ukprn));
            Assert.IsNotNull(_expectedCohorts, $"No cohorts found in 'Draft' or 'Ready to review' status for the UKPRN: [{_providerConfig.Ukprn}]!");
        }

        [Given(@"the Provider navigates to Choose a cohort page via the Home page")]
        public void GivenTheProviderNavigatesToChooseACohortPageViaTheHomePage()
        {
            _providerStepsHelper.NavigateToChooseACohortPage();
        }

        [Then(@"the Provider should only see apprentices with status Draft or Ready to review excluding apprentices related to change of party")]
        public void ThenTheProviderShouldOnlySeeApprenticesWithStatusDraftOrReadyToReviewExcludingApprenticesRelatedToChangeOfParty()
        {
            var _expectedNumberOfCohorts = _commitmentsSqlDataHelper.GetProvidersDraftAndReadyForReviewCohortsCount(Convert.ToInt32(_providerConfig.Ukprn));
            var _actualNumberOfCohorts = new ProviderChooseACohortPage(_context).GetDataRowsCount();
            Assert.AreEqual(_expectedNumberOfCohorts, _actualNumberOfCohorts, "Number of cohorts to be displayed");
        }

        [Then(@"User should be able to add or edit apprentice details on any cohort")]
        public void ThenUserShouldBeAbleToAddOrEditApprenticeDetailsOnAnyCohort()
        {
            var employerUser = _context.GetUser<LevyUser>();
            var employerName = employerUser.OrganisationName.Substring(0, 3) + "%";
            int employerAccountId = _context.Get<AgreementIdSqlHelper>().GetEmployerAccountId(employerUser.Username, employerName);
            var cohortReference = _commitmentsSqlDataHelper.GetOldestEditableCohortReference(Convert.ToInt32(_providerConfig.Ukprn), employerAccountId);

            var providerApproveApprenticeDetailsPage = new ProviderChooseACohortPage(_context).SelectCohort(cohortReference);            
            var existingapprentices = providerApproveApprenticeDetailsPage.GetNumberOfEditableApprentices();
            if (existingapprentices > 0)
            {
                _context.Get<ObjectContext>().SetNoOfApprentices(Convert.ToInt32(existingapprentices));
                _providerStepsHelper.DeleteApprentice(providerApproveApprenticeDetailsPage);
            }

            providerApproveApprenticeDetailsPage.SelectAddAnApprentice().SubmitValidApprenticeDetails().SubmitApprove();
        }

    }
}