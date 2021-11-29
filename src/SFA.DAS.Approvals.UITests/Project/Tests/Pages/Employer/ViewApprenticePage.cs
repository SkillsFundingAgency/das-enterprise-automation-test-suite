using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ViewApprenticePage : ApprovalsBasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");
        protected override string PageTitle => "View apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ViewApprenticeLink => By.CssSelector("a.govuk-link.edit-apprentice");

        public ViewApprenticePage(ScenarioContext context) : base(context) => _context = context;

        public ViewApprenticeDetailsPage ClickViewApprenticeLink()
        {
            formCompletionHelper.ClickElement(ViewApprenticeLink);
            return new ViewApprenticeDetailsPage(_context);
        }
    }
}
