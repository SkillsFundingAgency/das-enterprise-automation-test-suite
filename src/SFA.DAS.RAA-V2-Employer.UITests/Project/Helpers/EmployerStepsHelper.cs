using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;
using DoYouNeedToCreateAnAdvertPage = SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.DynamicHomePageEmployer.DoYouNeedToCreateAnAdvertPage;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers
{
    public class EmployerStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RAAV2EmployerLoginStepsHelper _rAAV2EmployerLoginHelper;
        private readonly StepsHelper _stepsHelper;

        public EmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new StepsHelper(context);
            _rAAV2EmployerLoginHelper = new RAAV2EmployerLoginStepsHelper(context);
        }

        internal EmployerVacancySearchResultPage YourAdvert()
        {
            _rAAV2EmployerLoginHelper.GotoEmployerHomePage();

            return _rAAV2EmployerLoginHelper.NavigateToRecruitmentHomePage().SearchYourAdverts();
        }

        internal void SubmitVacancy(VacancyPreviewPart2Page previewPage, bool isApplicationMethodFAA, bool optionalFields) => _stepsHelper.SubmitVacancy(previewPage, isApplicationMethodFAA, optionalFields);

        internal EmployerVacancySearchResultPage DeleteDraftVacancy(VacancyPreviewPart2Page previewPage) => previewPage.DeleteVacancy().YesDeleteVacancy();

        internal EmployerVacancySearchResultPage CancelVacancy() => EnterVacancyTitle().CancelVacancy();

        internal void CreateOfflineVacancy(bool disabilityConfidence)
        {
            var previewPage = PreviewVacancy(string.Empty, true, disabilityConfidence);

            _stepsHelper.SubmitVacancy(previewPage, false, false);

            SearchVacancyByVacancyReference().NavigateToViewAdvertPage().VerifyDisabilityConfident();
        }

        internal VacancyReferencePage CloneAVacancy() =>  _stepsHelper.SubmitVacancy(_rAAV2EmployerLoginHelper.GoToRecruitmentHomePage().SelectLiveAdvert().CloneAdvert().SelectYes().UpdateTitle().UpdateVacancyTitle().UpdateApplicationProcess().ApplicationMethod(true));

        internal void EditVacancyDates() => SearchVacancyByVacancyReferenceInNewTab().EditAdvert().EditVacancyCloseDate().EnterVacancyDates().EditVacancyStartDate().EnterPossibleStartDate().PublishVacancy();

        internal void CloseVacancy() => SearchVacancyByVacancyReferenceInNewTab().CloseAdvert().YesCloseThisVacancy();

        internal void ApplicantUnsucessful() => _stepsHelper.ApplicantUnsucessful(SearchVacancyByVacancyReferenceInNewTab());

        internal void ApplicantSucessful() => _stepsHelper.ApplicantSucessful(SearchVacancyByVacancyReferenceInNewTab());

        internal void CreateANewVacancy(string employername, bool isEmployerAddress, bool optionalFields = false)
        {
            var previewPage = PreviewVacancy(employername, isEmployerAddress, false);

            _stepsHelper.SubmitVacancy(previewPage, true, optionalFields);

            SearchVacancyByVacancyReference().NavigateToViewAdvertPage().VerifyEmployerName();
        }

        internal VacancyReferencePage CreateANewVacancy(string wageType)
        {
            var whichEmployerNameDoYouWantOnYourAdvertPage = SelectOrganisation();

            var locationPage = _stepsHelper.ChooseEmployerNameForEmployerJourney(whichEmployerNameDoYouWantOnYourAdvertPage, string.Empty);

            var previewPage = _stepsHelper.PreviewVacancy(locationPage, wageType);

            return _stepsHelper.SubmitVacancy(previewPage, true, false);
        }

        internal VacancyReferencePage CreateSubmittedVacancy(WhatDoYouWantToCallThisAdvertPage whatDoYouWantToCallThisAdvertPage, string wageType)
        {
            var previewPage = CreateDraftVacancy(whatDoYouWantToCallThisAdvertPage, wageType);

            return _stepsHelper.SubmitVacancy(previewPage, true, false);
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

        private ManageRecruitPage SearchVacancyByVacancyReferenceInNewTab()
        {
            _rAAV2EmployerLoginHelper.GotoEmployerHomePage();

            return SearchVacancyByVacancyReference();
        }

        private ManageRecruitPage SearchVacancyByVacancyReference() => _rAAV2EmployerLoginHelper.NavigateToRecruitmentHomePage().SearchAdvertByReferenceNumber();

        private ApprenticeshipTrainingPage EnterVacancyTitle() => _rAAV2EmployerLoginHelper.GoToRecruitmentHomePage().CreateAnAdvert().CreateNewAdvert().EnterVacancyTitle();

        private WhichEmployerNameDoYouWantOnYourAdvertPage SelectOrganisation() => EnterTrainingDetails(EnterVacancyTitle()).SubmitNoOfPositionsAndNavigateToSelectOrganisationPage().SelectOrganisation();

        private WhichEmployerNameDoYouWantOnYourAdvertPage SelectOrganisationForNewAccount(WhatDoYouWantToCallThisAdvertPage whatDoYouWantToCallThisAdvertPage)
        {
            EnterTrainingDetails(whatDoYouWantToCallThisAdvertPage.EnterVacancyTitleForTheFirstAdvert().SelectYes()).EnterNumberOfPositionsAndContinue();
            return new WhichEmployerNameDoYouWantOnYourAdvertPage(_context);
        }

        private SubmitNoOfPositionsPage EnterTrainingDetails(ApprenticeshipTrainingPage apprenticeshipTrainingPage) => apprenticeshipTrainingPage.EnterTrainingTitle().ConfirmTrainingAndContinue().ChooseFoundATrainingProvider().ConfirmTrainingProviderAndContinue();
    }
}
