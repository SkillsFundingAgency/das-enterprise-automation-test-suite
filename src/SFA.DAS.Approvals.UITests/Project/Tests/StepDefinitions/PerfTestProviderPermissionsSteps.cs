using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class PerfTestProviderPermissionsSteps(ScenarioContext context)
    {
        private readonly PerfTestProviderPermissionsConfig _perfTestProviderPermissionsConfig = context.GetPerfTestProviderPermissionsConfig<PerfTestProviderPermissionsConfig>();
        private readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper = new(context);

        [Then(@"create cohort permission is granted to a provider")]
        public void ThenCreateCohortPermissionIsGrantedToAProvider() => _employerPermissionsStepsHelper.SetCreateCohortPermission(_perfTestProviderPermissionsConfig.Ukprn);
    }
}