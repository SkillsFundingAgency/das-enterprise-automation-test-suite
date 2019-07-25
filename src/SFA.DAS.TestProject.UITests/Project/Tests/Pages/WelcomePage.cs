using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestProject.UITests.Project.Tests.Pages
{
    public sealed class WelcomePage : BasePage
    {
        #region constants
        private const string PageTitle = "Welcome to GOV.UK";
        #endregion

        #region Context and Helpers
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _scenarioContext;
        #endregion

        #region Page Object Elements
        private readonly By _searchField = By.Name("q");
        private readonly By _searchButton = By.CssSelector(".gem-c-search__submit");
#endregion

        public WelcomePage(ScenarioContext context) : base(context)
        {
            _scenarioContext = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();                            
            VerifyPage();
        }

        protected override bool VerifyPage()
        {
            return _pageInteractionHelper.VerifyPage(this.GetPageHeading(), PageTitle);
        }       

        internal SearchResultsPage EnterSearchTextAndSubmit(string searchText)
        {
            _formCompletionHelper.EnterText(_searchField, searchText);
            _formCompletionHelper.ClickElement(_searchButton);
            return new SearchResultsPage(_scenarioContext);
        }
    }
}