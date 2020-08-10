using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortsWithEmployersPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice details with employer";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ProviderCohortsWithEmployersPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderViewYourCohortPage SelectViewCurrentCohortDetails()
        {
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            return new ProviderViewYourCohortPage(_context);
        }
}
}
