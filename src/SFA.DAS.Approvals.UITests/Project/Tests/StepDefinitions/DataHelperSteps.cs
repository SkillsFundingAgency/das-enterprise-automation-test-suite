using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DataHelperSteps
    {
        private readonly EmployerPermissionsStepsHelper _employerPermissionsStepsHelper;
        
        private readonly ApprovalsConfig _approvalsConfig;

        private ProviderLogin _providerLogin;

        public DataHelperSteps(ScenarioContext context)
        {
            _approvalsConfig = context.GetApprovalsConfig<ApprovalsConfig>();
        }

        [Then(@"the Employer can set create cohort and recruitment permissions")]
        public void ThenTheEmployerCanSetCreateCohortAndRecruitmentPermissions()
        {
            _employerPermissionsStepsHelper.SetCreateCohortAndRecruitmentPermission(_approvalsConfig.AP_ProviderUkprn);
        }
    }
}
