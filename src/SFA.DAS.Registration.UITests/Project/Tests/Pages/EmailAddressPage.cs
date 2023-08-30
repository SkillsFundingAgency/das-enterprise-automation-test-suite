using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EmailAddressPage : RegistrationBasePage
    {
        protected override string PageTitle => "Email address";

        #region Locators
        private static By EmailAddressTextField => By.Id("Email");
        protected override By ContinueButton => By.Id("forgottenpassword-button");
        #endregion

        public EmailAddressPage(ScenarioContext context) : base(context) => VerifyPage();

    }
}
