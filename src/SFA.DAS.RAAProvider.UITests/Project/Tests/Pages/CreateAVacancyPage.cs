using OpenQA.Selenium;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.Pages
{
    public class CreateAVacancyPage(ScenarioContext context) : RaaBasePage(context)
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
