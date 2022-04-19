using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers
{
    public class EmployerStepsHelper
    {
        private readonly RAAV2EmployerLoginStepsHelper _rAAV2EmployerLoginHelper;
        private readonly StepsHelper _stepsHelper;

        public EmployerStepsHelper(ScenarioContext context)
        {
            _stepsHelper = new StepsHelper(context);
            _rAAV2EmployerLoginHelper = new RAAV2EmployerLoginStepsHelper(context);
        }

        internal EmployerVacancySearchResultPage YourAdvert()
        {
            _rAAV2EmployerLoginHelper.GotoEmployerHomePage();

            return _rAAV2EmployerLoginHelper.NavigateToRecruitmentHomePage().SearchYourAdverts();
        }

        internal EmployerVacancySearchResultPage DeleteDraftVacancy(VacancyPreviewPart2Page previewPage) => previewPage.DeleteVacancy().YesDeleteVacancy();

        internal void EditVacancyDates() => SearchVacancyByVacancyReferenceInNewTab().EditAdvert().EditVacancyCloseDate().EnterVacancyDates().EditVacancyStartDate().EnterPossibleStartDate().PublishVacancy();

        internal void CloseVacancy() => SearchVacancyByVacancyReferenceInNewTab().CloseAdvert().YesCloseThisVacancy();

        internal void ApplicantUnsucessful() => _stepsHelper.ApplicantUnsucessful(SearchVacancyByVacancyReferenceInNewTab());

        internal void ApplicantSucessful() => _stepsHelper.ApplicantSucessful(SearchVacancyByVacancyReferenceInNewTab());

        internal void VerifyWageType(string wageType) => _stepsHelper.VerifyWageType(SearchVacancyByVacancyReference(), wageType);

        internal VacancyPreviewPart2Page PreviewVacancy(string employername, bool isEmployerAddress, bool disabilityConfidence)
        {
            var whichEmployerNameDoYouWantOnYourAdvertPage = SelectOrganisation();

            return _stepsHelper.PreviewVacancyForEmployerJourney(whichEmployerNameDoYouWantOnYourAdvertPage, employername, isEmployerAddress, disabilityConfidence);
        }

        private ManageRecruitPage SearchVacancyByVacancyReferenceInNewTab()
        {
            _rAAV2EmployerLoginHelper.GotoEmployerHomePage();

            return SearchVacancyByVacancyReference();
        }

        private ManageRecruitPage SearchVacancyByVacancyReference() => _rAAV2EmployerLoginHelper.NavigateToRecruitmentHomePage().SearchAdvertByReferenceNumber();

        private ApprenticeshipTrainingPage EnterVacancyTitle() => _rAAV2EmployerLoginHelper.GoToRecruitmentHomePage().CreateAnAdvert().CreateNewAdvert().EnterVacancyTitle();

        private WhichEmployerNameDoYouWantOnYourAdvertPage SelectOrganisation() => EnterTrainingDetails(EnterVacancyTitle()).SubmitNoOfPositionsAndNavigateToSelectOrganisationPage().SelectOrganisation();

        private SubmitNoOfPositionsPage EnterTrainingDetails(ApprenticeshipTrainingPage apprenticeshipTrainingPage) => apprenticeshipTrainingPage.EnterTrainingTitle().ConfirmTrainingAndContinue().ChooseFoundATrainingProvider().ConfirmTrainingProviderAndContinue();
    }
}
