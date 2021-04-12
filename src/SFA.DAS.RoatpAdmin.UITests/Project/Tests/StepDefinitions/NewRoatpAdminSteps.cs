using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NewRoatpAdminSteps
    {
        private readonly ScenarioContext _context;
        private StaffDashboardPage _staffDashboardPage;
        private RoatpAdminHomePage _roatpAdminHomePage;
        private readonly NewRoatpAdminStepsHelper _roatpAdminStepsHelper;

        public NewRoatpAdminSteps(ScenarioContext context)
        {
            _context = context;
            _roatpAdminStepsHelper = new NewRoatpAdminStepsHelper(_context);
        }

        [Given(@"the (Main provider) is already on the RoATP register as Active")]
        public void TheProviderIsAlreadyOnTheRoATPRegisterAsActive(string providerType)
        {
            VerifyProviderStatusAsActive(InitatesAnApplication(providerType).ChangeStatusToActive());
        }

        [Given(@"the (Main provider) is already on the RoATP register as Active But No Apprentice")]
        public void TheProviderIsAlreadyOnTheRoATPRegisterAsActiveButNoApprentice(string providerType)
        {
            VerifyProviderStatusAsActive(InitatesAnApplication(providerType).ChangeStatusToActiveButNoApprentice());
        }

        [Then(@"verify the provider is added to the register with Application determined date updated")]
        public void ThenVerifyTheProviderIsAddedToTheRegisterWithApplicationDeterminedDateUpdated()
        {
            _roatpAdminStepsHelper.SearchForATrainingProvider().SearchTrainingProviderByUkprn().VerifyApplicationDeterminedDate();
        }

        [Then(@"the admin can download list of apprenticeship training providers")]
        public void ThenTheAdminCanDownloadListOfApprenticeshipTrainingProviders() => _staffDashboardPage = new StaffDashboardPage(_context).DownloadTrainingProvider();

        [Then(@"the admin can download the application data")]
        public void ThenTheAdminCanDownloadTheApplicationData() => _staffDashboardPage = _staffDashboardPage.DownloadApplicationData().DownloadReport().ClickReturnToStaffDashBoard();

        [Then(@"the admin can download all current finance applications")]
        public void ThenTheAdminCanDownloadAllCurrentFinanceApplications() => _staffDashboardPage = _staffDashboardPage.AccessFinancialApplications().DownloadAllCurrentApplications().ClickReturnToStaffDashBoard();

        private ChangeStatusPage InitatesAnApplication(string providerType)
        {
            _roatpAdminHomePage = _roatpAdminStepsHelper.InitatesAnApplication(providerType);

            _roatpAdminHomePage.VerifyNewProviderHasBeenAdded();

            return _roatpAdminHomePage.SearchTrainingProviderByName().VerifyProviderStatusAsOnBoarding().ClickChangeStatusLink();
        }

        private void VerifyProviderStatusAsActive(ResultsFoundPage resultsFoundPage) => resultsFoundPage.VerifyProviderStatusAsActive();
    }
}