using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    class ProviderViewApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "View apprentice details";

        private By ReturnToCohortViewLink => By.LinkText("Return to cohort view");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderViewApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderViewYourCohortPage SelectReturnToCohortView()
        {
            formCompletionHelper.ClickElement(ReturnToCohortViewLink);
            return new ProviderViewYourCohortPage(_context);
        }
    }
}
