using System;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using System.Linq;

namespace SFA.DAS.TestProject.UITests.Project.Tests.Pages
{
    public sealed class SearchResultsPage : TestProjectBasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly IWebDriver _webDriver;
        #endregion

        #region Page Object Elements

        private By DfeUrlLinks => By.CssSelector(".gem-c-document-list__item a");
        private IWebElement FindDfeUrlElement(string searchText)
        {
            return _webDriver.FindElements(DfeUrlLinks).ToList().First(x => x.Text == searchText);
        }
        #endregion

        protected override string PageTitle => "";

        public SearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _webDriver = context.GetWebDriver();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal HomePage OpenDesiredPage(string searchText)
        {
            _formCompletionHelper.ClickElement(FindDfeUrlElement(searchText));
            return new HomePage(_context);
        }
    }
}