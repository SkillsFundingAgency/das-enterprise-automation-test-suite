using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class PerfTestProviderPermissionsSteps
    {
        private readonly PerfTestProviderPermissionsConfig _perfTestProviderPermissionsConfig;
        private readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper;

        public PerfTestProviderPermissionsSteps(ScenarioContext context)
        {
            _perfTestProviderPermissionsConfig = context.GetPerfTestProviderPermissionsConfig<PerfTestProviderPermissionsConfig>();
            _employerPermissionsStepsHelper = new EmployerPermissionsStepsHelper(context);
        }

        [Then(@"create cohort permission is granted to a provider")]
        public void ThenCreateCohortPermissionIsGrantedToAProvider() => _employerPermissionsStepsHelper.SetCreateCohortPermission(_perfTestProviderPermissionsConfig.Ukprn);
    }
}