using System;
using ESFA.UI.Specflow.Framework.Helpers;
using ESFA.UI.Specflow.Framework.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    public class WelcomeToGovUkPage : BasePage
    {
        private static String PAGE_TITLE = "Welcome to GOV.UK";

        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _scenarioContext;

        public WelcomeToGovUkPage(ScenarioContext context) : base(context)
        {
            _scenarioContext = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return _pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private By searchField = By.Name("q");
        private By searchButton = By.CssSelector(".gem-c-search__submit");

        internal SearchResultsPage EnterSearchTextAndSubmit(String searchText)
        {
            _formCompletionHelper.EnterText(searchField, searchText);
            _formCompletionHelper.ClickElement(searchButton);
            return new SearchResultsPage(_scenarioContext);
        }
    }
}