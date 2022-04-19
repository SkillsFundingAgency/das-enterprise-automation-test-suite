using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmQualificationsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Qualifications";

        private By Preview => By.PartialLinkText("Preview");

        public ConfirmQualificationsPage(ScenarioContext context) : base(context) { }

        public VacancyPreviewPart2Page ConfirmQualifications()
        {
            formCompletionHelper.Click(Preview);
            return new VacancyPreviewPart2Page(context);
        }

        public FutureProspectsPage ConfirmQualificationsAndGoToFutureProspectsPage()
        {
            SaveAndContinue();
            return new FutureProspectsPage(context);
        }

        public ThingsToConsiderPage ConfirmQualificationsAndContinue()
        {
            SaveAndContinue();
            return new ThingsToConsiderPage(context);
        }

        private void SaveAndContinue() => formCompletionHelper.ClickLinkByText("Save and continue");
    }
}
