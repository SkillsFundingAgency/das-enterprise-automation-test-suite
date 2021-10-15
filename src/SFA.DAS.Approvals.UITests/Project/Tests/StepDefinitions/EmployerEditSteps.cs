using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerEditSteps
    {
        private readonly EmployerStepsHelper _employerStepsHelper;

        public EmployerEditSteps(ScenarioContext context) => _employerStepsHelper = new EmployerStepsHelper(context);

        [Given(@"the employer update the email address")]
        public void GivenTheEmployerUpdateTheEmailAddress() => _employerStepsHelper.EditApprenticeDetailsPagePostApproval().ContinueToAddValidEmailDetails().AcceptChangesAndSubmit();
    }
}
