using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.StepDefinition
{
    [Binding]
    public class ConfirmIdentitySteps : BaseSteps
    {
        private readonly ScenarioContext _context;
        private SigUpCompletePage sigUpCompletePage;

        public ConfirmIdentitySteps(ScenarioContext context) : base(context) => _context = context;

        [Given(@"an apprentice login in to the service")]
        public void GivenAnApprenticeLoginInToTheService()
        {
            appreticeCommitmentsStepsHelper.CreateApprenticeship();

            sigUpCompletePage = appreticeCommitmentsStepsHelper.CreatePassword();

        }

        [Then(@"the apprentice identity can be validated")]
        public void ThenTheApprenticeIdentityCanBeValidated()
        {
            sigUpCompletePage.ClickSignInToApprenticePortal().SignInToApprenticePortal();
        }


    }
}
