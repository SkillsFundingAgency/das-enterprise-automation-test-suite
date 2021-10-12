using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ChangePasswordPage : RegistrationBasePage
    {
        protected override string PageTitle => "Change password";

        private readonly ScenarioContext _context;

        #region Locators
        private By CreateNewPasswordTextField => By.Id("Password");
        private By ConfirmNewPasswordTextField => By.Id("ConfirmPassword");
        protected override By ContinueButton => By.CssSelector(".button[type='submit']");
        #endregion

        public ChangePasswordPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public SignInPage ResetPassword()
        {
            var newPassword = registrationDataHelper.NewPassword;
            formCompletionHelper.EnterText(CreateNewPasswordTextField, newPassword);
            formCompletionHelper.EnterText(ConfirmNewPasswordTextField, newPassword);
            Continue();
            return new SignInPage(_context);
        }
    }
}
