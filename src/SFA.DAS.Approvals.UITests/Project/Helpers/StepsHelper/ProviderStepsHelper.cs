using System;
using OpenQA.Selenium;
using System.Linq;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider;
using NUnit.Framework;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;
        private readonly ReviewYourCohortStepsHelper _reviewYourCohortStepsHelper;

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
            _reviewYourCohortStepsHelper = new ReviewYourCohortStepsHelper(_context.Get<AssertHelper>());
        }

        internal ApprovalsProviderHomePage GoToProviderHomePage(ProviderLoginUser login, bool newTab = true)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(login, newTab);
            return new ApprovalsProviderHomePage(_context);
        }

        public ApprovalsProviderHomePage NavigateToProviderHomePage() => new ApprovalsProviderHomePage(_context, true);

        public ApprovalsProviderHomePage GoToProviderHomePage(bool newTab = true)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(newTab);
            return new ApprovalsProviderHomePage(_context);
        }

        public void ApproveChangesAndSubmit() => GoToProviderHomePage().GoToProviderManageYourApprenticePage().SelectViewCurrentApprenticeDetails().ClickReviewChanges().SelectApproveChangesAndSubmit();


        public ProviderMakingChangesPage ProviderMakeReservation(ProviderLoginUser login = null, bool newTab = true)
        {
            var homePage = login != null
                ? GoToProviderHomePage(login, newTab)
                : NavigateToProviderHomePage();

            return homePage
                   .GoToProviderGetFunding()
                   .StartReservedFunding()
                   .ChooseAnEmployerNonLevy()
                   .ConfirmNonLevyEmployer()
                   .AddTrainingCourseAndDate()
                   .ConfirmReserveFunding()
                   .VerifySucessMessage();
        }

        public ProviderAddApprenticeDetailsPage ProviderMakeReservationThenGotoAddApprenticeDetails(ProviderLoginUser login = null)
        {
            return ProviderMakeReservation(login, false)
                .GoToAddApprenticeDetailsPage();
        }

        public ApprovalsProviderHomePage ProviderMakeReservationThenGotoHomePage(ProviderLoginUser login = null)
        {
            return ProviderMakeReservation(login, false)
                .GoToHomePage();
        }

        public ApprovalsProviderHomePage ProviderDeleteReservationThenGotoHomePage(ProviderLoginUser login = null)
        {
            var homePage = login != null
                   ? GoToProviderHomePage(login)
                   : NavigateToProviderHomePage();

            return homePage
                .GoToManageYourFunding()
                .DeleteTheReservedFunding()
                .YesDeleteThisReservation()
                .GoToHomePage();
        }

        public void AddApprenticeAndSendToEmployerForApproval(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = AddApprentice(numberOfApprentices).SubmitApprove();

            //providerReviewYourCohortPage
                //.SelectSaveAndContinue()
                //.SubmitApproveAndSendToEmployerForApproval();
                //.SendInstructionsToEmployerForAnApprovedCohort();
                //.SubmitApprove();
        }

        public void BulkUploadApprenticeDetails(int numberOfApprentices)
        {
            AddApprentice(numberOfApprentices)
                //.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval();
                //.SendInstructionsToEmployerForAnApprovedCohort();
        }

        public ProviderYourCohortsPage AddApprenticeAndSavesWithoutSendingEmployerForApproval(int numberOfApprentices)
        {
            return AddApprentice(numberOfApprentices)
                 //.SelectSaveAndContinue()
                 .SubmitSaveButDontSendToEmployer();
        }

        public ProviderApproveApprenticeDetailsPage AddApprentice(ProviderAddApprenticeDetailsPage _providerAddApprenticeDetailsPage, int numberOfApprentices)
        {
            var providerApproveApprenticeDetailsPage = _providerAddApprenticeDetailsPage.SubmitValidApprenticeDetails();

            for (int i = 1; i < numberOfApprentices; i++)
            {
                providerApproveApprenticeDetailsPage = providerApproveApprenticeDetailsPage
                    .SelectAddAnApprenticeUsingReservation()
                    .CreateANewReservation()
                    .AddTrainingCourseAndDate()
                    .ConfirmReserveFunding()
                    .VerifySucessMessage()
                    .GoToAddApprenticeDetailsPage()
                    .SubmitValidApprenticeDetails();
            }

            return SetApprenticeDetails(providerApproveApprenticeDetailsPage, numberOfApprentices);
        }

        public ProviderApproveApprenticeDetailsPage AddApprentice(int numberOfApprentices)
        {
            var providerApproveApprenticeDetailsPage = CurrentCohortDetails();

            for (int i = 0; i < numberOfApprentices; i++)
            {
                providerApproveApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectAddAnApprentice()
                        .SubmitValidApprenticeDetails();
            }

            return SetApprenticeDetails(providerApproveApprenticeDetailsPage, numberOfApprentices);
        }

        public ProviderCohortApprovedPage AddApprenticeViaBulkUpload(int numberOfApprentices)
        {
            return CurrentCohortDetails()
                .SelectBulkUploadApprentices()
                .UploadFileAndConfirmSuccessful(numberOfApprentices)
                //.SelectSaveAndContinue()
                .SubmitApprove();
                //.SubmitApproveAndSendToEmployerForApproval();
                //.SendInstructionsToEmployerForAnApprovedCohort();
        }

        public ProviderApproveApprenticeDetailsPage CurrentCohortDetails()
        {
            GoToProviderHomePage();

            return new ProviderYourCohortsPage(_context, true)
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails();
        }

        public ProviderApproveApprenticeDetailsPage EditApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, bool shouldCheckCoursesAreStandards = false)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                var ulnFields = providerApproveApprenticeDetailsPage.ApprenticeUlns().Reverse<IWebElement>();
                int j = ulnFields.Count() - 1;

                foreach (IWebElement uln in ulnFields)
                {
                    if (uln.Text.Equals("-"))
                    {
                        var providerEditApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(j);

                        if (shouldCheckCoursesAreStandards)
                        {
                            providerEditApprenticeDetailsPage.ConfirmOnlyStandardCoursesAreSelectable();
                        }

                        providerEditApprenticeDetailsPage.EnterUlnAndSave();
                        break;
                    }
                    j--;
                }
            }

            return providerApproveApprenticeDetailsPage;
        }

        public ProviderApproveApprenticeDetailsPage EditApprentice(bool shouldCheckCoursesAreStandards = false)
        {
            return EditApprentice(CurrentCohortDetails(), shouldCheckCoursesAreStandards);
        }

        public ProviderApproveApprenticeDetailsPage EditAllDetailsOfApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
                providerApproveApprenticeDetailsPage = providerApproveApprenticeDetailsPage.SelectEditApprentice(i)
                                         .EditAllApprenticeDetails();

            return providerApproveApprenticeDetailsPage;
        }

        public ProviderApproveApprenticeDetailsPage DeleteApprentice(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                string flashMessage = providerApproveApprenticeDetailsPage
                                          .SelectEditApprentice(0)
                                          .DeleteApprentice()
                                          .ConfirmDeleteAndSubmit()
                                          .GetFlashMessage();

                Assert.IsTrue(flashMessage == "Apprentice record deleted", "validate 'Apprentice record deleted' flash message is displayed");
            }

            return providerApproveApprenticeDetailsPage;
        }

        public void DeleteCohort(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage)
        {
            providerApproveApprenticeDetailsPage.SelectDeleteCohort()
                .ConfirmDeleteAndSubmit();
        }

        public void Approve() => EditApprentice().SubmitApprove();
        
        public void ViewApprentices()
        {
            ProviderViewYourCohortPage _providerViewYourCohortPage = new ProviderViewYourCohortPage(_context);
            int totalApprentices = _providerViewYourCohortPage.TotalNoOfApprentices();
            for (int i = 0; i < totalApprentices; i++)
            {
                _providerViewYourCohortPage.SelectViewApprentice(i)
                    .SelectReturnToCohortView();
            }
        }

        private ProviderApproveApprenticeDetailsPage SetApprenticeDetails(ProviderApproveApprenticeDetailsPage providerApproveApprenticeDetailsPage, int numberOfApprentices)
        {
            _objectContext.SetNoOfApprentices(_reviewYourCohortStepsHelper.NoOfApprentice(providerApproveApprenticeDetailsPage, numberOfApprentices));
            _objectContext.SetApprenticeTotalCost(_reviewYourCohortStepsHelper.ApprenticeTotalCost(providerApproveApprenticeDetailsPage));

            return providerApproveApprenticeDetailsPage;
        }

        public ProviderManageYourApprenticesPage FilterAndPaginate(string filterselection)
        {

            return new ProviderManageYourApprenticesPage(_context).FilterPagination(filterselection);
        }

        public bool VerifyDownloadAllLinkIsDisplayed()
        {
            return new ProviderManageYourApprenticesPage(_context).DownloadAllDataLinkIsDisplayed();
        }

        public void DynamicHomePageProviderApproval()
        {
            ApprovalsProviderHomePage _approvalsProviderHomePage = new ApprovalsProviderHomePage(_context);
            _approvalsProviderHomePage.GoToYourCohorts()
            .GoToCohortsToReviewPage()
             .SelectViewCurrentCohortDetails()
             .SelectEditApprentice(0)
             .EnterUlnAndSave()
             //.SelectSaveAndContinue()
             .SubmitApproveAndSendToEmployerForApproval();
             //.SendInstructionsToEmployerForAnApprovedCohort();
        }

        public ChangeOfEmployerRequestedPage StartChangeOfEmployerJourney()
        {
            return GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ClickChangeEmployerLink()
                .SelectChangeTheEmployer()
                .SelectNewEmployer()
                .ConfirmNewEmployer()
                .EndNewStartDateAndContinue()
                .EnterNewEndDateAndContinue()
                .EnterNewPriceAndContinue()
                .VerifyAndSubmitChangeOfEmployerRequest()
                .VerifyChangeOfEmployerHasBeenRequested();
        }
    }
}