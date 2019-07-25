using System;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.TestProject.UITests.Project.Tests.Pages
{
    public sealed class SearchResultsPage : BasePage
    {
        private const string PageTitle = "";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        #region Page Object Elements
        private By DfeUrl(string searchText) => By.LinkText(searchText);
#endregion 

        public SearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage(PageTitle);
        }

        internal HomePage OpenDesiredPage(string searchText)
        {
            _formCompletionHelper.ClickElement(DfeUrl(searchText));
            return new HomePage(_context);
        }
    }
}