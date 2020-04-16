using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.ProviderLeadRegistration
{
    public class StartSettingUpEmployerPage : ProviderLeadRegistrationBasePage
    {
        protected override string PageTitle => "Start setting up an account for an employer";

        private readonly ScenarioContext _context;

        protected override By ContinueButton => By.CssSelector(".govuk-button--start");

        public StartSettingUpEmployerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EnterTheEmployerDetailsPage Start()
        {
            Continue();
            return new EnterTheEmployerDetailsPage(_context);
        }
    }
}
