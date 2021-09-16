using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EmailAddressPage : RegistrationBasePage
    {
        protected override string PageTitle => "Email address";
        private readonly ScenarioContext _context;

        #region Locators
        private By EmailAddressTextField = By.Id("Email");
        private By ContinueButton = By.Id("forgottenpassword-button");
        #endregion

        public EmailAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EnterYourResetCodePage EnterResetCode()
        {
            formCompletionHelper.EnterText(EmailAddressTextField, objectContext.GetRegisteredEmail());
            formCompletionHelper.ClickElement(ContinueButton);
            return new EnterYourResetCodePage(_context);
        }
    }
}
