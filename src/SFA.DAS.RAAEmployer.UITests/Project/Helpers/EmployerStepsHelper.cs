using SFA.DAS.RAA.Service.Project.Helpers;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAEmployer.UITests.Project.Helpers
{
    public class EmployerStepsHelper(ScenarioContext context)
    {
        private readonly RAAEmployerLoginStepsHelper _rAAEmployerLoginHelper = new(context);
        internal EmployerVacancySearchResultPage YourAdvert()
        {
            _rAAEmployerLoginHelper.GotoEmployerHomePage();

            return _rAAEmployerLoginHelper.NavigateToRecruitmentHomePage().SearchYourAdverts();
        }

        internal void EditVacancyDates() => SearchVacancyByVacancyReferenceInNewTab().GoToVacancyManagePage().EditAdvert().EnterVacancyDates();

        internal void CloseVacancy() => SearchVacancyByVacancyReferenceInNewTab().GoToVacancyManagePage().CloseAdvert().YesCloseThisVacancy();

        internal void ApplicantUnsucessful() => StepsHelper.ApplicantUnsucessful(SearchVacancyByVacancyReferenceInNewTab());

        public void ApplicantShared() => StepsHelper.ApplicantSucessful(SearchVacancyByVacancyReferenceInNewTab());

        internal void ApplicantSucessful() => StepsHelper.ApplicantSucessful(SearchVacancyByVacancyReferenceInNewTab());

        internal void VerifyWageType(string wageType) => StepsHelper.VerifyWageType(SearchVacancyByVacancyReference(), wageType);

        private EmployerVacancySearchResultPage SearchVacancyByVacancyReferenceInNewTab()
        {
            _rAAEmployerLoginHelper.GotoEmployerHomePage();

            return SearchVacancyByVacancyReference();
        }

        private EmployerVacancySearchResultPage SearchVacancyByVacancyReference() => _rAAEmployerLoginHelper.NavigateToRecruitmentHomePage().SearchAdvertByReferenceNumber();
    }
}
