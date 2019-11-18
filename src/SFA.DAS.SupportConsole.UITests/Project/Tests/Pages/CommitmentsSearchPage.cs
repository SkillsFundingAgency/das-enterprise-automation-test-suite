using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class CommitmentsSearchPage : BasePage
    {
        protected override string PageTitle => "Department for Education";
        public const string SearchSectionHeaderText = "Search";
        public const string UlnSearchTextBoxHelpTextContent = "Enter ULN number";
        public const string CohortSearchTextBoxHelpTextContent = "Enter Cohort Reference number";
        public const string InvalidUln = "1234567";
        public const string InvalidUlnWithSpecialChars = "!£$%^&*()@?|#";
        public const string InvalidCohort = "ABCD";
        public const string InvalidCohortWithSpecialChars = "!£$%^&*()@?|#";
        public const string UlnSearchErrorMessage = "Please enter a 10-digit unique learner number";
        public const string CohortSearchErrorMessage = "Please enter a 6-digit Cohort number";
        public const string UnauthorisedCohortSearchErrorMessage = "Account is unauthorised to access this Cohort.";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly SupportConsoleConfig _config;
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
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
            VerifyPage(SearchSectionHeader, SearchSectionHeaderText); 
        }

        private void EnterTextInSearchBox(string searchText)
        {
            _formCompletionHelper.EnterText(SearchTextBox, searchText);
        }

        public void SelectUlnSearchTypeRadioButton()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(UlnRadioButton, "UnlSearchType");
        }

        private void ClickSearchButton()
        {
            _formCompletionHelper.Click(SearchButton);
        }

        public UlnSearchResultsPage SearchForULN()
        {
            SelectUlnSearchTypeRadioButton();
            EnterTextInSearchBox(_config.SupportConsoleUln);
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
            EnterTextInSearchBox(_config.SupportConsoleCohortRef);
            ClickSearchButton();
            return new CohortSummaryPage(_context);
        }

        public void SelectCohortRefSearchTypeRadioButton()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(CohortRefRadioButton, "CohortSearchType");
        }

        public void SearchWithInvalidCohort()
        {
            EnterTextInSearchBox(InvalidCohort);
            ClickSearchButton();
        }

        public void SearchWithUnauthorisedCohortAccess()
        {
            EnterTextInSearchBox(_config.SupportConsoleCohortNotAssociatedToAccount);
            ClickSearchButton();
        }

        public void SearchWithInvalidCohortWithSpecialChars()
        {
            EnterTextInSearchBox(InvalidCohortWithSpecialChars);
            ClickSearchButton();
        }
    }
}