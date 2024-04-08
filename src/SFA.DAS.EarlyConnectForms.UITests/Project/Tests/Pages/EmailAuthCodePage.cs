using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class EmailAuthCodePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "Check your email";
        private static By EmailAuthCodeField => By.CssSelector("#authcode");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public EmailAuthCodePage EnterValidAuthCode()
        {
            formCompletionHelper.EnterText(EmailAuthCodeField, earlyConnectDataHelper.Email);
            formCompletionHelper.ClickElement(ContinueButton);
            return new EmailAuthCodePage(context);
        }
    }
}
