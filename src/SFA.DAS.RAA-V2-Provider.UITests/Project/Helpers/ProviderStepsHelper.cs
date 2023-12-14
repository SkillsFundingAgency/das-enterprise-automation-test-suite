using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers
{
    public class ProviderStepsHelper(ScenarioContext context) : ProviderBaseStepsHelper(context)
    {
        public ProviderVacancySearchResultPage SearchVacancy() => GoToRecruitmentHomePage().SearchVacancy();

        internal void ViewReferVacancy() => GoToRecruitmentHomePage().SearchReferAdvertTitle();

        internal void ApplicantSucessful() => StepsHelper.ApplicantSucessful(SearchVacancyByVacancyReference());

        internal void ApplicantUnsucessful() => StepsHelper.ApplicantUnsucessful(SearchVacancyByVacancyReference());

        internal void VerifyWageType(string wageType) => StepsHelper.VerifyWageType(SearchVacancyByVacancyReference(), wageType);

        private ProviderVacancySearchResultPage SearchVacancyByVacancyReference() => GoToRecruitmentHomePage().SearchVacancyByVacancyReference();

        private RecruitmentHomePage GoToRecruitmentHomePage() => GoToRecruitmentHomePage(true);
    }
}