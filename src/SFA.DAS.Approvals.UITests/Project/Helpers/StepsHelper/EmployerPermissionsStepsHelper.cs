using System;
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

        public HomePage SetCreateCohortAndRecruitmentPermission(string ukprn)
        {
            return GoToSetProviderPermissionsPage(ukprn)
                .SetCreateCohortAndRecruitmentPermissions()
                .ConfirmTrainingProviderPermissions()
                .GoToHomePage();
        }

        public HomePage SetCreateCohortPermission(string ukprn)
        {
            return GoToSetProviderPermissionsPage(ukprn)
                .SetCreateCohortPermissions()
                .ConfirmTrainingProviderPermissions()
                .GoToHomePage();
        }

        public SetPermissionsPage GoToSetProviderPermissionsPage(string ukprn)
        {
            return OpenProviderPermissions()
                 .SelectAddANewTrainingProvider()
                 .SearchForATrainingProvider(ukprn)
                 .ConfirmTrainingProvider()
                 .SelectContinueInEmployerTrainingProviderAddedPage();
        }

        internal void UnSetCreateCohortPermission()
        {
                OpenProviderPermissions()
                .SelectSetPermissions()
                .UnSetCreateCohortPermissions()
                .ConfirmTrainingProviderPermissions()
                .GoToHomePage();
        }

        private TrainingProviderPermissionsPage OpenProviderPermissions()
        {
            return new TrainingProviderPermissionsHomePage(_context)
                    .OpenProviderPermissions();
        }
    }
}
