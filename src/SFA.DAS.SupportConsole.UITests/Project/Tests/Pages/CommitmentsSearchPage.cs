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
        private const string SearchTextBoxHelpTextContent = "Enter ULN number";

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
        private By SearchTextBox = By.Id("search-main");
        private By SearchButton => By.Id("searchButton");
        private By SearchTextBoxHelpText => By.Id("search-main");
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
            Assert.AreEqual(_pageInteractionHelper.GetText(SearchSectionHeader), SearchSectionHeaderText, "Search section header mismatch");
            Assert.AreEqual(_pageInteractionHelper.GetTextFromPlaceholderAttributeOfAnElement(SearchTextBoxHelpText), SearchTextBoxHelpTextContent, "Search Text Help text mismatch");
        }

        public UlnSearchResultsPage SearchForULN()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(UlnRadioButton, "UnlSearchType");
            _formCompletionHelper.EnterText(SearchTextBox, _config.SupportConsoleUln);
            _formCompletionHelper.Click(SearchButton);
            return new UlnSearchResultsPage(_context);
        }
    }
}