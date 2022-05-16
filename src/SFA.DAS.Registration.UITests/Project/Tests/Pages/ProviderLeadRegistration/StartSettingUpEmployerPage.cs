using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class StartSettingUpEmployerPage : ProviderLeadRegistrationBasePage
    {
        protected override string PageTitle => "Invite employers to create an account";

        protected override By ContinueButton => By.CssSelector(".govuk-button--start");

        public StartSettingUpEmployerPage(ScenarioContext context) : base(context) { }

        public EnterTheEmployerDetailsPage Start()
        {
            Continue();
            return new EnterTheEmployerDetailsPage(context);
        }
    }
}
