using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public abstract class SupportConsoleBasePage : BasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly ObjectContext objectContext;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly SupportConsoleConfig config;
        protected readonly RegexHelper regexHelper;
        protected readonly TableRowHelper tableRowHelper;
        #endregion

        protected By OrganisationsMenuLink => By.LinkText("Organisations");
        protected By CommitmentsMenuLink => By.LinkText("Commitments");
        protected By FinanceLink => By.LinkText("Finance");
        protected By TeamMembersLink => By.LinkText("Team members");
        private By Heading => By.Id("no-logo");

        public SupportConsoleBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
            tableRowHelper = context.Get<TableRowHelper>();
            regexHelper = context.Get<RegexHelper>();
        }

        public void ClickFinanceMenuLink() => formCompletionHelper.Click(FinanceLink);
        
        public SearchHomePage GoToSearchHomePage()
        {
            formCompletionHelper.ClickElement(Heading);
            return new SearchHomePage(_context);
        }
    }
}