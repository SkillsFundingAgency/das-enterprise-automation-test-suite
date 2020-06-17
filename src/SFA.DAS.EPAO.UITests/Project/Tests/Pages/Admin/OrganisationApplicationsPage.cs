using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class OrganisationApplicationsPage : ApplicationBasePage
    {
        protected override string PageTitle => "Organisation applications";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OrganisationApplicationsPage(ScenarioContext context) : base(context) => _context = context;

        public OrganisationApplicationOverviewPage GoToNewOrganisationApplicationOverviewPage() => GoToOrganisationApplicationOverviewPage(NewTab);

        public OrganisationApplicationOverviewPage GoToInProgressOrganisationApplicationOverviewPage() => GoToOrganisationApplicationOverviewPage(InProgressTab);

        public OrganisationApplicationOverviewPage GoToApprovedOrganisationApplicationOverviewPage() => GoToOrganisationApplicationOverviewPage(ApprovedTab);

        private OrganisationApplicationOverviewPage GoToOrganisationApplicationOverviewPage(By by)
        {
            GoToApplicationOverviewPage(by);
            return new OrganisationApplicationOverviewPage(_context);
        }
    }
}