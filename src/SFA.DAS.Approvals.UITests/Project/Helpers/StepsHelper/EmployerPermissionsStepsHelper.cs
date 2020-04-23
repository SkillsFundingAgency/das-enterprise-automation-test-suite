using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    internal class EmployerPermissionsStepsHelper
    {
        private readonly ScenarioContext _context;

        public EmployerPermissionsStepsHelper(ScenarioContext context) => _context = context;

        public HomePage SetCreateCohortPermission(string ukprn) 
        {
            return OpenProviderPermissions()
                 .SelectAddANewTrainingProvider()
                 .SearchForATrainingProvider(ukprn)
                 .ConfirmTrainingProvider()
                 .SelectContinueInEmployerTrainingProviderAddedPage()
                 .SelectSetPermissions()
                 .ClickYesToAddApprenticeRecords()
                 .ClickYesToAddRecruitApprentice()
                 .ConfirmTrainingProviderPermissions()
                 .GoToHomePage();
        }

        public PermissionsUpdatedPage UnSetCreateCohortPermission()
        {
            return OpenProviderPermissions()
                   .SelectChangePermissions()
                   .ClickNoToAddApprenticeRecords()
                   .ClickNoToAddRecruitApprentice()
                   .ConfirmTrainingProviderPermissions();
        }

        private YourTrainingProvidersPage OpenProviderPermissions() => new YourTrainingProvidersLinkHomePage(_context).OpenProviderPermissions();
    }
}