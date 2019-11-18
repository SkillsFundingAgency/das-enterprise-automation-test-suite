using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SFA.DAS.SupportConsole.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.SupportConsole.UITests.Project.Helpers
{
    public class StepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly SupportConsoleConfig _config;
        private readonly PageInteractionHelper _pageInteractionHelper;

        public StepsHelper(ScenarioContext context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
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

            var commitmentsSearchPage = new CommitmentsSearchPage(_context);
            Assert.AreEqual(_pageInteractionHelper.GetTextFromPlaceholderAttributeOfAnElement(commitmentsSearchPage.SearchTextBoxHelpText), CommitmentsSearchPage.UlnSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch in CommitmentsSearchPage");

            if (WithSpecialChars)
                commitmentsSearchPage.SearchWithInvalidULNWithSpecialChars();
            else
                commitmentsSearchPage.SearchWithInvalidULN();
        }

        public void SearchWithInvalidCohort(bool WithSpecialChars)
        {
            new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SelectCohortRefSearchTypeRadioButton();

            var commitmentsSearchPage = new CommitmentsSearchPage(_context);
            VerifyCohortSearchTextBoxHelpTextContent();

            if (WithSpecialChars)
                commitmentsSearchPage.SearchWithInvalidCohortWithSpecialChars();
            else
                commitmentsSearchPage.SearchWithInvalidCohort();
        }

        public void SearchWithUnauthorisedCohortAccess()
        {
            new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SelectCohortRefSearchTypeRadioButton();
            VerifyCohortSearchTextBoxHelpTextContent();
            new CommitmentsSearchPage(_context).SearchWithUnauthorisedCohortAccess();
        }

        public CohortSummaryPage SearchForCohort()
        {
            var accountOverviewPage = new AccountOverviewPage(_context);
            return accountOverviewPage.ClickCommitmentsMenuLink()
                .SearchForCohort();
        }

        void VerifyCohortSearchTextBoxHelpTextContent()
        {
            var commitmentsSearchPage = new CommitmentsSearchPage(_context);
            Assert.AreEqual(_pageInteractionHelper.GetTextFromPlaceholderAttributeOfAnElement(commitmentsSearchPage.SearchTextBoxHelpText), CommitmentsSearchPage.CohortSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch in CommitmentsSearchPage");
        }
    }
}