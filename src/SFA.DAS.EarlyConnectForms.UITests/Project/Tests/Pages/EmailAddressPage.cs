using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class EmailAddressPage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What is your email address?";
        private string EmailAddress => earlyConnectDataHelper.Email;
        private static By EmailAddressField => By.CssSelector("#email");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");

        public EmailAuthCodePage EnterNewEmailAddress()
        {
            formCompletionHelper.EnterText(EmailAddressField, EmailAddress);
            formCompletionHelper.ClickElement(ContinueButton);
            return new EmailAuthCodePage(context);
        }

        public EmailAuthCodePage EnterAlreadyUsedEmailAddress()
        {
            formCompletionHelper.EnterText(EmailAddressField, EmailAddress);
            formCompletionHelper.ClickElement(ContinueButton);
            return new EmailAuthCodePage(context);
        }
    }
}
