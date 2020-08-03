using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;
using DoYouNeedToCreateAnAdvertPage = SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.DynamicHomePageEmployer.DoYouNeedToCreateAnAdvertPage;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers
{
    public class EmployerStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _loginhelper;
        private readonly EmployerHomePageStepsHelper _homePageStepsHelper;
        private readonly StepsHelper _stepsHelper;

        public EmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _loginhelper = new EmployerPortalLoginHelper(context);
            _homePageStepsHelper = new EmployerHomePageStepsHelper(context);
            _stepsHelper = new StepsHelper(context);
        }

        internal void SubmitVacancy(VacancyPreviewPart2Page previewPage, bool isApplicationMethodFAA, bool optionalFields) => _stepsHelper.SubmitVacancy(previewPage, isApplicationMethodFAA, optionalFields);

        internal YourAdvertsPage DeleteDraftVacancy(VacancyPreviewPart2Page previewPage) => previewPage.DeleteVacancy().YesDeleteVacancy();

        internal YourAdvertsPage CancelVacancy() => EnterVacancyTitle().CancelVacancy();

        internal void CreateOfflineVacancy(bool disabilityConfidence)
        {
            var previewPage = PreviewVacancy(string.Empty, true, disabilityConfidence);

            _stepsHelper.SubmitVacancy(previewPage, false, false);

            SearchVacancyByVacancyReference().NavigateToViewVacancyPage().VerifyDisabilityConfident();
        }

        internal void CloneAVacancy() =>  _stepsHelper.SubmitVacancy(GoToRecruitmentHomePage().SelectLiveAdvert().CloneVacancy().SelectYes().UpdateTitle().UpdateVacancyTitle().UpdateApplicationProcess().ApplicationMethod(true));

        internal void EditVacancyDates() => SearchVacancyByVacancyReferenceInNewTab().EditVacancy().EditVacancyCloseDate().EnterVacancyDates().EditVacancyStartDate().EnterPossibleStartDate().PublishVacancy();

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
            var whichEmployerNameDoYouWantOnYourAdvertPage = SelectOrganisation();

            var locationPage = _stepsHelper.ChooseEmployerNameForEmployerJourney(whichEmployerNameDoYouWantOnYourAdvertPage, string.Empty);

            var previewPage = _stepsHelper.PreviewVacancy(locationPage, wageType);

            _stepsHelper.SubmitVacancy(previewPage, true, false);
        }

        internal void CreateSubmittedVacancy(WhatDoYouWantToCallThisAdvertPage whatDoYouWantToCallThisAdvertPage, string wageType)
        {
            var previewPage = CreateDraftVacancy(whatDoYouWantToCallThisAdvertPage, wageType);

            _stepsHelper.SubmitVacancy(previewPage, true, false);
        }

        internal VacancyPreviewPart2Page CreateDraftVacancy(WhatDoYouWantToCallThisAdvertPage whatDoYouWantToCallThisAdvertPage, string wageType)
        {
            var whichEmployerNameDoYouWantOnYourAdvertPage = SelectOrganisationForNewAccount(whatDoYouWantToCallThisAdvertPage);

            var locationPage = _stepsHelper.ChooseEmployerNameForEmployerJourney(whichEmployerNameDoYouWantOnYourAdvertPage, string.Empty);

            return _stepsHelper.PreviewVacancy(locationPage, wageType);
        }

        internal void VerifyWageType(string wageType) => _stepsHelper.VerifyWageType(SearchVacancyByVacancyReference(), wageType);

        internal VacancyPreviewPart2Page PreviewVacancy(string employername, bool isEmployerAddress, bool disabilityConfidence)
        {
            var whichEmployerNameDoYouWantOnYourAdvertPage = SelectOrganisation();

            return _stepsHelper.PreviewVacancyForEmployerJourney(whichEmployerNameDoYouWantOnYourAdvertPage, employername, isEmployerAddress, disabilityConfidence);
        }
        internal WhatDoYouWantToCallThisAdvertPage GoToAddAnAdvert()
        {
            new RecruitmentDynamicHomePage(_context, true).ContinueToCreateAdvert();
            return new DoYouNeedToCreateAnAdvertPage(_context).ClickYesRadioButtonTakesToRecruitment().ClickStartNow();
        }

        internal YourApprenticeshipAdvertsHomePage GoToRecruitmentHomePage()
        {
            _loginhelper.Login(_context.GetUser<RAAV2EmployerUser>(), true);

            return NavigateToRecruitmentHomePage();
        }

        private ManageVacancyPage SearchVacancyByVacancyReferenceInNewTab()
        {
            _homePageStepsHelper.GotoEmployerHomePage();

            return SearchVacancyByVacancyReference();
        }

        private ManageVacancyPage SearchVacancyByVacancyReference() => NavigateToRecruitmentHomePage().SearchAdvertByReferenceNumber();

        private ApprenticeshipTrainingPage EnterVacancyTitle() => GoToRecruitmentHomePage().CreateAnAdvert().CreateNewAdvert().EnterVacancyTitle();

        private WhichEmployerNameDoYouWantOnYourAdvertPage SelectOrganisation() => EnterTrainingDetails(EnterVacancyTitle()).SubmitNoOfPositionsAndNavigateToSelectOrganisationPage().SelectOrganisation();

        private WhichEmployerNameDoYouWantOnYourAdvertPage SelectOrganisationForNewAccount(WhatDoYouWantToCallThisAdvertPage whatDoYouWantToCallThisAdvertPage)
        {
            EnterTrainingDetails(whatDoYouWantToCallThisAdvertPage.EnterVacancyTitleForTheFirstVacancy().SelectYes()).EnterNumberOfPositionsAndContinue();
            return new WhichEmployerNameDoYouWantOnYourAdvertPage(_context);
        }

        private SubmitNoOfPositionsPage EnterTrainingDetails(ApprenticeshipTrainingPage apprenticeshipTrainingPage) => apprenticeshipTrainingPage.EnterTrainingTitle().ConfirmTrainingAndContinue().ChooseTrainingProvider().ConfirmTrainingProviderAndContinue();

        private YourApprenticeshipAdvertsHomePage NavigateToRecruitmentHomePage() => new YourApprenticeshipAdvertsHomePage(_context, true);
    }
}
