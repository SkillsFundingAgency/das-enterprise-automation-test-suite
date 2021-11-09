using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderChooseACohortPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Choose a cohort";

        private By CohortsTable => By.CssSelector(".govuk-table__row");


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderChooseACohortPage(ScenarioContext context) : base(context) => _context = context;

        public int? GetDataRowsCount() => pageInteractionHelper.FindElements(CohortsTable).Count - 1;

        public ProviderApproveApprenticeDetailsPage SelectCohort(string cohortReference)
        {            
            javaScriptHelper.ScrollToTheBottom();
            tableRowHelper.SelectRowFromTableDescending("Select", cohortReference);
            return new ProviderApproveApprenticeDetailsPage(_context);
        }
    }
}
