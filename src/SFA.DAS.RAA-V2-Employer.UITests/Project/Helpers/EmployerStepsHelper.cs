using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers
{
    public class EmployerStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _loginhelper;
        private readonly HomePageStepsHelper _homePageStepsHelper;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly StepsHelper _stepsHelper;
        public EmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _loginhelper = new EmployerPortalLoginHelper(context);
            _homePageStepsHelper = new HomePageStepsHelper(context);
            _stepsHelper = new StepsHelper(context);
            _loginHelper = new EmployerPortalLoginHelper(_context);
        }

        internal void SubmitVacancy(VacancyPreviewPart2Page previewPage, bool isApplicationMethodFAA, bool optionalFields)
        {
            _stepsHelper.SubmitVacancy(previewPage, isApplicationMethodFAA, optionalFields);
        }

        internal VacanciesPage DeleteDraftVacancy(VacancyPreviewPart2Page previewPage) => previewPage.DeleteVacancy().YesDeleteVacancy();

        internal VacanciesPage CancelVacancy() => EnterVacancyTitle().CancelVacancy();


        internal void CreateOfflineVacancy(bool disabilityConfidence)
        {
            var previewPage = PreviewVacancy(string.Empty, true, disabilityConfidence);

            _stepsHelper.SubmitVacancy(previewPage, false, false);

            SearchVacancyByVacancyReference().NavigateToViewVacancyPage().VerifyDisabilityConfident();
        }

        internal void CloneAVacancy()
        {
          var previewPage = GoToRecruitmentHomePage()
                .SelectLiveVacancy()
                .CloneVacancy()
                .SelectYes()
                .UpdateTitle()
                .UpdateVacancyTitle();

            _stepsHelper.SubmitVacancy(previewPage);
        }

        internal void EditVacancyDates() 
        {
            SearchVacancyByVacancyReferenceInNewTab()
                .EditVacancy()
                .EditVacancyCloseDate()
                .EnterVacancyDates()
                .EditVacancyStartDate()
                .EnterPossibleStartDate()
                .PublishVacancy();
        }

        internal void CloseVacancy() => SearchVacancyByVacancyReferenceInNewTab().CloseVacancy().YesCloseThisVacancy();

        internal void ApplicantUnsucessful() => _stepsHelper.ApplicantUnsucessful(SearchVacancyByVacancyReferenceInNewTab());

        internal void ApplicantSucessful() => _stepsHelper.ApplicantSucessful(SearchVacancyByVacancyReferenceInNewTab());

        internal void CreateANewVacancy(string employername, bool isEmployerAddress, bool optionalFields = false)
        {
            var previewPage = PreviewVacancy(employername, isEmployerAddress, false);

            _stepsHelper.SubmitVacancy(previewPage, true, optionalFields);

            SearchVacancyByVacancyReference().NavigateToViewVacancyPage().VerifyEmployerName();
        }

        internal void CreateANewVacancy(string wageType)
        {
            var employernamePage = SelectOrganisation();  

            var locationPage = _stepsHelper.ChooseEmployerName(employernamePage, string.Empty);

            var previewPage = _stepsHelper.PreviewVacancy(locationPage, wageType);

            _stepsHelper.SubmitVacancy(previewPage, true, false);
        }
        

        internal void CreateFirstSubmittedVacancy(string wageType)
        {
            var employernamePage = SelectOrganisationForNewAccount();

            var locationPage = _stepsHelper.ChooseEmployerName(employernamePage, string.Empty);

            var previewPage = _stepsHelper.PreviewVacancy(locationPage, wageType);

            _stepsHelper.SubmitVacancy(previewPage, true, false);
        }

        internal void VerifyWageType(string wageType) => _stepsHelper.VerifyWageType(SearchVacancyByVacancyReference(), wageType);

        internal VacancyPreviewPart2Page PreviewVacancy(string employername, bool isEmployerAddress, bool disabilityConfidence)
        {
            var employernamePage = SelectOrganisation();

            return _stepsHelper.PreviewVacancy(employernamePage, employername, isEmployerAddress, disabilityConfidence);
        }

        private ManageVacancyPage SearchVacancyByVacancyReferenceInNewTab()
        {
            _homePageStepsHelper.GotoEmployerHomePage();

            return SearchVacancyByVacancyReference();
        }

        private ManageVacancyPage SearchVacancyByVacancyReference() => NavigateToRecruitmentHomePage().SearchVacancyByVacancyReference();

        private RecruitmentHomePage GoToRecruitmentHomePage()
        {
            _loginhelper.Login(_context.GetUser<RAAV2EmployerUser>(), true);

            return NavigateToRecruitmentHomePage();
        }

        //private RecruitmentLandingPage GoToRecruitmentLandingPage()
        //{
            
        //}

        private RecruitmentHomePage NavigateToRecruitmentHomePage() => new RecruitmentHomePage(_context, true);

        //private RecruitmentLandingPage NavigateToRecruitmentLandingPage() => new RecruitmentLandingPage(_context, true);

        private ApprenticeshipTrainingPage EnterVacancyTitle()
        {
            return GoToRecruitmentHomePage()
                .CreateANewVacancy()
                .CreateNewVacancy()
                .EnterVacancyTitle();
        }

        public VacancyTitlePage GoToAddAnAdvert()
        {
            MFEmployerStepsHelper _mfEmployerStepsHelper = new MFEmployerStepsHelper(_context);
            _mfEmployerStepsHelper.ContinueToCreateAddAnApprentices();
            DoYouNeedToCreateAnAdvertPage _doYouNeedToCreateAnAdvertPage = new DoYouNeedToCreateAnAdvertPage(_context);
            _doYouNeedToCreateAnAdvertPage.ClickYesRadioButtonTakesToRecruitment();
            return new RecruitmentLandingPage(_context).ClickStartNow();
        }
        
        private EmployerNamePage SelectOrganisation()
        {
            return EnterVacancyTitle()
                .EnterTrainingTitle()
                .ConfirmTrainingAndContinue()
                .ChooseTrainingProvider()
                .ConfirmTrainingProviderAndContinue()
                .SubmitNoOfPositions()
                .SelectOrganisation();
        }

        private EmployerNamePage SelectOrganisationForNewAccount()
        {
            return new VacancyTitlePage(_context).EnterVacancyTitleForTheFirstVacancy()
                .SelectYes()
                .EnterTrainingTitle()
                .ConfirmTrainingAndContinue()
                .ChooseTrainingProvider()
                .ConfirmTrainingProviderAndContinue()
                .SubmitNoOfPositionsAndNavigateToEmployerNamePage();
        }

        public VacanciesPage CreateFirstDraftVacancy()
        {
            return new VacancyTitlePage(_context).EnterVacancyTitleForTheFirstVacancy().CancelVacancy();
        }

        public string ConfirmVacancyStatus(string vacancyStatus)
        {
            string status = null;
            if (_loginHelper.IsYourAccountPageDisplayed())
            {
                status = new VacancyReferencePage(_context).GoToHomePage().ConfirmVacancyDetails(vacancyStatus);                
            }
            else
            {
                status = new DynamicHomePage(_context).ConfirmVacancyDetails(vacancyStatus);
            }
            return status.Remove(0,7);
        }

        private void ClicktheButtonOnAdvertPage(string button)
        {
            new DynamicHomePage(_context).ClicktheButtonOnAdvertPage(button);
        }

        public HaveYouAlreadyFoundTrainingPage ClickContinueCreatingYourVacancy(string button)
        {
            ClicktheButtonOnAdvertPage(button);
            return new HaveYouAlreadyFoundTrainingPage(_context);
        }

        public RecruitmentHomePage ClickGoToYourVacancy(string button)
        {
            ClicktheButtonOnAdvertPage(button);
            return new RecruitmentHomePage(_context);
        }

        public VacancyPreviewPart2Page ClickReviewYourVacancy(string button)
        {
            ClicktheButtonOnAdvertPage(button);
            return new VacancyPreviewPart2Page(_context);
        }

        public ManageVacancyPage ClickApplicationsLink(string button)
        {
            ClicktheButtonOnAdvertPage(button);
            return new ManageVacancyPage(_context);
        }
    }
}
