using System;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestProject.UITests.Project.Tests.Pages
{
    public class SearchResultsPage : BasePage
    {
        private static String PAGE_TITLE = "";

        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;

        public SearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
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
            return new DepartmentForEducationHomePage(_context);
        }
    }
}