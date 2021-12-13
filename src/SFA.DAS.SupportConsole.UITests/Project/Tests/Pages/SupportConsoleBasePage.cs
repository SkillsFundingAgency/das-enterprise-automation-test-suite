using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public abstract class SupportConsoleBasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly SupportConsoleConfig config;
        #endregion

        protected By OrganisationsMenuLink => By.LinkText("Organisations");
        protected By CommitmentsMenuLink => By.LinkText("Commitments");
        protected By FinanceLink => By.LinkText("Finance");
        protected By TeamMembersLink => By.LinkText("Team members");
        private By Heading => By.Id("no-logo");

        public SupportConsoleBasePage(ScenarioContext context) : base(context) => config = context.GetSupportConsoleConfig<SupportConsoleConfig>();

        public void ClickFinanceMenuLink() => formCompletionHelper.Click(FinanceLink);
        
        public SearchHomePage GoToSearchHomePage()
        {
            formCompletionHelper.ClickElement(Heading);
            return new SearchHomePage(_context);
        }
    }
}