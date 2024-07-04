using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages
{
    public class ShortDescriptionPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Short description of the apprenticeship";

        private static By ShortDescription => By.Id("ShortDescription");

        public PreviewYourAdvertOrVacancyPage EnterBriefOverview()
        {
            formCompletionHelper.EnterText(ShortDescription, rAADataHelper.VacancyBriefOverview);
            Continue();
            return new PreviewYourAdvertOrVacancyPage(context);
        }
    }
}
