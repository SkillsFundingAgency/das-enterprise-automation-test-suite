using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class PasswordResetCodePage : RegistrationBasePage
    {
        protected override string PageTitle => "Password reset code";

        #region Locators
        protected override By ContinueButton => By.LinkText("Continue");
        #endregion

        public PasswordResetCodePage(ScenarioContext context) : base(context) => VerifyPage();

    }
}
