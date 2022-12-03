using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmQualificationsPage : Raav2BasePage
    {
        protected override string PageTitle => "Qualifications";

        private By Preview => By.PartialLinkText("Preview");

        public ConfirmQualificationsPage(ScenarioContext context) : base(context) { }

        public PreviewYourAdvertOrVacancyPage ConfirmQualifications()
        {
            formCompletionHelper.Click(Preview);
            return new PreviewYourAdvertOrVacancyPage(context);
        }

        public FutureProspectsPage ConfirmQualificationsAndGoToFutureProspectsPage()
        {
            formCompletionHelper.ClickLinkByText("Save and continue");
            return new FutureProspectsPage(context);
        }
    }
}
