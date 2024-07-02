using OpenQA.Selenium;
using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class EmailAuthCodePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        private new readonly RetriveEmailOTPCodeHelper retriveEmailOTPCodeHelper = new RetriveEmailOTPCodeHelper();
        protected override string PageTitle => "Check your email";
        private static By EmailAuthCodeField => By.CssSelector("#authcode");
        protected override By ContinueButton => By.CssSelector("button[type='submit']");
        public WhatsYourNamePage EnterValidAuthCode()
        {
            formCompletionHelper.EnterText(EmailAuthCodeField, retriveEmailOTPCodeHelper.AuthCodes);
            formCompletionHelper.ClickElement(ContinueButton);
            return new WhatsYourNamePage(context);
        }
    }
}
