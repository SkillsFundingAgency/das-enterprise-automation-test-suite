using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers
{
    public class EmployerStepsHelper(ScenarioContext context)
    {
        private readonly RAAV2EmployerLoginStepsHelper _rAAV2EmployerLoginHelper = new(context);
        private readonly StepsHelper _stepsHelper = new(context);

        internal EmployerVacancySearchResultPage YourAdvert()
        {
            _rAAV2EmployerLoginHelper.GotoEmployerHomePage();

            return _rAAV2EmployerLoginHelper.NavigateToRecruitmentHomePage().SearchYourAdverts();
        }

        internal void EditVacancyDates() => SearchVacancyByVacancyReferenceInNewTab().GoToVacancyManagePage().EditAdvert().EnterVacancyDates();

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
