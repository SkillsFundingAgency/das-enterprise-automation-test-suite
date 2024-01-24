using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAT_Provider.UITests.Project.Tests.Pages
{
    public class CreateAVacancyPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "Create a vacancy";

        protected override By ContinueButton => By.CssSelector("[data-automation='create-vacancy']");

        public SelectEmployersPage StartNow()
        {
            Continue();
            return new SelectEmployersPage(context);
        }
    }
}
