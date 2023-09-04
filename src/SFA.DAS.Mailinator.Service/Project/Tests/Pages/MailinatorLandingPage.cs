using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Mailinator.Service.Project.Tests.Pages
{
    internal class MailinatorLandingPage : MailinatorBasePage
    {
        protected override string PageTitle => "Mailinator";

        protected override bool TakeFullScreenShot => false;

        protected override By PageHeader => By.CssSelector(".gel-heading-title");
        
        #region Locators
        private static By EmailTextBox => By.CssSelector("#search");
        private static By GoButton => By.CssSelector("#site-header button");
        #endregion

        internal MailinatorLandingPage(ScenarioContext context) : base(context, false) => VerifyPage(() => pageInteractionHelper.FindElements(PageHeader));

        internal MailinatorInboxPage EnterEmailAndClickOnGoButton(string organisationEmailAddress)
        {
            formCompletionHelper.EnterText(EmailTextBox, organisationEmailAddress);

            formCompletionHelper.ClickButtonByText(GoButton, "GO");

            return new MailinatorInboxPage(context);
        }
    }
}
