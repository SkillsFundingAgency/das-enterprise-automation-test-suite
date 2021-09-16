using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class PasswordResetCodePage : RegistrationBasePage
    {
        protected override string PageTitle => "Password reset code";
        private readonly ScenarioContext _context;

        #region Locators
        private By ContinueButton = By.LinkText("Continue");
        #endregion

        public PasswordResetCodePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EmailAddressPage EnterEmailToReset()
        {
            formCompletionHelper.ClickElement(ContinueButton);
            return new EmailAddressPage(_context);
        }
    }
}
