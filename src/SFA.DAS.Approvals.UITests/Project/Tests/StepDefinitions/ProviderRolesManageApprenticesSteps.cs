using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRolesManageApprenticesSteps
    {
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly ProviderRoleApprenticeDataHelper _providerRoleApprenticeDataHelper;

        public ProviderRolesManageApprenticesSteps(ScenarioContext context)
        {
            _providerStepsHelper = new ProviderStepsHelper(context);
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _providerRoleApprenticeDataHelper = new ProviderRoleApprenticeDataHelper();            
        }

        [When(@"the user clicks on manage apprentice link from homepage or manage apprentices link")]
        public void WhenTheUserClicksOnManageApprenticeLinkFormHomepageOrManageApprenticesLink() => GoToProviderManageYourApprenticePage();

        [Then(@"the user can download csv file")]
        public void ThenTheUserCanDownloadCsvFile()
        {
            var linkDisplayed = _providerStepsHelper.VerifyDownloadAllLinkIsDisplayed();

            Assert.IsTrue(linkDisplayed, "Download all data");
        }

        [Then(@"the user can view details of the apprenticeship on apprenticeship details page")]
        public void ThenTheUserCanViewDetailsOfTheApprenticeshipOnApprenticeshipDetailsPage()
        {
            UpdateApprenticeName("LiveApprentice");

            SelectViewCurrentApprenticeDetails();
        }

        [Then(@"the user can view changes via view changes link in the banner")]
        public void ThenTheUserCanViewChangesViaViewChangesLinkInTheBanner()
        {
            UpdateApprenticeName("ChangesForReviewApprentice");
            
             SelectViewCurrentApprenticeDetails();
        }

        [Then(@"the user can view details of ILR mismatch via view details link in the ILR data mismatch banner")]
        public void ThenTheUserCanViewDetailsOfILRMismatchViaViewDetailsLinkInTheILRDataMismatchBanner()
        {
            UpdateApprenticeName("ILRDataMisMatchRequestDetails");
            
            SelectViewCurrentApprenticeDetails().ClickViewDetails();
        }

        [Then(@"the user can view details of ILR mismatch request restart via view details link in the ILR data mismatch banner")]
        public void ThenTheUserCanViewDetailsOfILRMismatchRequestRestartViaViewDetailsLinkInTheILRDataMismatchBanner()
        {
            UpdateApprenticeName("ILRDataMisMatchAskEmployerToFix");
            
            SelectViewCurrentApprenticeDetails().ClickViewDetails();                
        }


        [Then(@"the user can view review changes via review details link in the banner")]
        public void ThenTheUserCanViewReviewChangesViaReviewDetailsLinkInTheBanner()
        {
            UpdateApprenticeName("ChangesForReviewApprentice");
                      
            SelectViewCurrentApprenticeDetails().ClickReviewChanges();
        }

        [Then(@"the user can view view changes nonCoE page via view changes link in the banner")]
        public void ThenTheUserCanViewViewChangesNonCoEPageViaViewChangesLinkInTheBanner()
        {

            UpdateApprenticeName("ChangesPendingApprentice");
            
            SelectViewCurrentApprenticeDetails().ClickViewChanges();
        }

        [Then(@"the user can can access  apprentice request page via apprentice requests link on homepage or from apprentice requests menu bar")]
        public void ThenTheUserCanCanAccessApprenticeRequestPageViaApprenticeRequestsLinkOnHomepageOrFromApprenticeRequestsMenuBar()
        {
            _providerStepsHelper.NavigateToProviderHomePage().GoToApprenticeRequestsPage();
        }       

        [Then(@"the user cannot trigger change of employer journey using change link against the employer field")]
        public void ThenTheUserCannotTriggerChangeOfEmployerJourneyUsingChangeLinkAgainstTheEmployerField()
        {
            UpdateApprenticeName("StoppedApprentice");
            
            SelectViewCurrentApprenticeDetails().ClickChangeEmployerLinkGoesToAccessDenied().GoBackToTheServiceHomePage();            
        }

        [Then(@"the user cannot edit an existing apprenticeship record by selecting edit apprentice link under manage appreciates")]
        public void ThenTheUserCannotEditAnExistingApprenticeshipRecordBySelectingEditApprenticeLinkUnderManageAppreciates()
        {
            UpdateApprenticeName("LiveApprentice");

            SelectViewCurrentApprenticeDetails().ClickEditApprenticeDetailsLinkGoesToAccessDenied().GoBackToTheServiceHomePage();
        }

        [Then(@"the user cannot take action on details of ILR mismatch page by selecting any radio buttons on the page")]
        public void ThenTheUserCannotTakeActionOnDetailsOfILRMismatchPageBySelectingAnyRadioButtonsOnThePage()
        {
            UpdateApprenticeName("ILRDataMisMatchRequestDetails");
            
            SelectViewCurrentApprenticeDetails().ClickViewDetails()
             .ClickContinueNavigateToProviderAccessDeniedPage()
             .GoBackToTheServiceHomePage();
        }

        [Then(@"the user cannot take action on details of ILR mismatch request restart via view details link in the ILR data mismatch banner")]
        public void ThenTheUserCannotTakeActionOnDetailsOfILRMismatchRequestRestartViaViewDetailsLinkInTheILRDataMismatchBanner()
        {
            UpdateApprenticeName("ILRDataMisMatchRequestDetails");

            SelectViewCurrentApprenticeDetails().ClickViewDetails()
                 .ClickContinueNavigateToProviderAccessDeniedPage()
                 .GoBackToTheServiceHomePage();
        }

        [Then(@"the user cannot take action on review changes page")]
        public void ThenTheUserCannotTakeActionOnReviewChangesPage()
        {
            UpdateApprenticeName("ChangesForReviewApprentice");

            SelectViewCurrentApprenticeDetails().ClickReviewChanges()
            .ClickContinueNavigateToProviderAccessDeniedPage()
            .GoBackToTheServiceHomePage();
        }


        [Then(@"the user cannot take action on View changes on nonCoE page")]
        public void ThenTheUserCannotTakeActionOnViewChangesOnNonCoEPage()
        {
            UpdateApprenticeName("ChangesPendingApprentice");
            
            SelectViewCurrentApprenticeDetails().ClickViewChanges()
           .ClickContinueNavigateToProviderAccessDeniedPage()
           .GoBackToTheServiceHomePage();
        }

        [Then(@"the user cannot create a cohort")]
        public void ThenTheUserCannotCreateACohort()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .AddNewApprenticesGoesToAccessDenied()
                .GoBackToTheServiceHomePage();
        }

        [Then(@"the user can create a cohort")]
        public void ThenTheUserCanCreateACohort()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
            .GotoSelectJourneyPage()
            .SelectAddManually()
            .SelectOptionCreateNewCohort()
            .ChooseAnEmployer("Levy")
            .ConfirmEmployer();
        }

        [Then(@"the user can trigger change of employer journey using change link against the employer field")]
        public void ThenTheUserCanTriggerChangeOfEmployerJourneyUsingChangeLinkAgainstTheEmployerField()
        {
            UpdateApprenticeName("StoppedApprentice");

            SelectViewCurrentApprenticeDetails().ClickChangeEmployerLink().SelectChangeTheEmployer();   
                                         
        }

        [Then(@"the user can edit an existing apprenticeship record by selecting edit apprentice link under manage apprentices")]
        public void ThenTheUserCanEditAnExistingApprenticeshipRecordBySelectingEditApprenticeLinkUnderManageApprentices()
        {
            UpdateApprenticeName("LiveApprentice");

            SelectViewCurrentApprenticeDetails().ClickEditApprenticeDetailsLink();                                                  
        }

        [Then(@"the user can take action on details of ILR mismatch page by selecting any radio buttons on the page")]
        public void ThenTheUserCanTakeActionOnDetailsOfILRMismatchPageBySelectingAnyRadioButtonsOnThePage()
        {
            UpdateApprenticeName("ILRDataMisMatchRequestDetails");

            SelectViewCurrentApprenticeDetails().ClickViewIlrMismatchDetails().SelectILRDataMismatchOptions();
        }

        [Then(@"the user can take action on review changes page")]
        public void ThenTheUserCanTakeActionOnReviewChangesPage()
        {
            UpdateApprenticeName("ChangesForReviewApprentice");

            SelectViewCurrentApprenticeDetails().ClickReviewChanges().SelectReviewChangesOptions();
        }

        [Then(@"the user can take action on View changes on nonCoE page")]
        public void ThenTheUserCanTakeActionOnViewChangesOnNonCoEPage()
        {
            UpdateApprenticeName("ChangesPendingApprentice");

            SelectViewCurrentApprenticeDetails().ClickViewChanges().SelectViewChangesOptions();                                         
        }
        private void UpdateApprenticeName(string key)
        {
            var apprentice = _providerRoleApprenticeDataHelper.GetProviderRoleApprenticeTestData(key);

            _dataHelper.ApprenticeFirstname = apprentice.firstname;
            _dataHelper.ApprenticeLastname = apprentice.lastname;
        }

        private ProviderManageYourApprenticesPage GoToProviderManageYourApprenticePage() => _providerStepsHelper.NavigateToProviderHomePage().GoToProviderManageYourApprenticePage();

        private ProviderApprenticeDetailsPage SelectViewCurrentApprenticeDetails() => GoToProviderManageYourApprenticePage().SelectViewCurrentApprenticeDetails();
    }
}
