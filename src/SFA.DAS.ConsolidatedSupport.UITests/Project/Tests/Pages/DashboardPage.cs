using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Tests.Pages
{
    public class DashboardPage : ConsolidatedSupportBasePage
    {
        protected override By PageHeader => By.CssSelector("#main_navigation");
        protected override string PageTitle { get; }

        private readonly ScenarioContext _context;

        private By BrandingHeader => By.CssSelector("#branding_header");

        private By SearchIcon => By.CssSelector("[data-test-id='header-toolbar-search-button'] svg");

        private By SearchInput => By.CssSelector("[data-test-id='header-toolbar-search-button'] input");

        private By Indicators => By.CssSelector(".indicators");

        private By TicketTable => By.CssSelector("[data-test-id='table_container'] table");

        private By HomeButton => By.CssSelector("#main_navigation [data-original-title='Home']");

        public DashboardPage(ScenarioContext context, bool navigateTo = false) : base(context)
        {
            _context = context;

            if (navigateTo) { formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(HomeButton)); }
            
            VerifyPage(PageHeader);
            VerifyPage(BrandingHeader);
            VerifyPage(Indicators);
            VerifyPage(TicketTable);
        }

        public TicketPage SearchTicket()
        {
            pageInteractionHelper.InvokeAction(() =>
            {
                formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SearchIcon));
                formCompletionHelper.EnterText(SearchInput, objectContext.GetTicketId());
                formCompletionHelper.SendKeys(SearchInput, Keys.Enter);
            });

            return new TicketPage(_context);
        }
    }
}
