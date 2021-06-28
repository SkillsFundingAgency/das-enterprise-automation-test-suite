using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class StandardApplicationsPage : ApplicationBasePage
    {
        protected override string PageTitle => "Standard applications";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public StandardApplicationsPage(ScenarioContext context) : base(context) => _context = context;

        public StandardApplicationOverviewPage GoToNewStandardApplicationOverviewPage() => GoToStandardApplicationOverviewPage(NewTab);

        public StandardApplicationOverviewPage GoToInProgressStandardApplicationOverviewPage() => GoToStandardApplicationOverviewPage(InProgressTab);

        public StandardApplicationOverviewPage GoToApprovedStandardApplicationOverviewPage() => GoToStandardApplicationOverviewPage(ApprovedTab);

        private StandardApplicationOverviewPage GoToStandardApplicationOverviewPage(By by)
        {
            GoToApplicationOverviewPage(by);
            return new StandardApplicationOverviewPage(_context);
        }
    }
}