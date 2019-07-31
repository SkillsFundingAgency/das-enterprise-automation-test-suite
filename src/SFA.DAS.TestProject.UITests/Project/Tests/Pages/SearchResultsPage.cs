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
            By DfeNextPageLink() => By.CssSelector(".gem-c-pagination__item gem-c-pagination__item--next a");

            int pagenumber = 0;
            IWebElement link = null;
            do
            {
                pagenumber++;
                link = _webDriver.FindElements(DfeUrlLinks).ToList().FirstOrDefault(x => x.Text == searchText);
                if (link != null) break;
                _formCompletionHelper.ClickElement(DfeNextPageLink());
            } while (pagenumber <= 10 || link == null);

            return link;
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