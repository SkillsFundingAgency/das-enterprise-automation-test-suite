using SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;
using NUnit.Framework;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Login.Service;

namespace SFA.DAS.SupportConsole.UITests.Project.Helpers
{
    public class StepsHelper
    {
        private readonly ScenarioContext _context;

        public StepsHelper(ScenarioContext context) => _context = context;

        public SearchHomePage Tier1LoginToSupportConsole() => LoginToSupportConsole(_context.GetUser<SupportConsoleTier1User>());
        
        public SearchHomePage Tier2LoginToSupportConsole() => LoginToSupportConsole(_context.GetUser<SupportConsoleTier2User>());

        public AccountOverviewPage SearchAndViewAccount() => new SearchHomePage(_context).SearchAndViewAccount();

        public UlnSearchResultsPage SearchForUln() => new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SearchForULN();

        public void SearchWithInvalidUln(bool WithSpecialChars)
        {
            var commitmentsSearchPage = new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SelectUlnSearchTypeRadioButton();

            Assert.AreEqual(commitmentsSearchPage.GetSearchTextBoxHelpText(), commitmentsSearchPage.UlnSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch in CommitmentsSearchPage");

            if (WithSpecialChars)
                commitmentsSearchPage.SearchWithInvalidULNWithSpecialChars();
            else
                commitmentsSearchPage.SearchWithInvalidULN();
        }

        public void SearchWithInvalidCohort(bool WithSpecialChars)
        {
            var commitmentsSearchPage = new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SelectCohortRefSearchTypeRadioButton();

            VerifyCohortSearchTextBoxHelpTextContent(commitmentsSearchPage);

            if (WithSpecialChars)
                commitmentsSearchPage.SearchWithInvalidCohortWithSpecialChars();
            else
                commitmentsSearchPage.SearchWithInvalidCohort();
        }

        public void SearchWithUnauthorisedCohortAccess()
        {
            var commitmentsSearchPage = new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SelectCohortRefSearchTypeRadioButton();

            VerifyCohortSearchTextBoxHelpTextContent(commitmentsSearchPage);
            
            commitmentsSearchPage.SearchWithUnauthorisedCohortAccess();
        }

        public CohortSummaryPage SearchForCohort() => new AccountOverviewPage(_context).ClickCommitmentsMenuLink().SearchForCohort();

        void VerifyCohortSearchTextBoxHelpTextContent(CommitmentsSearchPage commitmentsSearchPage) => Assert.AreEqual(commitmentsSearchPage.GetSearchTextBoxHelpText(), commitmentsSearchPage.CohortSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch in CommitmentsSearchPage");

        private SearchHomePage LoginToSupportConsole(LoginUser loginUser)
        {
            new IdamsPage(_context).LoginToAccess1Staff();

            return new SignInPage(_context).SignInWithValidDetails(loginUser);
        }
    }
}