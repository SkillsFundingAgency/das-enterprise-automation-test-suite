using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DLockSteps
    {
        private readonly DataLockSqlHelper _dlockDataHelper;

        private readonly ProviderStepsHelper _providerStepsHelper;

        private readonly EmployerStepsHelper _employerStepsHelper;

        private readonly ApprenticeDataHelper _dataHelper;

        public DLockSteps(ScenarioContext context)
        {
            _dlockDataHelper = context.Get<DataLockSqlHelper>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
        }

        [When(@"the provider submit an ILR with price mismatch")]
        [When(@"the provider submit another ILR with price mismatch")]
        public void WhenTheProviderSubmitAnILRWithPriceMismatch()
        {
            _dlockDataHelper.SubmitILRWithPriceMismatch();
        }
        
        [When(@"the provider submit an ILR with course mismatch")]
        [When(@"the provider submit another ILR with course mismatch")]
        public void WhenTheProviderSubmitAnILRWithCourseMismatch()
        {
            _dlockDataHelper.SubmitILRWithCourseMismatch();
        }

        [When(@"the provider submit an ILR with course price mismatch")]
        public void WhenTheProviderSubmitAnILRWithCoursePriceMismatch()
        {
            _dlockDataHelper.SubmitILRWithCourseAndPriceMismatch();            
        }

        [When(@"provider requests Employer to update details in MA")]
        public void WhenProviderRequestsEmployerToUpdateDetailsInMA()
        {
            ConfirmIlrismatch();
        }

        [Then(@"only course mismatch is displayed")]
        public void ThenOnlyCourseMismatchIsDisplayed()
        {
            var rows = _providerStepsHelper.GoToProviderHomePage(false)
                                             .GoToProviderManageYourApprenticePage()
                                             .SelectViewCurrentApprenticeDetails()
                                             .ClickViewIlrMismatchDetails()
                                             .GetRowCountForMismatch();

            Assert.IsTrue(rows == 1, "validate only course mismatch row is displayed");
        }

        [Then(@"both mismatches are displayed on single page")]
        public void ThenBothMismatchesAreDisplayedOnSinglePage()
        {
            var rows = _providerStepsHelper.GoToProviderHomePage(false)
                                             .GoToProviderManageYourApprenticePage()
                                             .SelectViewCurrentApprenticeDetails()
                                             .ClickViewIlrMismatchDetails()
                                             .GetRowCountForMismatch();

            Assert.IsTrue(rows == 4, "validate both mismatched rows are displayed");
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
            _employerStepsHelper.StopApprenticeThisMonth();
        }

        [Then(@"the Employer can stop the waiting to start apprentice")]
        public void ThenTheEmployerCanStopTheWaitingToStartApprentice()
        {
            _employerStepsHelper.ViewCurrentApprenticeDetails()
              .ClickEditStatusLink()
              .SelectStopAndContinueForAWaitingToStartApprentice()
              .ClickARadioButtonAndContinue()
              .SelectYesAndConfirm()
              .ValidateRedundancyStatus();
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

        [Then(@"provider will see two links on PAS for each ILR mismatch")]
        public void ThenProviderWillSeeTwoLinksOnPASForEachILRMismatch()
        {
            var ProviderApprenticeDetailsPage = _providerStepsHelper.GoToProviderHomePage(false)
                                                                    .GoToProviderManageYourApprenticePage()
                                                                    .SelectViewCurrentApprenticeDetails();

            Assert.IsTrue(ProviderApprenticeDetailsPage.IsPricemismatchLinkDisplayed(), "Validate price mismatch link is displayed");
            Assert.IsTrue(ProviderApprenticeDetailsPage.IsCoursemismatchLinkDisplayed(), "Validate course mismatch link is displayed");
        }

        [Then(@"provider will see all price episodes on single page")]
        public void ThenProviderWillSeeAllPriceEpisodesOnSinglePage()
        {
            var ProviderApprenticeDetailsPage = _providerStepsHelper.GoToProviderHomePage(false)
                                                        .GoToProviderManageYourApprenticePage()
                                                        .SelectViewCurrentApprenticeDetails();
        }



        private void ConfirmIlrismatch()
        {
            _providerStepsHelper.GoToProviderHomePage(false)
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ClickViewIlrMismatchDetails()
                .RequestEmployerTheseDetailsAreUpdatedToMatchTheILR()
                .ConfirmRequestToFixILRMismatch()
                .ConfirmChangeRequestPendingMessage();
        }

    }
}
