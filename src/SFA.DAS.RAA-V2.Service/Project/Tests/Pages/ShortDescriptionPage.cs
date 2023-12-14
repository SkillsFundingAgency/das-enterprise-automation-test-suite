using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ShortDescriptionPage : Raav2BasePage
    {
        protected override string PageTitle => "Short description of the apprenticeship";

        private static By ShortDescription => By.Id("ShortDescription");

        public ShortDescriptionPage(ScenarioContext context) : base(context) { }

        public PreviewYourAdvertOrVacancyPage EnterBriefOverview()
        {
            formCompletionHelper.EnterText(ShortDescription, rAAV2DataHelper.VacancyBriefOverview);
            Continue();
            return new PreviewYourAdvertOrVacancyPage(context);
        }
    }
}
