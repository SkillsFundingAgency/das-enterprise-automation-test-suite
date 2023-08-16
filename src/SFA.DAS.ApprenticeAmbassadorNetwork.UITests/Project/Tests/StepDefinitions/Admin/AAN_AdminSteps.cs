using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.EsfaAdmin.Service.Project;
using SFA.DAS.EsfaAdmin.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin
{
    [Binding]
    public class AAN_AdminSteps
    {
        private readonly ScenarioContext _context;

        private readonly EsfaAdminLoginStepsHelper _esfaAdminLoginStepsHelper;

        public AAN_AdminSteps(ScenarioContext context)
        {
            _context = context;

            _esfaAdminLoginStepsHelper = new EsfaAdminLoginStepsHelper(context);
        }

        [Given(@"an admin logs into the AAN portal")]
        public void AnAdminLogsIntoTheAANPortal() => SubmitValidLoginDetails(_context.GetAanEsfaAdminConfig<AanEsfaAdminConfig>());

        [Given(@"a super admin logs into the AAN portal")]
        public void ASuperAdminLogsIntoTheAANPortal() => SubmitValidLoginDetails(_context.GetAanEsfaSuperAdminConfig<AanEsfaSuperAdminConfig>());

        private void SubmitValidLoginDetails(EsfaAdminConfig config)
        {
            _esfaAdminLoginStepsHelper.SubmitValidLoginDetails(config);

            _ = new AdminAdministratorHubPage(_context);
        }
    }
}