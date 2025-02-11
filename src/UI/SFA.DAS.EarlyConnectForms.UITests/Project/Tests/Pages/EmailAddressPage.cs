using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class EmailAddressPage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "What is your email address?";

        private static By EmailAddressField => By.CssSelector("#email");

        protected override By ContinueButton => By.CssSelector("button[type='submit']");

        public EmailAuthCodePage EnterNewEmailAddress()
        {
            formCompletionHelper.EnterText(EmailAddressField, earlyConnectDataHelper.Email);

            Continue();

            return new EmailAuthCodePage(context);
        }
    }
}
