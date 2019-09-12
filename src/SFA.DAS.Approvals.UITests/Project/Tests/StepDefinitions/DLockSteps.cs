using SFA.DAS.Approvals.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DLockSteps
    {
        private readonly DlockDataHelper _dlockDataHelper;

        private readonly ProviderStepsHelper _providerStepsHelper;

        private readonly EmployerStepsHelper _employerStepsHelper;

        private readonly ApprenticeDataHelper _dataHelper;

        public DLockSteps(ScenarioContext context)
        {
            _dlockDataHelper = context.Get<DlockDataHelper>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            
        }

        [When(@"the provider submit an ILR with price mismatch")]
        public void WhenTheProviderSubmitAnILRWithPriceMismatch()
        {
            _dlockDataHelper.SubmitILRWithPriceMismatch();
            _providerStepsHelper.GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ClickViewIlrMismatchDetails()
                .RequestEmployerTheseDetailsAreUpdatedToMatchTheILR()
                .ConfirmRequestToFixILRMismatch()
                .ConfirmChangeRequestPendingMessage();
        }

        [Then(@"the Employer can approve the ILR mismatch changes")]
        public void ThenTheEmployerCanApproveTheILRMismatchChanges()
        {
            var apprenticeDetails = _employerStepsHelper.ViewCurrentApprenticeDetails();
            _employerStepsHelper.ApproveChangesAndSubmit(apprenticeDetails);
            apprenticeDetails.VerifyIfChangeRequestWasApproved();
        }

        [Then(@"the ILR should be matched and datalock is resolved")]
        public void ThenTheILRShouldBeMatchedAndDatalockIsResolved()
        {
            int apprenticeId = _dataHelper.GetApprenticeshipIdForCurrentLearner();
            int datalockStatus = _dlockDataHelper.GetDatalocksResolvedStatus(apprenticeId);
            if (datalockStatus == 0)
            {
                throw new Exception("ILR mismatch still exists and datalock is not resolved");
            }
        }
    }
}
