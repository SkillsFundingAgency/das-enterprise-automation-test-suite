using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class PreviewYourVacancyPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "Preview your advert" : "Preview your vacancy";

        protected override By ContinueButton => By.CssSelector("[data-automation='link-continue']");

        public PreviewYourAdvertOrVacancyPage PreviewVacancy()
        {
            Continue();
            return new PreviewYourAdvertOrVacancyPage(context);
        }
    }
}
