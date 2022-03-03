using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class CheckYourAnswersPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Check your answers";

        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public CheckYourAnswersPage(ScenarioContext context) : base(context)  { }

        public VacancyPreviewPart2Page PreviewAdvert()
        {
            formCompletionHelper.ClickLinkByText("Preview advert before submitting");
            return new VacancyPreviewPart2Page(context);
        }

        public VacancyReferencePage SubmitAdvert()
        {
            Continue();
            return new VacancyReferencePage(context);
        }
    }
}
