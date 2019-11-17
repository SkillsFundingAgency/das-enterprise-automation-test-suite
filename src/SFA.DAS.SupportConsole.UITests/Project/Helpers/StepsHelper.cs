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
            return new SearchHomePage(_context).SearchAndViewAccount();
        }

        public UlnSearchResultsPage SearchForUln()
        {
            var accountOverviewPage = new AccountOverviewPage(_context);
            return accountOverviewPage.ClickCommitmentsMenuLink()
                .SearchForULN();
        }

        public void SearchWithInvalidUln(bool WithSpecialChars)
        {
            new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SelectUlnSearchTypeRadioButton();

            if (WithSpecialChars)
                new CommitmentsSearchPage(_context).SearchWithInvalidCohortWithSpecialChars();
            else
                new CommitmentsSearchPage(_context).SearchWithInvalidULN();
        }

        public void SearchWithInvalidCohort(bool WithSpecialChars)
        {
            new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SelectCohortRefSearchTypeRadioButton();

            if (WithSpecialChars)
                new CommitmentsSearchPage(_context).SearchWithInvalidCohortWithSpecialChars();
            else
                new CommitmentsSearchPage(_context).SearchWithInvalidCohort();
        }

        public void SearchWithUnauthorisedCohortAccess()
        {
            new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SelectCohortRefSearchTypeRadioButton();
            new CommitmentsSearchPage(_context).SearchWithUnauthorisedCohortAccess();
        }

        public CohortSummaryPage SearchForCohort()
        {
            var accountOverviewPage = new AccountOverviewPage(_context);
            return accountOverviewPage.ClickCommitmentsMenuLink()
                .SearchForCohort();
        }
    }
}