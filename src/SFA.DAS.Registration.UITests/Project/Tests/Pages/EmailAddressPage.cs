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
        
        #region Locators
        private By EmailAddressTextField => By.Id("Email");
        protected override By ContinueButton => By.Id("forgottenpassword-button");
        #endregion

        public EmailAddressPage(ScenarioContext context) : base(context) => VerifyPage();

        public EnterYourResetCodePage EnterResetCode()
        {
            formCompletionHelper.EnterText(EmailAddressTextField, objectContext.GetRegisteredEmail());
            Continue();
            return new EnterYourResetCodePage(_context);
        }
    }
}
