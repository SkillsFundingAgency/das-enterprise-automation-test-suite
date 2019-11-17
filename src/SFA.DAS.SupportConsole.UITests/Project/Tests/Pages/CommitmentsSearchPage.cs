using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using NUnit.Framework;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class CommitmentsSearchPage : BasePage
    {
        protected override string PageTitle => "Department for Education";
        private const string SearchSectionHeaderText = "Search";
        private const string UlnSearchTextBoxHelpTextContent = "Enter ULN number";
        private const string CohortSearchTextBoxHelpTextContent = "Enter Cohort Reference number";
        private const string InvalidUln = "1234567";
        private const string InvalidUlnWithSpecialChars = "!£$%^&*()@?|#";
        private const string InvalidCohort = "ABCD";
        private const string InvalidCohortWithSpecialChars = "!£$%^&*()@?|#";
        private const string UlnSearchErrorMessage = "Please enter a 10-digit unique learner number";
        private const string CohortSearchErrorMessage = "Please enter a 6-digit Cohort number";
        private const string UnauthorisedCohortSearchErrorMessage = "Account is unauthorised to access this Cohort.";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly SupportConsoleConfig _config;
        #endregion

        #region Locators
        protected override By PageHeader => By.CssSelector(".heading-large");
        private By SearchSectionHeader => By.XPath("(//h1)[2]");
        private By UlnRadioButton => By.CssSelector("label");
        private By CohortRefRadioButton => By.CssSelector("label");
        private By SearchTextBox => By.Id("search-main");
        private By SearchButton => By.Id("searchButton");
        private By SearchTextBoxHelpText => By.Id("search-main");
        private By CommitmentsSearchPageErrorText => By.CssSelector(".error-message");
        #endregion

        public CommitmentsSearchPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
            VerifyPage();
            VerifySearchSection();
        }

        private void VerifySearchSection()
        {
            Assert.AreEqual(_pageInteractionHelper.GetText(SearchSectionHeader), SearchSectionHeaderText, "Search section header mismatch in CommitmentsSearchPage");
        }

        private void EnterTextInSearchBox(string searchText)
        {
            _formCompletionHelper.EnterText(SearchTextBox, searchText);
        }

        public void SelectUlnSearchTypeRadioButton()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(UlnRadioButton, "UnlSearchType");
            Assert.AreEqual(_pageInteractionHelper.GetTextFromPlaceholderAttributeOfAnElement(SearchTextBoxHelpText), UlnSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch in CommitmentsSearchPage");
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

        public void VerifyUlnErrorMessage()
        {
            Assert.AreEqual(_pageInteractionHelper.GetText(CommitmentsSearchPageErrorText), UlnSearchErrorMessage, "Uln search Error message mismatch in CommitmentsSearchPage");
        }

        public void VerifyCohortErrorMessage()
        {
            Assert.AreEqual(_pageInteractionHelper.GetText(CommitmentsSearchPageErrorText), CohortSearchErrorMessage, "Cohort search Error message mismatch in CommitmentsSearchPage");
        }

        public void VerifyUnauthorisedCohortAccessErrorMessage()
        {
            Assert.AreEqual(_pageInteractionHelper.GetText(CommitmentsSearchPageErrorText), UnauthorisedCohortSearchErrorMessage, "Cohort search Error message mismatch in CommitmentsSearchPage");
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
            Assert.AreEqual(_pageInteractionHelper.GetTextFromPlaceholderAttributeOfAnElement(SearchTextBoxHelpText), CohortSearchTextBoxHelpTextContent, "Search Textbox Help text mismatch");
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