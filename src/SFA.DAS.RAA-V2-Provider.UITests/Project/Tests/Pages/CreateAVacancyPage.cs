using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class CreateAVacancyPage : Raav2BasePage
    {
        protected override string PageTitle => "Create a vacancy";

        protected override By ContinueButton => By.CssSelector("[data-automation='create-vacancy']");

        public CreateAVacancyPage(ScenarioContext context) : base(context) { }

        public SelectEmployersPage StartNow()
        {
            Continue();
            return new SelectEmployersPage(context);
        }
    }
}
