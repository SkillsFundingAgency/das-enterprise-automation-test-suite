using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerEditSteps
    {
        private readonly EmployerStepsHelper _employerStepsHelper;

        public EmployerEditSteps(ScenarioContext context) => _employerStepsHelper = new EmployerStepsHelper(context);

        [Given(@"the employer update the email address")]
        public void GivenTheEmployerUpdateTheEmailAddress() => EditApprenticeDetailsPagePostApproval().ContinueToAddValidEmailDetails().AcceptChangesAndSubmit();

        [Then(@"the employer will no longer be able to change the email address")]
        public void ThenTheEmployerWillNoLongerBeAbleToChangeTheEmailAddress() => EditApprenticeDetailsPagePostApproval().VerifyReadOnlyEmail();

        private EditApprenticeDetailsPage EditApprenticeDetailsPagePostApproval() => _employerStepsHelper.EditApprenticeDetailsPagePostApproval();
    }
}
