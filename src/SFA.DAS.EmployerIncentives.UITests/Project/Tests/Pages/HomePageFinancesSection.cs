using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class HomePageFinancesSection_EI : HomePage
    {
        private By EIHubLink => By.LinkText("Your hire a new apprentice payments");

        public HomePageFinancesSection_EI(ScenarioContext context) : base(context) { }

        public EIAccessDeniedPage AccessEIHubLinkRedirectsToAccessDeniedPage()
        {
            ClickEIHubLink();
            return new EIAccessDeniedPage(context);
        }

        public EIHubPage NavigateToEIHubPage()
        {
            ClickEIHubLink();
            return new EIHubPage(context);
        }

        public ChooseOrganisationPage NavigateToChooseOrgPage()
        {
            ClickEIHubLink();
            return new ChooseOrganisationPage(context);
        }

        private void ClickEIHubLink() => formCompletionHelper.Click(EIHubLink);
    }
}
