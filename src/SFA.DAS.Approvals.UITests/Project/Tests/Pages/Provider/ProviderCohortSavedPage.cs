using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortSavedPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Cohort saved but not sent";

        protected override By PageHeader => By.CssSelector(".green-box-alert");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderCohortSavedPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderReviewYourCohortPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTable("Details", objectContext.GetCohortReference());
            return new ProviderReviewYourCohortPage(_context);
        }
    }
}
