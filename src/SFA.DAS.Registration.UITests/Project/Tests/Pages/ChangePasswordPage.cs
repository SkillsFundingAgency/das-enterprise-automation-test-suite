using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project.Tests.Pages.StubPages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ChangePasswordPage : RegistrationBasePage
    {
        protected override string PageTitle => "Change password";

        #region Locators
        private By CreateNewPasswordTextField => By.Id("Password");
        private By ConfirmNewPasswordTextField => By.Id("ConfirmPassword");
        protected override By ContinueButton => By.CssSelector(".button[type='submit']");
        #endregion

        public ChangePasswordPage(ScenarioContext context) : base(context) => VerifyPage();

    }
}
