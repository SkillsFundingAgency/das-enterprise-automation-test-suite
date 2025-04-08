using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class CheckYourAnswersPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "Check your answers" : "Check your answers before submitting your vacancy";

        private static By BackToTaskSelector => By.CssSelector("[data-automation='link-back']");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        private static By ChangeAdditionalQuestion => By.CssSelector("a[data-automation='change-additional-question-1']");

        public PreviewYourAdvertOrVacancyPage PreviewAdvert()
        {
            formCompletionHelper.ClickLinkByText("Preview advert before submitting");
            return new PreviewYourAdvertOrVacancyPage(context);
        }

        public PreviewYourAdvertOrVacancyPage PreviewVacancy()
        {
            formCompletionHelper.ClickLinkByText("Preview vacancy before submitting");
            return new PreviewYourAdvertOrVacancyPage(context);
        }

        public CreateAnApprenticeshipAdvertOrVacancyPage BackToTaskList()
        {
            formCompletionHelper.Click(BackToTaskSelector);
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }

        public VacancyReferencePage SubmitAdvert()
        {
            Continue();
            return new VacancyReferencePage(context);
        }

        public AdditionalQuestionsPage UpdateAdditionalQuestion()
        {
            formCompletionHelper.Click(ChangeAdditionalQuestion);

            return new (context);
        }
}
}
