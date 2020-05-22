using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EmployerHelpPage : RegistrationBasePage
    {
        protected override string PageTitle => "Sign in to Apprenticeship Service Support SANDBOX";

        protected override By PageHeader => By.CssSelector(".title");

        public EmployerHelpPage(ScenarioContext context) : base(context)
        {
            tabHelper.SwitchToFrame();
            VerifyPage();
            tabHelper.SwitchToDefaultContent();
        }

    }
}