using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Helpers
{
    public class ProviderCreateDraftAdvertStepsHelper(ScenarioContext context) : ProviderCreateVacancyStepsHelper(context)
    {
        protected bool IsFoundationAdvert => context.ContainsKey("isFoundationAdvert") && (bool)context["isFoundationAdvert"];
        internal VacancyReferencePage SubmitDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            CheckAndSubmitAdvert(CompleteAboutTheEmployer(createAdvertPage).EnterAdditionalQuestionsForApplicants().CompleteAllAdditionalQuestionsForApplicants(IsFoundationAdvert, true, true));

        internal CreateAnApprenticeshipAdvertOrVacancyPage CompleteDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            CompleteAboutTheEmployer(createAdvertPage).EnterAdditionalQuestionsForApplicants().CompleteAllAdditionalQuestionsForApplicants(IsFoundationAdvert, true, true).CheckYourAnswers().PreviewVacancy().DeleteVacancy().NoDeleteVacancy();

        internal ProviderVacancySearchResultPage CompleteDeleteOfDraftVacancy() => new CreateAnApprenticeshipAdvertOrVacancyPage(context).CheckYourAnswers().PreviewVacancy().DeleteVacancy().YesDeleteVacancy();

        protected CreateAnApprenticeshipAdvertOrVacancyPage CompleteAboutTheEmployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            AboutTheEmployer(SkillsAndQualifications(createAdvertPage), string.Empty, true, true);
    }
}
