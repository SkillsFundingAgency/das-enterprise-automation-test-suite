using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers
{
    public class ProviderStepsHelper : ProviderBaseStepsHelper
    {
        private readonly StepsHelper _stepsHelper;

        public ProviderStepsHelper(ScenarioContext context) : base(context) => _stepsHelper = new StepsHelper(_context);

        public ProviderVacancySearchResultPage SearchVacancy() => GoToRecruitmentHomePage().SearchVacancy();

        internal void ViewReferVacancy() => GoToRecruitmentHomePage().SearchReferAdvertTitle();

        internal void ApplicantSucessful() => _stepsHelper.ApplicantSucessful(SearchVacancyByVacancyReference());

        internal void ApplicantUnsucessful() => _stepsHelper.ApplicantUnsucessful(SearchVacancyByVacancyReference());

        internal void VerifyWageType(string wageType) => _stepsHelper.VerifyWageType(SearchVacancyByVacancyReference(), wageType);

        private ProviderVacancySearchResultPage SearchVacancyByVacancyReference() => GoToRecruitmentHomePage().SearchVacancyByVacancyReference();

        private RecruitmentHomePage GoToRecruitmentHomePage() => GoToRecruitmentHomePage(true);
    }
}