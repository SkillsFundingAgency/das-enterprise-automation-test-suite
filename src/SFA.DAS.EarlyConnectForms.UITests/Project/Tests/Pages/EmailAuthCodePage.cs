using OpenQA.Selenium;
using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using System.Threading;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class EmailAuthCodePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        //private RetriveEmailOTPCodeHelper _emailOTPCodeHelper;
        protected override string PageTitle => "Check your email";
        private static By EmailAuthCodeField => By.CssSelector("#authcode");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public WhatsYourNamePage EnterValidAuthCode(string code)
        {
            Thread.Sleep(20000);
            formCompletionHelper.EnterText(EmailAuthCodeField, code);
            formCompletionHelper.ClickElement(ContinueButton);
            return new WhatsYourNamePage(context);
        }
    }
}
