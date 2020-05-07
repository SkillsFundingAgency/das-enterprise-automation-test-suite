using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class CommitmentsSearchPage : SupportConsoleBasePage
    {
        protected override string PageTitle => "Department for Education";
        public string SearchSectionHeaderText => "Search";
        public string UlnSearchTextBoxHelpTextContent => "Enter ULN number";
        public string CohortSearchTextBoxHelpTextContent => "Enter Cohort Reference number";
        public string InvalidUln => "1234567";
        public string InvalidUlnWithSpecialChars => "!£$%^&*()@?|#";
        public string InvalidCohort => "ABCD";
        public string InvalidCohortWithSpecialChars => "!£$%^&*()@?|#";
        public string UlnSearchErrorMessage => "Please enter a 10-digit unique learner number";
        public string CohortSearchErrorMessage => "Please enter a 6-digit Cohort number";
        public string UnauthorisedCohortSearchErrorMessage => "Account is unauthorised to access this Cohort.";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        private By SearchSectionHeader => By.XPath("(//h1)[2]");
        private By UlnRadioButton => By.CssSelector("label");
        private By CohortRefRadioButton => By.CssSelector("label");
        private By SearchTextBox => By.Id("search-main");
        private By SearchButton => By.Id("searchButton");
        public By SearchTextBoxHelpText => By.Id("search-main");
        public By CommitmentsSearchPageErrorText => By.CssSelector(".error-message");
        #endregion

        public CommitmentsSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage(SearchSectionHeader, SearchSectionHeaderText);
        }

        private void EnterTextInSearchBox(string searchText)
        {
            _formCompletionHelper.EnterText(SearchTextBox, searchText);
        }

        public CommitmentsSearchPage SelectUlnSearchTypeRadioButton()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(UlnRadioButton, "UnlSearchType");
            return this;
        }

        private void ClickSearchButton()
        {
            _formCompletionHelper.Click(SearchButton);
        }

        public UlnSearchResultsPage SearchForULN()
        {
            SelectUlnSearchTypeRadioButton();
            EnterTextInSearchBox(_config.Uln);
            ClickSearchButton();
            return new UlnSearchResultsPage(_context);
        }

        public void SearchWithInvalidULN()
        {
            EnterTextInSearchBox(InvalidUln);
            ClickSearchButton();
        }

        public void SearchWithInvalidULNWithSpecialChars()
        {
            EnterTextInSearchBox(InvalidUlnWithSpecialChars);
            ClickSearchButton();
        }

        public CohortSummaryPage SearchForCohort()
        {
            SelectCohortRefSearchTypeRadioButton();
            EnterTextInSearchBox(_config.CohortRef);
            ClickSearchButton();
            return new CohortSummaryPage(_context);
        }

        public CommitmentsSearchPage SelectCohortRefSearchTypeRadioButton()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(CohortRefRadioButton, "CohortSearchType");
            return this;
        }

        public void SearchWithInvalidCohort()
        {
            EnterTextInSearchBox(InvalidCohort);
            ClickSearchButton();
        }

        public void SearchWithUnauthorisedCohortAccess()
        {
            EnterTextInSearchBox(_config.CohortNotAssociatedToAccount);
            ClickSearchButton();
        }

        public void SearchWithInvalidCohortWithSpecialChars()
        {
            EnterTextInSearchBox(InvalidCohortWithSpecialChars);
            ClickSearchButton();
        }

        public string GetCommitmentsSearchPageErrorText()
        {
            return _pageInteractionHelper.GetText(CommitmentsSearchPageErrorText);
        }

        public string GetSearchTextBoxHelpText()
        {
            return _pageInteractionHelper.GetTextFromPlaceholderAttributeOfAnElement(SearchTextBoxHelpText);
        }
    }
}