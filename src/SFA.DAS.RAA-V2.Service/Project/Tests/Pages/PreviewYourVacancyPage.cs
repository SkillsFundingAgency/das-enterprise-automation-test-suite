using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class PreviewYourVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "Preview your advert" : "Preview your vacancy";

        protected override By ContinueButton => By.CssSelector("[data-automation='link-continue']");
        
        public PreviewYourVacancyPage(ScenarioContext context) : base(context) { }

        public VacancyPreviewPart2Page PreviewVacancy()
        {
            Continue();
            return new VacancyPreviewPart2Page(_context);
        }
    }
}
