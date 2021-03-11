using System;
using OpenQA.Selenium;
using System.Linq;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.Login.Service.Helpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;
        private readonly ReviewYourCohortStepsHelper _reviewYourCohortStepsHelper;

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
            _reviewYourCohortStepsHelper = new ReviewYourCohortStepsHelper(_context.Get<AssertHelper>());
            _tabHelper = _context.Get<TabHelper>();
        }

        internal ApprovalsProviderHomePage GoToProviderHomePage(ProviderLoginUser login)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(login, true);

            return new ApprovalsProviderHomePage(_context);
        }

        public ApprovalsProviderHomePage NavigateToProviderHomePage() => new ApprovalsProviderHomePage(_context, true);

        public ApprovalsProviderHomePage GoToProviderHomePage(bool login = true)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(login);
            return new ApprovalsProviderHomePage(_context);
        }
        public ProviderAddApprenticeDetailsPage ProviderMakeReservation(ProviderLoginUser login)
        {
            return GoToProviderHomePage(login)
                   .GoToProviderGetFunding()
                   .StartReservedFunding()
                   .ChooseAnEmployerNonLevy()
                   .ConfirmNonLevyEmployer()
                   .AddTrainingCourseAndDate()
                   .ConfirmReserveFunding()
                   .VerifySucessMessage()
                   .GoToAddApprenticeDetailsPage();
        }

        public void MakeReservation()
        {
            ApprovalsProviderHomePage approvalsProviderHomePage = new ApprovalsProviderHomePage(_context);
            approvalsProviderHomePage.GoToProviderGetFunding().StartReservedFunding()
                   .ChooseAnEmployerNonLevy()
                   .ConfirmNonLevyEmployer()
                   .AddTrainingCourseAndDate()
                   .ConfirmReserveFunding()
                   .VerifySucessMessage()
                   .GoToHomePage();            
        }

        public void AddApprenticeAndSendToEmployerForApproval(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = AddApprentice(numberOfApprentices);

            providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

        public void BulkUploadApprenticeDetails(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = AddApprentice(numberOfApprentices);

            providerReviewYourCohortPage.SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

        public ProviderYourCohortsPage AddApprenticeAndSavesWithoutSendingEmployerForApproval(int numberOfApprentices)
        {
            return AddApprentice(numberOfApprentices)
                 .SelectSaveAndContinue()
                 .SubmitSaveButDontSendToEmployer();
        }

        public ProviderReviewYourCohortPage AddApprentice(ProviderAddApprenticeDetailsPage _providerAddApprenticeDetailsPage, int numberOfApprentices)
        {
            //var providerAddApprenticeDetailsPage = providerHomePage.GoToManageYourFunding().AddApprenticeWithReservedFunding();

            var providerReviewYourCohortPage = _providerAddApprenticeDetailsPage.SubmitValidApprenticeDetails();

            for (int i = 1; i < numberOfApprentices; i++)
            {
                providerReviewYourCohortPage = providerReviewYourCohortPage
                    .SelectAddAnApprenticeUsingReservation()
                    .CreateANewReservation()
                    .AddTrainingCourseAndDate()
                    .ConfirmReserveFunding()
                    .VerifySucessMessage()
                    .GoToAddApprenticeDetailsPage()
                    .SubmitValidApprenticeDetails();
            }

            return SetApprenticeDetails(providerReviewYourCohortPage, numberOfApprentices);
        }

        public ProviderReviewYourCohortPage AddApprentice(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = CurrentCohortDetails();

            for (int i = 0; i < numberOfApprentices; i++)
            {
                providerReviewYourCohortPage = providerReviewYourCohortPage.SelectAddAnApprentice()
                        .SubmitValidApprenticeDetails();
            }

            return SetApprenticeDetails(providerReviewYourCohortPage, numberOfApprentices);
        }

        public ProviderCohortApprovedAndSentToEmployerPage AddApprenticeViaBulkUpload(int numberOfApprentices)
        {
            var providerReviewYourCohortPage = CurrentCohortDetails();

            return providerReviewYourCohortPage
                .SelectBulkUploadApprentices()
                .UploadFileAndConfirmSuccessful(numberOfApprentices)
                .SelectSaveAndContinue()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

        public ProviderReviewYourCohortPage CurrentCohortDetails()
        {
            GoToProviderHomePage();

            return new ProviderYourCohortsPage(_context, true)
                .GoToCohortsToReviewPage()
                .SelectViewCurrentCohortDetails();
        }

        public ProviderReviewYourCohortPage EditApprentice(ProviderReviewYourCohortPage providerReviewYourCohortPage, bool shouldCheckCoursesAreStandards = false)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                var ulnFields = providerReviewYourCohortPage.ApprenticeUlns().Reverse<IWebElement>();
                int j = ulnFields.Count() - 1;

                foreach (IWebElement uln in ulnFields)
                {
                    if (uln.Text.Equals("–"))
                    {
                        var providerEditApprenticeDetailsPage = providerReviewYourCohortPage.SelectEditApprentice(j);

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

            return providerReviewYourCohortPage;
        }

        public ProviderReviewYourCohortPage EditApprentice(bool shouldCheckCoursesAreStandards = false)
        {
            return EditApprentice(CurrentCohortDetails(), shouldCheckCoursesAreStandards);
        }

        public ProviderReviewYourCohortPage EditAllDetailsOfApprentice(ProviderReviewYourCohortPage providerReviewYourCohortPage)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
                providerReviewYourCohortPage = providerReviewYourCohortPage.SelectEditApprentice(i)
                                         .EditAllApprenticeDetails();

            return providerReviewYourCohortPage;
        }

        public ProviderReviewYourCohortPage DeleteApprentice(ProviderReviewYourCohortPage providerReviewYourCohortPage)
        {
            var totalNoOfApprentices = _objectContext.GetNoOfApprentices();

            for (int i = 0; i < totalNoOfApprentices; i++)
            {
                providerReviewYourCohortPage = providerReviewYourCohortPage.SelectEditApprentice(0)
                                          .DeleteApprentice()
                                          .ConfirmDeleteAndSubmit();
            }

            return providerReviewYourCohortPage;
        }

        public void DeleteCohort(ProviderReviewYourCohortPage providerReviewYourCohortPage)
        {
            providerReviewYourCohortPage.SelectDeleteCohort()
                .ConfirmDeleteAndSubmit();
        }

        public void Approve()
        {
            EditApprentice()
                .SelectContinueToApproval()
                .SubmitApprove();
        }

        public void ApprovesTheCohortsAndSendsToEmployer()
        {
            EditApprentice()
                .SelectContinueToApproval()
                .SubmitApproveAndSendToEmployerForApproval()
                .SendInstructionsToEmployerForAnApprovedCohort();
        }

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

        private ProviderReviewYourCohortPage SetApprenticeDetails(ProviderReviewYourCohortPage providerReviewYourCohortPage, int numberOfApprentices)
        {
            _objectContext.SetNoOfApprentices(_reviewYourCohortStepsHelper.NoOfApprentice(providerReviewYourCohortPage, numberOfApprentices));
            _objectContext.SetApprenticeTotalCost(_reviewYourCohortStepsHelper.ApprenticeTotalCost(providerReviewYourCohortPage));

            return providerReviewYourCohortPage;
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
             .SelectSaveAndContinue()
             .SubmitApproveAndSendToEmployerForApproval()
             .SendInstructionsToEmployerForAnApprovedCohort();
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