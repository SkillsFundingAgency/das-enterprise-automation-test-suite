using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public abstract class SupportConsoleBasePage : BasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly FormCompletionHelper _formCompletionHelper;
        protected readonly PageInteractionHelper _pageInteractionHelper;
        protected readonly SupportConsoleConfig _config;
        protected readonly RegexHelper _regexHelper;
        protected readonly TableRowHelper _tableRowHelper;
        #endregion

        protected By OrganisationsMenuLink => By.LinkText("Organisations");
        protected By CommitmentsMenuLink => By.LinkText("Commitments");
        protected By FinanceLink => By.LinkText("Finance");
        protected By TeamMembersLink => By.LinkText("Team members");

        public SupportConsoleBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
            _tableRowHelper = context.Get<TableRowHelper>();
            _regexHelper = context.Get<RegexHelper>();
        }

        public void ClickFinanceMenuLink() => _formCompletionHelper.Click(FinanceLink);       
    }
}