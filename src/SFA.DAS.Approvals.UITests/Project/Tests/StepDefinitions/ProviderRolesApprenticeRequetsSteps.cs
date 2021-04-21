using System;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Registration.UITests.Project.Helpers;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRolesApprenticeRequetsSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ApprenticeDataHelper _dataHelper;
        private readonly ProviderRoleApprenticeDataHelper _providerRoleApprenticeDataHelper;

        public ProviderRolesApprenticeRequetsSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _providerRoleApprenticeDataHelper = new ProviderRoleApprenticeDataHelper();
        }


        //[When(@"the user clicks on manage apprentice link from homepage or manage apprentices link")]
        //public void WhenTheUserClicksOnManageApprenticeLinkFormHomepageOrManageApprenticesLink()
        //{
        //    _providerStepsHelper.NavigateToProviderHomePage()
        //                    .GoToProviderManageYourApprenticePage();
        //}

        [When(@"the user clicks on apprentice request link from homepage or apprentice request link")]
        public void WhenTheUserClicksOnApprenticeRequestLinkFromHomepageOrApprenticeRequestLink()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                               .GoToYourCohorts();
        }

        [Then(@"the user can view apprentice requests page")]
        public void ThenTheUserCanViewApprenticeRequestsPage()
        {
            //
        }



       /* [Then(@"the user can view manage your apprecitces page")]
        public void ThenTheUserCanViewManageYourApprecitcesPage()
        {
            //_providerStepsHelper.
        }

        [Then(@"the user can download csv file")]
        public void ThenTheUserCanDownloadCsvFile()
        {
            var linkDisplayed = _providerStepsHelper.VerifyDownloadAllLinkIsDisplayed();

            Assert.IsTrue(linkDisplayed, "Download all data");
        }

        [Then(@"the user can view details of the apprenticeship on apprenticeship details page")]
        public void ThenTheUserCanViewDetailsOfTheApprenticeshipOnApprenticeshipDetailsPage()
        {
            var apprentice = _providerRoleApprenticeDataHelper.GetProviderRoleApprenticeTestData("LiveApprentice");
            _dataHelper.ApprenticeFirstname = apprentice.firstname;// "David";
            _dataHelper.ApprenticeLastname = apprentice.lastname; // "Clarke";

            _providerStepsHelper.NavigateToProviderHomePage()
                            .GoToProviderManageYourApprenticePage()
                            .SelectViewCurrentApprenticeDetails();
        }


        [Then(@"the user can view changes via view changes link in the banner")]
        public void ThenTheUserCanViewChangesViaViewChangesLinkInTheBanner()
        {
            var apprentice = _providerRoleApprenticeDataHelper.GetProviderRoleApprenticeTestData("ChangesForReviewApprentice");
            _dataHelper.ApprenticeFirstname = apprentice.firstname;// "User45";
            _dataHelper.ApprenticeLastname = apprentice.lastname; // "Test";

            ProviderApprenticeDetailsPage providerApprenticeDetailsPage = _providerStepsHelper.NavigateToProviderHomePage()
                                                                         .GoToProviderManageYourApprenticePage()
                                                                         .SelectViewCurrentApprenticeDetails();

        }

        [Then(@"the user can view details of ILR mismatch via view details link in the ILR data mismatch banner")]
        public void ThenTheUserCanViewDetailsOfILRMismatchViaViewDetailsLinkInTheILRDataMismatchBanner()
        {
            var apprentice = _providerRoleApprenticeDataHelper.GetProviderRoleApprenticeTestData("ILRDataMismatchApprentice");
            _dataHelper.ApprenticeFirstname = apprentice.firstname;// "F_HJNgDpRVwT";
            _dataHelper.ApprenticeLastname = apprentice.lastname; // "L_vicyMjKphr";

            ProviderApprenticeDetailsPage providerApprenticeDetailsPage = _providerStepsHelper.NavigateToProviderHomePage()
                                                                          .GoToProviderManageYourApprenticePage()
                                                                          .SelectViewCurrentApprenticeDetails();
        }

        [Then(@"the user can view details of ILR mismatch request restart via view details link in the ILR data mismatch banner")]
        public void ThenTheUserCanViewDetailsOfILRMismatchRequestRestartViaViewDetailsLinkInTheILRDataMismatchBanner()
        {

            //TODO : need new data
            _dataHelper.ApprenticeFirstname = "F_HJNgDpRVwT";
            _dataHelper.ApprenticeLastname = "L_vicyMjKphr";

            ProviderApprenticeDetailsPage providerApprenticeDetailsPage = _providerStepsHelper.NavigateToProviderHomePage()
                                                                          .GoToProviderManageYourApprenticePage()
                                                                          .SelectViewCurrentApprenticeDetails();

            providerApprenticeDetailsPage.ClickViewDetails();
        }



        [Then(@"the user can view review changes via review details link in the banner")]
        public void ThenTheUserCanViewReviewChangesViaReviewDetailsLinkInTheBanner()
        {
            var apprentice = _providerRoleApprenticeDataHelper.GetProviderRoleApprenticeTestData("ChangesPendingApprentice");
            _dataHelper.ApprenticeFirstname = apprentice.firstname; //"User27";
            _dataHelper.ApprenticeLastname = apprentice.lastname; //"Test";        

            ProviderApprenticeDetailsPage providerApprenticeDetailsPage = _providerStepsHelper.NavigateToProviderHomePage()
                                                                          .GoToProviderManageYourApprenticePage()
                                                                          .SelectViewCurrentApprenticeDetails();

            providerApprenticeDetailsPage.ClickReviewChanges();

        }

        [Then(@"the user can view view changes nonCoE page via view changes link in the banner")]
        public void ThenTheUserCanViewViewChangesNonCoEPageViaViewChangesLinkInTheBanner()
        {

            var apprentice = _providerRoleApprenticeDataHelper.GetProviderRoleApprenticeTestData("ChangesForReviewApprentice");
            _dataHelper.ApprenticeFirstname = apprentice.firstname;// "User45";
            _dataHelper.ApprenticeLastname = apprentice.lastname; // "Test";

            ProviderApprenticeDetailsPage providerApprenticeDetailsPage = _providerStepsHelper.NavigateToProviderHomePage()
                                                                         .GoToProviderManageYourApprenticePage()
                                                                         .SelectViewCurrentApprenticeDetails();

            providerApprenticeDetailsPage.ClickViewChanges();
        }


        [Then(@"the user can can access  apprentice request page via apprentice requests link on homepage or from apprentice requests menu bar")]
        public void ThenTheUserCanCanAccessApprenticeRequestPageViaApprenticeRequestsLinkOnHomepageOrFromApprenticeRequestsMenuBar()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                                .GoToYourCohorts();
        }*/

        [Then(@"the user can view apprentice details ready for review page when user clicks on with employer box")]
        public void ThenTheUserCanViewApprenticeDetailsReadyForReviewPageWhenUserClicksOnWithEmployerBox()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsWithEmployers()
                                                        .SelectViewCurrentCohortDetails();
        }

        [Then(@"the user can view apprentice details ready for review page when user clicks on drafts box")]
        public void ThenTheUserCanViewApprenticeDetailsReadyForReviewPageWhenUserClicksOnDraftsBox()
        {
            new ProviderYourCohortsPage(_context, true).GoToDraftCohorts()
                                                        .SelectViewCurrentCohortDetails();
        }

        [Then(@"the user can view apprentice details ready for review page when user clicks on with transfer sending employers box")]
        public void ThenTheUserCanViewApprenticeDetailsReadyForReviewPageWhenUserClicksOnWithTransferSendingEmployersBox()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsWithTransferSendingEmployers()
                                                        .SelectViewCurrentCohortDetails();
        }

        [Then(@"the user can view view your cohort page by clicking view link on view your cohort page selecting the employers box")]
        public void ThenTheUserCanViewViewYourCohortPageByClickingViewLinkOnViewYourCohortPageSelectingTheEmployersBox()
        {
            //TODO : need to check added now
            new ProviderYourCohortsPage(_context, true).GoToCohortsWithTransferSendingEmployers()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectViewApprentice();
        }

        [Then(@"the user can view view your cohort page by clicking view link on view your cohort page selecting with transfer sending employers box")]
        public void ThenTheUserCanViewViewYourCohortPageByClickingViewLinkOnViewYourCohortPageSelectingWithTransferSendingEmployersBox()
        {
            //TODO : need to check added now
            new ProviderYourCohortsPage(_context, true).GoToCohortsWithTransferSendingEmployers()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectViewApprentice();
        }


        [Then(@"the user can view review your cohort page when user clicks on details link from apprentice details ready for review page selecting with employers box")]
        public void ThenTheUserCanViewReviewYourCohortPageWhenUserClicksOnDetailsLinkFromApprenticeDetailsReadyForReviewPageSelectingWithEmployersBox()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails();
        }

        [Then(@"the user can view review your cohort page when user clicks on details link from apprentice details ready for review page selecting drafts box")]
        public void ThenTheUserCanViewReviewYourCohortPageWhenUserClicksOnDetailsLinkFromApprenticeDetailsReadyForReviewPageSelectingDraftsBox()
        {
            //TODO : check this
            new ProviderYourCohortsPage(_context, true).GoToDraftCohorts()
                .SelectViewCurrentCohortDetails();
        }

        /*[Then(@"the user cannot trigger change of employer journey using change link against the employer field")]
        public void ThenTheUserCannotTriggerChangeOfEmployerJourneyUsingChangeLinkAgainstTheEmployerField()
        {
            var apprentice = _providerRoleApprenticeDataHelper.GetProviderRoleApprenticeTestData("StoppedApprentice");
            _dataHelper.ApprenticeFirstname = apprentice.firstname;// "F_GEWeMBRBGL";
            _dataHelper.ApprenticeLastname = apprentice.lastname; // "L_GLwVYpKCmU";

            ProviderApprenticeDetailsPage providerApprenticeDetailsPage = _providerStepsHelper.NavigateToProviderHomePage()
                                                                         .GoToProviderManageYourApprenticePage()
                                                                         .SelectViewCurrentApprenticeDetails();

            providerApprenticeDetailsPage.ClickChangeEmployerLinkGoesToAccessDenied()
                .GoBackToTheServiceHomePage();

        }

        [Then(@"the user cannot edit an existing apprenticeship record by selecting edit apprentice link under manage appreciates")]
        public void ThenTheUserCannotEditAnExistingApprenticeshipRecordBySelectingEditApprenticeLinkUnderManageAppreciates()
        {
            var apprentice = _providerRoleApprenticeDataHelper.GetProviderRoleApprenticeTestData("LiveApprentice");
            _dataHelper.ApprenticeFirstname = apprentice.firstname;// "David";
            _dataHelper.ApprenticeLastname = apprentice.lastname; // "Clarke";

            ProviderApprenticeDetailsPage providerApprenticeDetailsPage = _providerStepsHelper.NavigateToProviderHomePage()
                                                                         .GoToProviderManageYourApprenticePage()
                                                                         .SelectViewCurrentApprenticeDetails();

            providerApprenticeDetailsPage.ClickEditApprenticeDetailsLinkGoesToAccessDenied()
                .GoBackToTheServiceHomePage();
        }

        [Then(@"the user cannot take action on details of ILR mismatch page by selecting any radio buttons on the page")]
        public void ThenTheUserCannotTakeActionOnDetailsOfILRMismatchPageBySelectingAnyRadioButtonsOnThePage()
        {
            var apprentice = _providerRoleApprenticeDataHelper.GetProviderRoleApprenticeTestData("ILRDataMismatchApprentice");
            _dataHelper.ApprenticeFirstname = apprentice.firstname;// "F_HJNgDpRVwT";
            _dataHelper.ApprenticeLastname = apprentice.lastname; // "L_vicyMjKphr";

            ProviderApprenticeDetailsPage providerApprenticeDetailsPage = _providerStepsHelper.NavigateToProviderHomePage()
                                                                          .GoToProviderManageYourApprenticePage()
                                                                          .SelectViewCurrentApprenticeDetails();

            providerApprenticeDetailsPage.ClickViewDetails()
            .ClickContinueNavigateToProviderAccessDeniedPage()
            .GoBackToTheServiceHomePage();
        }


        [Then(@"the user cannot take action on details of ILR mismatch request restart via view details link in the ILR data mismatch banner")]
        public void ThenTheUserCannotTakeActionOnDetailsOfILRMismatchRequestRestartViaViewDetailsLinkInTheILRDataMismatchBanner()
        {
            var apprentice = _providerRoleApprenticeDataHelper.GetProviderRoleApprenticeTestData("ILRDataMismatchApprentice");
            _dataHelper.ApprenticeFirstname = apprentice.firstname;// "F_HJNgDpRVwT";
            _dataHelper.ApprenticeLastname = apprentice.lastname; // "L_vicyMjKphr";

            ProviderApprenticeDetailsPage providerApprenticeDetailsPage = _providerStepsHelper.NavigateToProviderHomePage()
                                                                          .GoToProviderManageYourApprenticePage()
                                                                          .SelectViewCurrentApprenticeDetails();

            providerApprenticeDetailsPage.ClickViewDetails()
                .ClickContinueNavigateToProviderAccessDeniedPage()
                .GoBackToTheServiceHomePage();
        }

        [Then(@"the user cannot take action on review changes page")]
        public void ThenTheUserCannotTakeActionOnReviewChangesPage()
        {
            var apprentice = _providerRoleApprenticeDataHelper.GetProviderRoleApprenticeTestData("ChangesPendingApprentice");
            _dataHelper.ApprenticeFirstname = apprentice.firstname; //"User27";
            _dataHelper.ApprenticeLastname = apprentice.lastname; //"Test";  

            ProviderApprenticeDetailsPage providerApprenticeDetailsPage = _providerStepsHelper.NavigateToProviderHomePage()
                                                                          .GoToProviderManageYourApprenticePage()
                                                                          .SelectViewCurrentApprenticeDetails();

            providerApprenticeDetailsPage.ClickReviewChanges()
            .ClickContinueNavigateToProviderAccessDeniedPage()
            .GoBackToTheServiceHomePage();
        }


        [Then(@"the user cannot take action on View changes on nonCoE page")]
        public void ThenTheUserCannotTakeActionOnViewChangesOnNonCoEPage()
        {
            var apprentice = _providerRoleApprenticeDataHelper.GetProviderRoleApprenticeTestData("ChangesForReviewApprentice");
            _dataHelper.ApprenticeFirstname = apprentice.firstname;// "User45";
            _dataHelper.ApprenticeLastname = apprentice.lastname; // "Test";

            ProviderApprenticeDetailsPage providerApprenticeDetailsPage = _providerStepsHelper.NavigateToProviderHomePage()
                                                                         .GoToProviderManageYourApprenticePage()
                                                                         .SelectViewCurrentApprenticeDetails();

            providerApprenticeDetailsPage.ClickViewChanges()
           .ClickContinueNavigateToProviderAccessDeniedPage()
           .GoBackToTheServiceHomePage();
        }


        [Then(@"the user cannot create a cohort")]
        public void ThenTheUserCannotCreateACohort()
        {
            _providerStepsHelper.NavigateToProviderHomePage().CreateCohortGoesToAccessDenied().GoBackToTheServiceHomePage();
        }

        [Then(@"the user cannot edit an apprentice in a cohort")]
        public void ThenTheUserCannotEditAnApprenticeInACohort()
        {

            new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectEditApprenticeGoesToAccessDenied() // TODO : this is not working
                                                        .GoBackToTheServiceHomePage();
        }*/

        [Then(@"the user cannot bulk upload apprentices via csv file")]
        public void ThenTheUserCannotBulkUploadApprenticesViaCsvFile()
        {
            _providerStepsHelper.NavigateToProviderHomePage().GoToYourCohorts();

            new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectBulkUploadApprenticesGoesToAccessDenied()
                                                        .GoBackToTheServiceHomePage();
        }


        [Then(@"the user cannot send a cohort to employer")]
        public void ThenTheUserCannotSendACohortToEmployer()
        {
            new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectAddAnApprenticeGoesToAccessDenied()
                                                        .GoBackToTheServiceHomePage();
        }

        [Then(@"the user cannot delete a cohort")]
        public void ThenTheUserCannotDeleteACohort()
        {

            _providerStepsHelper.NavigateToProviderHomePage().GoToYourCohorts();

            new ProviderYourCohortsPage(_context, true).GoToCohortsToReviewPage()
                                                        .SelectViewCurrentCohortDetails()
                                                        .SelectDeleteCohortGoesToAccessDenied()
                                                        .GoBackToTheServiceHomePage();
        }
    }
}
