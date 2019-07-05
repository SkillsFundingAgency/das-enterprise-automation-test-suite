using System;
using ESFA.UI.Specflow.Framework.Helpers;
using ESFA.UI.Specflow.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.Pages
{
    public class SearchResultsPage : BasePage
    {
        private static String PAGE_TITLE = "";

        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _scenarioContext;

        public SearchResultsPage(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _pageInteractionHelper = scenarioContext.Get<PageInteractionHelper>();
            _formCompletionHelper = scenarioContext.Get<FormCompletionHelper>();
            SelfVerify();
        }

        protected override bool SelfVerify()
        {
            return _pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PAGE_TITLE);
        }

        private By dfeLink(string searchText) => By.LinkText(searchText);

        internal DepartmentForEducationHomePage ClickDfeLink(string searchText)
        {
            _formCompletionHelper.ClickElement(dfeLink(searchText));
            return new DepartmentForEducationHomePage(_scenarioContext);
        }
    }
}