using OpenQA.Selenium;
using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class EmailAuthCodePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        private new readonly RetriveEmailOTPCodeHelper retriveEmailOTPCodeHelper = new(context);
        protected override string PageTitle => "Check your email";
        private static By EmailAuthCodeField => By.CssSelector("#authcode");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        private static By EmailAuthCodeErrorSummary => By.CssSelector(".govuk-error-summary__title");

        public WhatsYourNamePage EnterValidAuthCode()
        {
            formCompletionHelper.EnterText(EmailAuthCodeField, retriveEmailOTPCodeHelper.GetOPT());
            formCompletionHelper.ClickElement(ContinueButton);
            return new WhatsYourNamePage(context);
        }

        public AlreadyCompletedFormPage EnterValidAuthCodeForUsedEmail()
        {
            formCompletionHelper.EnterText(EmailAuthCodeField, retriveEmailOTPCodeHelper.GetOPT());
            formCompletionHelper.ClickElement(ContinueButton);
            return new AlreadyCompletedFormPage(context);
        }

        public void EnterInvalidAuthCode()
        {
            formCompletionHelper.EnterText(EmailAuthCodeField, "11122");
            formCompletionHelper.ClickElement(ContinueButton);
        }

        public EmailAuthCodePage VerifyInvalidAuthCodeDisplaysError()
        {
            if (pageInteractionHelper.IsElementDisplayed(EmailAuthCodeErrorSummary)) throw new Exception("Auth Code Error Does Not Display Error Summary");
            return this;
        }
    }
}
