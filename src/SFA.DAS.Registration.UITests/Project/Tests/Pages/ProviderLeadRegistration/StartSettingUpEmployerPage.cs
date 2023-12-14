using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class StartSettingUpEmployerPage(ScenarioContext context) : ProviderLeadRegistrationBasePage(context)
    {
        protected override string PageTitle => "Invite employers to create an account";

        protected override By ContinueButton => By.CssSelector(".govuk-button--start");

        public EnterTheEmployerDetailsPage Start()
        {
            Continue();
            return new EnterTheEmployerDetailsPage(context);
        }
    }
}
