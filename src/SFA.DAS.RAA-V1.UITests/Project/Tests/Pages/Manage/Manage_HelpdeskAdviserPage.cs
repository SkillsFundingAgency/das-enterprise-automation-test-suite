using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_HelpdeskAdviserPage : Manage_HeaderSectionBasePage
    {
        protected override string PageTitle => "Search for candidate";

        protected override By PageHeader => By.CssSelector(".heading-medium");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        
        public Manage_HelpdeskAdviserPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public Manage_SearchForACandidatePage SearchForACandidate()
        {
            formCompletionHelper.ClickButtonByText("Search for candidate");
            return new Manage_SearchForACandidatePage(_context);
        }
    }
}
