using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Mailinator.Service.Project.Tests.Pages
{
    internal class MailinatorInboxPage : MailinatorBasePage
    {
        protected override string PageTitle => "Public Messages";

        protected override bool TakeFullScreenShot => false;

        protected override By PageHeader => By.CssSelector("#inbox_pane");

        #region Locators
        private static By EmailSubjectField => By.CssSelector(".jambo_table tr .ng-binding");
        #endregion

        internal MailinatorInboxPage(ScenarioContext context) : base(context) { }

        internal MailinatorEmailPage OpenEmail()
        {
            formCompletionHelper.Click(EmailSubjectField);
            return new MailinatorEmailPage(context);
        }
    }
}
