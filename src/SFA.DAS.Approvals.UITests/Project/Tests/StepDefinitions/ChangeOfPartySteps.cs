using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using System;
using System.Linq;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using NUnit.Framework;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ChangeOfPartySteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        private readonly MultipleAccountsLoginHelper _multipleAccountsLoginHelper;

        private readonly string _oldEmployer;
        private readonly string _newEmployer;

        public ChangeOfPartySteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _loginHelper = new EmployerPortalLoginHelper(context);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.GetApprovalsConfig<ApprovalsConfig>());
            _multipleAccountsLoginHelper = new MultipleAccountsLoginHelper(context);
            _oldEmployer = context.GetRegistrationConfig<RegistrationConfig>().RE_OrganisationName;
            _newEmployer = context.GetTransfersConfig<TransfersConfig>().ReceiverOrganisationName;

        }

        [Given(@"the provider has an apprentice with stopped status")]
        [Given(@"the employer has an apprentice with stopped status")]
        public void GivenTheProviderHasAnApprenticeWithStoppedStatus()
        {
            if (_context.ScenarioInfo.Tags.Contains("changeOfEmployer"))
            {
                _objectContext.UpdateOrganisationName(_oldEmployer);
                Login();
            }
            else
            {
                _loginHelper.Login(_context.GetUser<LevyUser>(), true);
            }

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(1);
            _employerStepsHelper.SetCohortReference(cohortReference);
            _providerStepsHelper.Approve();
            _employerStepsHelper.StopApprenticeThisMonth();
        }

        [When(@"employer sends COP request to new provider")]
        public void WhenEmployerSendsCOPRequestToNewProvider()
        {
            _employerStepsHelper.ViewCurrentApprenticeDetails(false)
                                .ClickOnChangeOfProviderLink()
                                .ClickOnContinueButton()
                                .ChooseTrainingProviderPage()
                                .SelectYesAndContinue();


            var _newcohortReference = _commitmentsSqlDataHelper.GetNewcohortReference(Convert.ToString(_dataHelper.Ulns.First()));
            _employerStepsHelper.UpdateCohortReference(_newcohortReference);
        }

        [Then(@"employer should not be able to see change link for another CoP")]
        public void ThenEmployerShouldNotBeAbleToSeeChangeLinkForAnotherCoP()
        {
            Assert.IsFalse(_employerStepsHelper.ViewCurrentApprenticeDetails(false).IsChangeOfProviderLinkDisplayed());
        }


        [When(@"provider sends COE request to new employer")]
        public void WhenProviderSendsCOERequestToNewEmployer()
        {
            _providerStepsHelper.StartChangeOfEmployerJourney();

            var _newcohortReference = _commitmentsSqlDataHelper.GetNewcohortReference(Convert.ToString(_dataHelper.Ulns.First()));

            _employerStepsHelper.UpdateCohortReference(_newcohortReference);
        }

        [Then(@"new employer approves the cohort")]
        [When(@"new employer approves the cohort")]
        public void ThenNewEmployerApprovesTheCohort()
        {
            _objectContext.UpdateOrganisationName(_newEmployer);
            _employerStepsHelper.Approve();
        }

        [Then(@"a new live apprenticeship record is created")]
        public void ThenANewLiveApprenticeshipRecordIsCreated()
        {
            _employerStepsHelper
                .GoToManageYourApprenticesPage()
                .VerifyApprenticeExists();
        }

        [When(@"new employer rejects the cohort")]
        public void WhenNewEmployerRejectsTheCohort()
        {
            _objectContext.UpdateOrganisationName(_newEmployer);
            _employerStepsHelper.Reject();
        }

        [Then(@"Provider Approves the Cohort")]
        public void ThenProviderApprovesTheCohort()
        {
            _providerStepsHelper
                .GoToProviderHomePage(false)
                .GoToYourCohorts()
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails()
                .SelectContinueToApproval()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

        [When(@"Provider deletes the Cohort")]
        public void WhenProviderDeletesTheCohort()
        {
            _providerStepsHelper.DeleteCohort(_providerStepsHelper.CurrentCohortDetails());
        }

        [Then(@"provider can change employer again")]
        public void ThenProviderCanChangeEmployerAgain()
        {
            _providerStepsHelper.StartChangeOfEmployerJourney();
        }

        [Then(@"a banner is displayed for provider with a link to ""(.*)"" cohort")]
        public void ThenABannerIsDisplayedForProviderWithALinkToCohort(string status)
        {
            bool editable = status == "editable" ? true : false;

            ProviderApprenticeDetailsPage providerApprenticeDetailsPage =
                _providerStepsHelper.GoToProviderHomePage(editable)
                                    .GoToProviderManageYourApprenticePage()
                                    .SelectViewCurrentApprenticeDetails();

            if (editable)
                 ValidateBannerWithLinkToEditableCohort(providerApprenticeDetailsPage);
            else
                ValidateBannerWithLinkToNonEditableCohort(providerApprenticeDetailsPage);
        }

        [When(@"Validate that old Employer cannot request CoP during in-flight CoE")]
        public void WhenValidateThatOldEmployerCannotRequestCoPDuringIn_FlightCoE()
        {
            bool IsChangeOfProviderLinkDisplayed
               = _employerStepsHelper
               .GoToManageYourApprenticesPage()
               .SelectViewCurrentApprenticeDetails()
               .IsChangeOfProviderLinkDisplayed();

            Assert.IsFalse(IsChangeOfProviderLinkDisplayed, "Validate that CoP link is not available for the old employer");
        }

        [Then(@"Validate that old Employer cannot request CoP after successful CoE")]
        public void ThenValidateThatOldEmployerCannotRequestCoPAfterSuccessfulCoE()
        {
            _objectContext.UpdateOrganisationName(_oldEmployer);

            bool IsChangeOfProviderLinkDisplayed
              = _employerStepsHelper
              .GoToManageYourApprenticesPage()
              .SelectViewCurrentApprenticeDetails()
              .IsChangeOfProviderLinkDisplayed();

            Assert.IsFalse(IsChangeOfProviderLinkDisplayed, "Validate that CoP link is not available for the old employer");
        }

        private void Login() => _multipleAccountsLoginHelper.Login(_context.GetUser<TransfersUser>(), true);
    
        private void ValidateBannerWithLinkToNonEditableCohort(ProviderApprenticeDetailsPage providerApprenticeDetailsPage)
        {
            string expectedText = "There are changes to this apprentice's details that are waiting for approval by the new employer.";
            string actualText = providerApprenticeDetailsPage.GetCoPBanner();

            Assert.AreEqual(expectedText, actualText, "Text in the change of party banner");

            var EditBoxOnApprenticeDetailsPage = providerApprenticeDetailsPage
                                                    .ClickViewChangesLink()
                                                    .ClickOnReviewNewDetailsLink()
                                                    .SelectViewApprentice()
                                                    .GetAllEditBoxes();

            Assert.IsTrue(EditBoxOnApprenticeDetailsPage.Count < 1, "validate there are no edit or input box available on View apprentice details page");
        }

        private void ValidateBannerWithLinkToEditableCohort(ProviderApprenticeDetailsPage providerApprenticeDetailsPage)
        {
            string expectedText = "The new employer has requested changes to this apprentice's details.";
            string actualText = providerApprenticeDetailsPage.GetCoPBanner();

            Assert.AreEqual(expectedText, actualText, "Text in the change of party banner");

            var EditBoxOnApprenticeDetailsPage = providerApprenticeDetailsPage
                                                    .ClickViewChangesLink()
                                                    .ClickOnReviewNewDetailsToUpdateLink()
                                                    .SelectEditApprentice()
                                                    .GetAllEditBoxes();

            Assert.IsTrue(EditBoxOnApprenticeDetailsPage.Count > 3, "validate that cohort is editable on View apprentice details page");
        }

    }
}
