using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class PreviewYourVacancyPage : Raav2BasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "Preview your advert" : "Preview your vacancy";

        protected override By ContinueButton => By.CssSelector("[data-automation='link-continue']");
        
        public PreviewYourVacancyPage(ScenarioContext context) : base(context) { }

        public PreviewYourAdvertOrVacancyPage PreviewVacancy()
        {
            Continue();
            return new PreviewYourAdvertOrVacancyPage(context);
        }
    }
}
