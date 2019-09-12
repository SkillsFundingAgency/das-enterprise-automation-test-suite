using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DLockSteps
    {
        public DLockSteps(ScenarioContext context)
        {

        }
        [When(@"the provider submit an ILR with price mismatch")]
        public void WhenTheProviderSubmitAnILRWithPriceMismatch()
        {
            throw new PendingStepException();
        }

        [Then(@"the Employer can approve the ILR mismatch changes")]
        public void ThenTheEmployerCanApproveTheILRMismatchChanges()
        {
            throw new PendingStepException();
        }

        [Then(@"the ILR should be matched and datalock is resolved")]
        public void ThenTheILRShouldBeMatchedAndDatalockIsResolved()
        {
            throw new PendingStepException();
        }

    }
}
