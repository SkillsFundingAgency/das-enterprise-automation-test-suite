using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class CheckYourAnswersPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "Check your answers" : "Check your answers before submitting your vacancy";

        private By BackToTaskSelector => By.CssSelector("[data-automation='link-back']");

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public CheckYourAnswersPage(ScenarioContext context) : base(context)  { }

        public VacancyPreviewPart2Page PreviewAdvert()
        {
            formCompletionHelper.ClickLinkByText("Preview advert before submitting");
            return new VacancyPreviewPart2Page(context);
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
    }
}
