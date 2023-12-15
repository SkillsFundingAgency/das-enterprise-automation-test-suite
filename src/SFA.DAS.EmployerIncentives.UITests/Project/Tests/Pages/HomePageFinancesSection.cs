using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection_EI(ScenarioContext context) : HomePage(context)
    {
        private static By EIHubLink => By.LinkText("Your hire a new apprentice payments");

        public EIHubPage NavigateToEIHubPage()
        {
            ClickEIHubLink();
            return new EIHubPage(context);
        }

        private void ClickEIHubLink() => formCompletionHelper.Click(EIHubLink);
    }
}
