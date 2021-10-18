using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerAndProviderSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;

        public EmployerAndProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
        }


        [Given(@"the listed provider has approved apprentice")]
        public void GivenTheListedProviderHasApprovedApprentice()
        {
            _employerPortalLoginHelper.Login(_context.GetUser<LevyUser>(), true);

            _employerStepsHelper.EmployerCreateCohortAndSendsToProvider();

            _providerStepsHelper.AddApprenticeAndSendToEmployerForApproval(1);

            _employerStepsHelper.Approve();
        }

    }
}