using TechTalk.SpecFlow;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerAndProviderSteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly EmployerCreateCohortStepsHelper _employerCreateCohortStepsHelper;
        private readonly ManageFundingEmployerStepsHelper _reservationStepsHelper;

        public EmployerAndProviderSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerPortalLoginHelper = new EmployerPortalLoginHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _reservationStepsHelper = new ManageFundingEmployerStepsHelper(context);
            _employerCreateCohortStepsHelper = new EmployerCreateCohortStepsHelper(context);
        }


        [Given(@"the listed provider has approved apprentice")]
        public void GivenTheListedProviderHasApprovedApprentice()
        {
            _employerPortalLoginHelper.Login(_context.GetUser<LevyUser>(), true);

            _employerCreateCohortStepsHelper.EmployerCreateCohortAndSendsToProvider();

            _providerStepsHelper.AddApprenticeAndSendToEmployerForApproval(1);

            _employerStepsHelper.Approve();
        }

        [Given(@"a dynamic pause rule exists from (.*) to (.*)")]
        public void GivenADynamicPauseRuleExistsFromMonthActiveFromToMonthActiveTo(string monthActiveFrom, string monthActiveTo) =>
            _reservationStepsHelper.AddDynamicPauseGlobalRule(ParseMonth(monthActiveFrom).Value, ParseMonth(monthActiveTo).Value);
    }
}