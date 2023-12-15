using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAT_Provider.UITests.Project.Helpers
{
    public class ProviderStepsHelper(ScenarioContext context) : ProviderBaseStepsHelper(context)
    {
        internal void ViewReferVacancy() => GoToTraineeshipHomePage().SearchReferAdvertTitle();

        internal void ApplicantSucessful() => StepsHelper.ApplicantSucessful(SearchVacancyByVacancyReference());

        internal void ApplicantUnsucessful() => StepsHelper.ApplicantUnsucessful(SearchVacancyByVacancyReference());

        internal void VerifyWageType(string wageType) => StepsHelper.VerifyWageType(SearchVacancyByVacancyReference(), wageType);

        private ProviderVacancySearchResultPage SearchVacancyByVacancyReference() => GoToTraineeshipHomePage().SearchVacancyByVacancyReference();

        private TraineeshipRecruitHomePage GoToTraineeshipHomePage() => GoToTraineeshipHomePage(true);
    }
}
