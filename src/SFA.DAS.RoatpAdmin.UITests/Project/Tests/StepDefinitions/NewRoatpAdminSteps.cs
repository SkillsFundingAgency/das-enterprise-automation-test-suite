using SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;
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
        private MiniDashboardPage _miniDashboardPage;
        private readonly NewRoatpAdminStepsHelper _roatpAdminStepsHelper;

        public NewRoatpAdminSteps(ScenarioContext context)
        {
            _context = context;
            _roatpAdminStepsHelper = new NewRoatpAdminStepsHelper(_context);
        }

        [Given(@"the (Main provider|Employer provider) is already on the RoATP register as Active")]
        public void TheProviderIsAlreadyOnTheRoATPRegisterAsActive(string providerType)
        {
            var successPage = InitatesAnApplication(providerType).ChangeStatusToActive();
            VerifyProviderStatusAsActive(successPage);
        }

        [Given(@"the (Main provider) is already on the RoATP register as Active But No Apprentice")]
        public void TheProviderIsAlreadyOnTheRoATPRegisterAsActiveButNoApprentice(string providerType)
        {
            var successPage = InitatesAnApplication(providerType).ChangeStatusToActiveButNoApprentice();
            VerifyProviderStatusAsActive(successPage);
        }

        [Then(@"verify the provider is added to the register with Application determined date updated")]
        public void ThenVerifyTheProviderIsAddedToTheRegisterWithApplicationDeterminedDateUpdated()
        {
            _roatpAdminStepsHelper.SearchForATrainingProvider().SearchTrainingProviderByUkprn().VerifyApplicationDeterminedDate();
        }

        [Then(@"verify the provider Application determined date is not updated")]
        public void ThenVerifyTheProviderApplicationDeterminedDateIsNotUpdated()
        {
            _roatpAdminStepsHelper.SearchForATrainingProvider().SearchTrainingProviderByUkprn().VerifyApplicationDeterminedDateNotUpdated();
        }

        [Then(@"the admin can download list of apprenticeship training providers")]
        public void ThenTheAdminCanDownloadListOfApprenticeshipTrainingProviders() => _staffDashboardPage = new StaffDashboardPage(_context).DownloadTrainingProvider();

        [Then(@"the admin can download the application data")]
        public void ThenTheAdminCanDownloadTheApplicationData() => _staffDashboardPage = _staffDashboardPage.DownloadApplicationData().DownloadReport().ClickReturnToStaffDashBoard();

        [Then(@"the admin can download all current finance applications")]
        public void ThenTheAdminCanDownloadAllCurrentFinanceApplications() => _staffDashboardPage = _staffDashboardPage.AccessFinancialApplications().DownloadAllCurrentApplications().ClickReturnToStaffDashBoard();

        private ChangeStatusPage InitatesAnApplication(string providerType)
        {
            var searchPage = _roatpAdminStepsHelper.InitatesAnApplication(providerType)
                .SearchForTrainingProvider()
                .SearchTrainingProviderByName()
                .ClickChangeStatusLink();
            return searchPage;
        }

        private static void VerifyProviderStatusAsActive(SuccessPage successPage) => successPage.VerifyProviderStatusUpdated();
    }
}