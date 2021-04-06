using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NewRoatpAdminSteps
    {
        private readonly ScenarioContext _context;
        private StaffDashboardPage _staffDashboardPage;

        public NewRoatpAdminSteps(ScenarioContext context) => _context = context;

        [Then(@"the admin can download list of apprenticeship training providers")]
        public void ThenTheAdminCanDownloadListOfApprenticeshipTrainingProviders() => _staffDashboardPage = new StaffDashboardPage(_context).DownloadTrainingProvider();

        [Then(@"the admin can download the application data")]
        public void ThenTheAdminCanDownloadTheApplicationData() => _staffDashboardPage = _staffDashboardPage.DownloadApplicationData().DownloadReport().ClickReturnToStaffDashBoard();

        [Then(@"the admin can download all current finance applications")]
        public void ThenTheAdminCanDownloadAllCurrentFinanceApplications() => _staffDashboardPage = _staffDashboardPage.AccessFinancialApplications().DownloadAllCurrentApplications().ClickReturnToStaffDashBoard();
    }
}