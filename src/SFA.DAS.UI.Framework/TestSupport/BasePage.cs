using System;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class BasePage
    {
        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        protected virtual By PageHeader => By.CssSelector("h1");

        public BasePage(ScenarioContext context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        protected string GetPageHeading()
        {
            return _pageInteractionHelper.GetText(PageHeader);
        }

        protected bool IsPagePresented(string expected)
        {
            return GetPageHeading() == expected;
        }
    }
}