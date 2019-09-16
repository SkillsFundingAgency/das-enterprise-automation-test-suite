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
            ConfirmIlrismatch();
        }
        
        [When(@"the provider submit an ILR with course mismatch")]
        public void WhenTheProviderSubmitAnILRWithCourseMismatch()
        {
            _dlockDataHelper.SubmitILRWithCourseMismatch();
            ConfirmIlrismatch();
        }

        [When(@"the provider submit an ILR with course price mismatch")]
        public void WhenTheProviderSubmitAnILRWithCoursePriceMismatch()
        {
            _dlockDataHelper.SubmitILRWithCourseAndPriceMismatch();
            ConfirmIlrismatch();
        }

        [Then(@"the Employer can approve the ILR mismatch changes")]
        public void ThenTheEmployerCanApproveTheILRMismatchChanges()
        {
            var apprenticeDetails = _employerStepsHelper.ViewCurrentApprenticeDetails();
            _employerStepsHelper.ApproveChangesAndSubmit(apprenticeDetails);
            apprenticeDetails.VerifyIfChangeRequestWasApproved();
        }

        [Then(@"the Employer can stop the live apprentice")]
        public void ThenTheEmployerCanStopTheLiveApprentice()
        {
            _employerStepsHelper.ViewCurrentApprenticeDetails()
                .ClickEditStatusLink()
                .SelectStopAndContinueForAStartedApprentice()
                .ChooseRandomStopMonthAndSubmit()
                .SelectYesandConfirm();
        }

        [Then(@"the Employer can stop the waiting to apprentice")]
        public void ThenTheEmployerCanStopTheWaitingToApprentice()
        {
            _employerStepsHelper.ViewCurrentApprenticeDetails()
                .ClickEditStatusLink()
                .SelectStopAndContinueForANonStartedApprentice()
                .SelectYesandConfirm();
        }

        [Then(@"the ILR should be matched and datalock is resolved")]
        public void ThenTheILRShouldBeMatchedAndDatalockIsResolved()
        {
            int datalockStatus = _dlockDataHelper.GetDatalocksResolvedStatus();
            if (datalockStatus == 0)
            {
                throw new Exception("ILR mismatch still exists and datalock is not resolved");
            }
        }

        private void ConfirmIlrismatch()
        {
            _providerStepsHelper.GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ClickViewIlrMismatchDetails()
                .RequestEmployerTheseDetailsAreUpdatedToMatchTheILR()
                .ConfirmRequestToFixILRMismatch()
                .ConfirmChangeRequestPendingMessage();
        }

    }
}
