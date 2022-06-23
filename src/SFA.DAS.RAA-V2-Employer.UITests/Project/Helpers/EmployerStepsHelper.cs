using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
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

        internal void EditVacancyDates() => SearchVacancyByVacancyReferenceInNewTab().GoToVacancyManagePage().EditAdvert().EditVacancyCloseDate().EnterVacancyDates().EditVacancyStartDate().EnterPossibleStartDate().PublishVacancy();

        internal void CloseVacancy() => SearchVacancyByVacancyReferenceInNewTab().GoToVacancyManagePage().CloseAdvert().YesCloseThisVacancy();

        internal void ApplicantUnsucessful() => _stepsHelper.ApplicantUnsucessful(SearchVacancyByVacancyReferenceInNewTab());

        internal void ApplicantSucessful() => _stepsHelper.ApplicantSucessful(SearchVacancyByVacancyReferenceInNewTab());

        internal void VerifyWageType(string wageType) => _stepsHelper.VerifyWageType(SearchVacancyByVacancyReference(), wageType);

        private EmployerVacancySearchResultPage SearchVacancyByVacancyReferenceInNewTab()
        {
            _rAAV2EmployerLoginHelper.GotoEmployerHomePage();

            return SearchVacancyByVacancyReference();
        }

        private EmployerVacancySearchResultPage SearchVacancyByVacancyReference() => _rAAV2EmployerLoginHelper.NavigateToRecruitmentHomePage().SearchAdvertByReferenceNumber();
    }
}
