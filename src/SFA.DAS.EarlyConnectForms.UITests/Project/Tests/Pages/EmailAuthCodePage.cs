using OpenQA.Selenium;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class EmailAuthCodePage(ScenarioContext context) : EarlyConnectBasePage(context)
    {
        protected override string PageTitle => "Check your email";

        private static By EmailAuthCodeField => By.CssSelector("#authcode");

        protected override By ContinueButton => By.CssSelector("button[type='submit']");

        public WhatsYourNamePage EnterValidAuthCode()
        {
            var code = context.Get<MailosaurApiHelper>().GetCodeInEmail(earlyConnectDataHelper.Email, "Confirm your email address – Department for education", "Your confirmation code is:");

            formCompletionHelper.EnterText(EmailAuthCodeField, code);

            Continue();

            return new WhatsYourNamePage(context);
        }
    }
}
