using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ChangeOfProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly ChangeOfPartyConfig _changeOfPartyConfig;
        private readonly ProviderLoginUser _newProviderLoginDetails;


        public ChangeOfProviderSteps(ScenarioContext context)
        {
            _context = context;
            _changeOfPartyConfig = context.GetChangeOfPartyConfig<ChangeOfPartyConfig>();
            _newProviderLoginDetails = new ProviderLoginUser { Username = _changeOfPartyConfig.UserId, Password = _changeOfPartyConfig.Password, Ukprn = _changeOfPartyConfig.Ukprn };
            new RestartWebDriverHelper(context).RestartWebDriver(UrlConfig.Provider_BaseUrl, "Approvals");
        }

        [When(@"new provider approves the cohort")]
        public void WhenNewProviderApprovesTheCohort()
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_newProviderLoginDetails, false);

            new ProviderYourCohortsPage(_context, true)
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails()
                .IsAddApprenticeButtonDisplayed()
                .IsBulkUpLoadButtonDisplayed()
                .SelectEditApprentice()
                .ValidateEditableTextBoxes(6)
                .EditCopApprenticeDetails()
                .SelectContinueToApproval()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

        [When(@"employer approves the cohort")]
        public void WhenEmployerApprovesTheCohort()
        {
            new EmployerStepsHelper(_context)
                .EmployerReviewCohort()
                .IsAddApprenticeLinkDisplayed()
                .EmployerDoesSecondApproval();
        }

        [Then(@"a new live apprenticeship record is created with new Provider")]
        public void ThenANewLiveApprenticeshipRecordIsCreatedWithNewProvider()
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_newProviderLoginDetails, true);

            new ProviderManageYourApprenticesPage(_context, true).SelectViewCurrentApprenticeDetails();
        }

        [Then(@"Employer can only edit start date, end date and Price on the new record")]
        public void ThenEmployerCanOnlyEditStartDateEndDateAndPriceOnTheNewRecord()
        {
            new EmployerStepsHelper(_context).GoToManageYourApprenticesPage()
                .SelectApprentices("Live")
                .ClickEditApprenticeDetailsLink();

            ValidateOnlyEditableApprenticeDetails();
        }

        [When(@"new provider rejects the cohort")]
        public void WhenNewProviderRejectsTheCohort()
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_newProviderLoginDetails, false);
            new ProviderYourCohortsPage(_context, true)
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails()
                .SelectEditApprentice()
                .EditCopApprenticeDetails()
                .SelectContinueToApproval()
                .SubmitSendToEmployerToReview()
                .SendInstructionsToEmployerForCohortToReview();
        }

        [When(@"employer deletes the Cohort")]
        public void WhenEmployerDeletesTheCohort()
        {
            new EmployerStepsHelper(_context)
               .EmployerReviewCohort()
               .SelectDeleteThisGroup()
               .ConfirmDeleteAndSubmit();
        }

        [Then(@"employer can change provider again")]
        public void ThenEmployerCanChangeProviderAgain()
        {
            new EmployerStepsHelper(_context).StartChangeofNewTrainingProvider();        
        }

        [When(@"new provider approves the changes")]
        public void WhenNewProviderApprovesTheChanges()
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_newProviderLoginDetails, true);

            new ProviderYourCohortsPage(_context, true)
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails()
                .IsAddApprenticeButtonDisplayed()
                .IsBulkUpLoadButtonDisplayed()
                .SelectEditApprentice()
                .ValidateEditableTextBoxes(6)
                .EditCopApprenticeDetails()
                .SelectContinueToApproval()
                .SubmitApprove();
        }

        [Then(@"Prevent employer from requesting CoP on the original apprenticeship")]
        public void ThenPreventEmployerFromRequestingCoPOnTheOriginalApprenticeship()
        {
            bool IsChangeOfProviderLinkDisplayed 
                = new EmployerStepsHelper(_context)
                .GoToManageYourApprenticesPage()
                .SelectApprentices("Stopped")
                .IsChangeOfProviderLinkDisplayed();

            Assert.IsFalse(IsChangeOfProviderLinkDisplayed, "Validate that CoP link on the original apprentice record has been removed");
        }

        [Then(@"a banner is displayed for employer with a link to ""(.*)"" cohort")]
        public void ThenABannerIsDisplayedForEmployerWithALinkToCohort(string status)
        {
            bool editable = status == "editable" ? true : false;

            var employerApprenticeDetailsPage = new EmployerStepsHelper(_context).ViewCurrentApprenticeDetails(true);

            if (editable)
                ValidateBannerWithLinkToEditableCohort(employerApprenticeDetailsPage);
            else
                ValidateBannerWithLinkToNonEditableCohort(employerApprenticeDetailsPage);
        }

        private void ValidateBannerWithLinkToNonEditableCohort(ApprenticeDetailsPage apprenticeDetailsPage)
        {
            string expectedText = "There are changes to this apprentice's details that are waiting for approval by the training provider.";
            string actualText = apprenticeDetailsPage.GetAlertBanner();

            Assert.AreEqual(expectedText, actualText, "Text in the changes pending banner");

            /*
            var EditBoxOnApprenticeDetailsPage = apprenticeDetailsPage
                .ClickViewChangesLink();

                //.ClickOnReviewNewDetailsLink()
                //.SelectViewApprentice()
                //.GetAllEditBoxes();

            Assert.IsTrue(EditBoxOnApprenticeDetailsPage.Count < 1, "validate there are no edit or input box available on View apprentice details page");
            */
        }

        private void ValidateBannerWithLinkToEditableCohort(ApprenticeDetailsPage apprenticeDetailsPage)
        {
            string expectedText = "There are changes to this apprentice's details that you need to review.";
            string actualText = apprenticeDetailsPage.GetAlertBanner();

            Assert.AreEqual(expectedText, actualText, "Text in the changes pending banner");

            /*
            var EditBoxOnApprenticeDetailsPage = apprenticeDetailsPage
                    .ClickViewChangesLink();

                .ClickOnReviewNewDetailsToUpdateLink()
                .SelectEditApprentice()
                .GetAllEditBoxes();

            Assert.IsTrue(EditBoxOnApprenticeDetailsPage.Count > 3, "validate that cohort is editable on View apprentice details page");
            */
        }

        private void ValidateOnlyEditableApprenticeDetails()
        {
            EditApprenticePage editApprenticePage = new EditApprenticePage(_context);
            var EditApprenticeDetails = editApprenticePage.GetAllEditBoxes();

            Assert.IsTrue(EditApprenticeDetails.Count > 3, "validate that cohort is editable on View apprentice details page");
        }
    }
}
