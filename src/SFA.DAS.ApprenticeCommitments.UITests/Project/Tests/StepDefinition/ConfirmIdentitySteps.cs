using SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page;
using System.Collections.Generic;
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
            appreticeCommitmentsStepsHelper.SignInToApprenticePortal(sigUpCompletePage).ConfirmIdentity();
        }

        [Then(@"an error is shown for invalid data")]
        public void ThenAnErrorIsShownForInvalidData()
        {
            var confirmidentitypage =  appreticeCommitmentsStepsHelper.SignInToApprenticePortal(sigUpCompletePage);

            var invalidDatas = new List<(string, string, int, int, int, string)>
            {
                (string.Empty, string.Empty, 0,0,0, string.Empty)
            };

            foreach (var d in invalidDatas)
            {
                confirmidentitypage = confirmidentitypage.InvalidData(d.Item1, d.Item2, d.Item3, d.Item4, d.Item5, d.Item6);

                confirmidentitypage.VerifyErrorSummary();
            }
        }

    }
}
