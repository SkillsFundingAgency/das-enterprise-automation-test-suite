using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ProviderLogin.Service;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DataHelperSteps
    {
        private readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper;
        
        private readonly ProviderConfig _config;

        public DataHelperSteps(ScenarioContext context)
        {
            _config = context.GetProviderConfig<ProviderConfig>();
            _employerPermissionsStepsHelper = new EmployerPermissionsStepsHelper(context);
        }

        [Then(@"the Employer can set create cohort and recruitment permissions")]
        public void ThenTheEmployerCanSetCreateCohortAndRecruitmentPermissions()
        {
            _employerPermissionsStepsHelper.SetCreateCohortAndRecruitmentPermission(_config.Ukprn);
        }
    }
}
