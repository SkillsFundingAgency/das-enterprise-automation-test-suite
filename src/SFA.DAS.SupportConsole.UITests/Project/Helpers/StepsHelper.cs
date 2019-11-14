using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Helpers
{
    public class StepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly SupportConsoleConfig _config;

        public StepsHelper(ScenarioContext context)
        {
            _context = context;
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
        }

        public SearchHomePage LoginToSupportConsole()
        {
            var idamsPage = new IdamsPage(_context);
            return idamsPage.ClickAccessStaff1Link()
                .SignInWithValidDetails();
        }

        public AccountOverviewPage SearchAndViewAccount()
        {
            var searchHomePage = new SearchHomePage(_context);
            return searchHomePage.SearchAndViewAccount();
        }

        public UlnSearchResultsPage SearchForUln()
        {
            var accountOverviewPage = new AccountOverviewPage(_context);
            return accountOverviewPage.ClickCommitmentsMenuLink()
                .SearchForULN();
        }
    }
}