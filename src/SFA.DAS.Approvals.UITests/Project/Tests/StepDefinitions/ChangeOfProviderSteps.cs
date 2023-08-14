using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
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
        private readonly ProviderConfig _oldProviderLogin;
        private readonly ProviderLoginUser _newProviderLoginDetails;
        private readonly ProviderLoginUser _oldProviderLoginDetails;
        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper;
        private const int expectedEditableFields = 12;

        public ChangeOfProviderSteps(ScenarioContext context)
        {
            _context = context;
            _changeOfPartyConfig = context.GetChangeOfPartyConfig<ChangeOfPartyConfig>();
            _oldProviderLogin = context.GetProviderConfig<ProviderConfig>();
            _newProviderLoginDetails = new ProviderLoginUser { UserId = _changeOfPartyConfig.UserId, Password = _changeOfPartyConfig.Password, Ukprn = _changeOfPartyConfig.Ukprn };
            _oldProviderLoginDetails = new ProviderLoginUser { UserId = _oldProviderLogin.UserId, Password = _oldProviderLogin.Password, Ukprn = _oldProviderLogin.Ukprn };
            _apprenticeHomePageStepsHelper = new ApprenticeHomePageStepsHelper(context);
            new RestartWebDriverHelper(context).RestartWebDriver(UrlConfig.Provider_BaseUrl, "Approvals");
        }
 
        [When(@"new provider approves the cohort")]
        public void WhenNewProviderApprovesTheCohort()
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_newProviderLoginDetails, false);

            new ProviderApprenticeRequestsPage(_context, true)
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails()
                .IsAddApprenticeLinkDisplayed()
                .IsBulkUpLoadLinkDisplayed()
                .SelectEditApprentice()
                .ValidateEditableTextBoxes(expectedEditableFields)
                .EditCopApprenticeDetails()
                .SubmitApprove();
        }

        [When(@"new provider approves the employer led change of provider cohort")]
        public void WhenNewProviderApprovesTheEmployerLedChangeOfProviderCohort()
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_newProviderLoginDetails, false);

            new ProviderApprenticeRequestsPage(_context, true)
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails()
                .SelectEditApprentice()
                .SelectSaveAndUpdateRPLAsNo()
                .SubmitApprove();
        }

        [When(@"employer approves the cohort")]
        public void WhenEmployerApprovesTheCohort()
        {
            new EmployerStepsHelper(_context)
                .EmployerReviewCohort()
                .IsAddApprenticeLinkDisplayed()
                .SelectEditApprentice()
                .ValidateTrainingCourseNotEditable()
                .SaveEditedTrainingDetails()
                .EmployerDoesSecondApproval();
        }

        [When(@"Levy employer approves the cohorts")]
        public void WhenLevyEmployerApprovesTheCohorts()
        {
            new EmployerStepsHelper(_context)
                .EmployerReviewCohort()
                .EmployerDoesSecondApproval();
        }

        [Then(@"a new live apprenticeship record is created with new Provider")]
        public void ThenANewLiveApprenticeshipRecordIsCreatedWithNewProvider()
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_newProviderLoginDetails, true);

            SelectViewCurrentApprenticeDetails();
        }

        [Then(@"Employer can only edit start date, end date and Price on the new record")]
        public void ThenEmployerCanOnlyEditStartDateEndDateAndPriceOnTheNewRecord()
        {
            var editApprenticePage = _apprenticeHomePageStepsHelper.GoToManageYourApprenticesPage()
                .SelectApprentices("LIVE")
                .ClickEditApprenticeDetailsLink();

            ValidateOnlyEditableApprenticeDetails(editApprenticePage);
        }

        [When(@"new Provider sends the cohort back to employer to review")]
        public void WhenNewProviderSendsTheCohortBackToEmployerToReview()
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_newProviderLoginDetails, true);

            new ProviderApprenticeRequestsPage(_context, true)
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails()
                .SelectEditApprentice()
                .ValidateTrainingCourseNotEditable()
                .EditCopApprenticeDetails()
                .SubmitSendToEmployerToReview();
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
        public void ThenEmployerCanChangeProviderAgain() => new EmployerStepsHelper(_context).StartChangeofNewTrainingProvider();

        [When(@"new provider approves the changes")]
        public void WhenNewProviderApprovesTheChanges()
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_newProviderLoginDetails, true);

            new ProviderApprenticeRequestsPage(_context, true)
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails()
                .IsAddApprenticeLinkDisplayed()
                .IsBulkUpLoadLinkDisplayed()
                .SelectEditApprentice()
                .ValidateEditableTextBoxes(expectedEditableFields)
                .EditCopApprenticeDetails()
                .SubmitApprove();
        }

        [Then(@"Prevent employer from requesting CoP on the original apprenticeship")]
        public void ThenPreventEmployerFromRequestingCoPOnTheOriginalApprenticeship()
        {
            bool IsChangeOfProviderLinkDisplayed 
                = _apprenticeHomePageStepsHelper.GoToManageYourApprenticesPage()
                .SelectApprentices("STOPPED")
                .IsChangeOfProviderLinkDisplayed();

            Assert.IsFalse(IsChangeOfProviderLinkDisplayed, "Validate that CoP link on the original apprentice record has been removed");
        }

        [Then(@"a banner is displayed for employer with a link to ""(.*)"" cohort")]
        public void ThenABannerIsDisplayedForEmployerWithALinkToCohort(string status)
        {
            bool editable = status == "editable";

            var employerApprenticeDetailsPage = new EmployerStepsHelper(_context).ViewCurrentApprenticeDetails(true);

            if (editable)
                ValidateBannerWithLinkToEditableCohort(employerApprenticeDetailsPage);
            else
                ValidateBannerWithLinkToNonEditableCohort(employerApprenticeDetailsPage);
        }

        public void ValidatePreviousProviderShouldNotBeAbleToStartCoEOnTheOldRecordAfterSuccessfulCoP()
        {                  
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(_oldProviderLoginDetails, false);
              
            Assert.IsFalse(SelectViewCurrentApprenticeDetails().IsCoELinkDisplayed(), "Validate that CoE link is not available for the old provider after successful CoP");
        }

        private ProviderApprenticeDetailsPage SelectViewCurrentApprenticeDetails() => new ProviderManageYourApprenticesPage(_context, true).SelectViewCurrentApprenticeDetails();

        private void ValidateBannerWithLinkToNonEditableCohort(ApprenticeDetailsPage apprenticeDetailsPage)
        {
            string expectedText = "You have made a change of provider request. It’s now with the new training provider for review.";
            string actualText = apprenticeDetailsPage.GetAlertBanner();

            Assert.AreEqual(expectedText, actualText, "Text in the changes pending banner");


            var EditBoxOnApprenticeDetailsPage = apprenticeDetailsPage
                                                    .ClickViewChangesLink()
                                                    .ClickProviderReviewingTheRequestLink()
                                                    .ClickViewApprenticeLink()
                                                    .GetAllEditBoxes();


            Assert.IsTrue(EditBoxOnApprenticeDetailsPage.Count < 1, "validate there are no edit or input box available on View apprentice details page");            
        }

        private void ValidateBannerWithLinkToEditableCohort(ApprenticeDetailsPage apprenticeDetailsPage)
        {
            string expectedText = "The new training provider has reviewed the change of provider request. You need to review the new details. View changes";
            string actualText = apprenticeDetailsPage.GetAlertBanner();

            Assert.AreEqual(expectedText, actualText, "Text in the changes pending banner");

            var editApprenticePage = apprenticeDetailsPage
                                                    .ClickReviewChangesLink()
                                                    .ClickReviewTheApprenticeDetailsToUpdateLink()
                                                    .SelectEditApprentice();

            ValidateOnlyEditableApprenticeDetails(editApprenticePage);     
        }

        private void ValidateOnlyEditableApprenticeDetails(EditApprenticeDetailsPage editApprenticePage)
        {
            Assert.IsTrue(editApprenticePage.GetAllEditableBoxes().Count == expectedEditableFields, "validate that cohort is editable on View apprentice details page");
        }
    }
}
