using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerAndProviderSteps(ScenarioContext context) : BaseSteps
    {
        private readonly EmployerPortalLoginHelper _employerPortalLoginHelper = new(context);
        private readonly ProviderStepsHelper _providerStepsHelper = new(context);
        private readonly EmployerStepsHelper _employerStepsHelper = new(context);
        private readonly EmployerCreateCohortStepsHelper _employerCreateCohortStepsHelper = new(context);
        private readonly ManageFundingEmployerStepsHelper _reservationStepsHelper = new(context);

        [Given(@"the listed provider has approved apprentice")]
        public void GivenTheListedProviderHasApprovedApprentice()
        {
            _employerPortalLoginHelper.Login(context.GetUser<LevyUser>(), true);

            _employerCreateCohortStepsHelper.EmployerCreateCohortAndSendsToProvider();

            _providerStepsHelper.AddApprenticeAndSendToEmployerForApproval(1);

            _employerStepsHelper.Approve();
        }

        [Given(@"a dynamic pause rule exists from (.*) to (.*)")]
        public void GivenADynamicPauseRuleExistsFromMonthActiveFromToMonthActiveTo(string monthActiveFrom, string monthActiveTo) =>
            _reservationStepsHelper.AddDynamicPauseGlobalRule(ParseMonth(monthActiveFrom).Value, ParseMonth(monthActiveTo).Value);
    }
}