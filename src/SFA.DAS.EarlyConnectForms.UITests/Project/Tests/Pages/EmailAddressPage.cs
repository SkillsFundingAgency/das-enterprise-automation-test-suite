using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages
{
    public class EmailAddressPage(ScenarioContext context) : EarlyConnectVerifyLinks(context)
    {
        protected override string PageTitle => "What is your email address?";
        private static By EmailAddressField => By.CssSelector("#email");
        protected override By ContinueButton => By.CssSelector("#fiu-app-menu-link-3");
        public EmailAddressPage EnterNewEmailAddress()
        {
            formCompletionHelper.EnterText(EmailAddressField, earlyConnectDataHelper.Email);
            formCompletionHelper.ClickElement(ContinueButton);
            return new EmailAddressPage(context);
        }
    }
}
