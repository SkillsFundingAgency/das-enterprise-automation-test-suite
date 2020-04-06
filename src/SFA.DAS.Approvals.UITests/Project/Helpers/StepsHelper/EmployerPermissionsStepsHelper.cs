using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    internal class EmployerPermissionsStepsHelper
    {
        private readonly ScenarioContext _context;

        public EmployerPermissionsStepsHelper(ScenarioContext context)
        {
            _context = context;
        }

        public HomePage SetCreateCohortPermission(string ukprn)
        {
            return GoToSetProviderPermissionsPage(ukprn)
                  .GoToHomePage();
        }

        public PermissionsUpdatedPage GoToSetProviderPermissionsPage(string ukprn)
        {
            return OpenProviderPermissions()
                 .SelectAddANewTrainingProvider()
                 .SearchForATrainingProvider(ukprn)
                 .ConfirmTrainingProvider()
                 .SelectContinueInEmployerTrainingProviderAddedPage()
                 .ClickYesToAddApprenticeRecords()
                 .ClickYesToAddRecruitApprentice()
                 .ConfirmTrainingProviderPermissions();
        }
        public PermissionsUpdatedPage UnSetCreateCohortPermission()
        {
            return OpenProviderPermissions()
                   .SelectChangePermissions()
                   .ClickNOToAddApprenticeRecords()
                   .ClickNoToAddRecruitApprentice()
                   .ConfirmTrainingProviderPermissions();
        }
        private YourTrainingProvidersPage OpenProviderPermissions()
        {
            return new TrainingProviderPermissionsHomePage(_context)
                    .OpenProviderPermissions();
        }              
    }
}