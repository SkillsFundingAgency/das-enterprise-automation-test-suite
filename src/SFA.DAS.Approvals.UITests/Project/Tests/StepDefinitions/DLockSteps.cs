using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DLockSteps
    {
        private readonly DataLockSqlHelper _dlockDataHelper;

        private readonly ProviderStepsHelper _providerStepsHelper;

        private readonly EmployerStepsHelper _employerStepsHelper;

        public DLockSteps(ScenarioContext context)
        {
            _dlockDataHelper = context.Get<DataLockSqlHelper>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
        }

        [When(@"the provider submit an ILR with price mismatch")]
        [When(@"the provider submit another ILR with price mismatch")]
        public void WhenTheProviderSubmitAnILRWithPriceMismatch() => _dlockDataHelper.SubmitILRWithPriceMismatch();

        [When(@"the provider submit an ILR with course mismatch")]
        [When(@"the provider submit another ILR with course mismatch")]
        public void WhenTheProviderSubmitAnILRWithCourseMismatch() => _dlockDataHelper.SubmitILRWithCourseMismatch();

        [When(@"the provider submit an ILR with course price mismatch")]
        public void WhenTheProviderSubmitAnILRWithCoursePriceMismatch() => _dlockDataHelper.SubmitILRWithCourseAndPriceMismatch();

        [When(@"provider requests Employer to update details in MA")]
        public void WhenProviderRequestsEmployerToUpdateDetailsInMA() => ConfirmIlrismatch();

        [Then(@"only course mismatch is displayed")]
        public void ThenOnlyCourseMismatchIsDisplayed()
        {
            var rows = GetRowCountForMismatch();

            Assert.IsTrue(rows["CourseMismatchRows"] == 1, "validate 1 course mismatch row is displayed");
            Assert.IsTrue(rows["PriceMismatchRows"] == 0, "validate no other mismatch row is displayed");
        }

        [Then(@"both mismatches are displayed on single page")]
        public void ThenBothMismatchesAreDisplayedOnSinglePage()
        {
            var rows = GetRowCountForMismatch();

            Assert.IsTrue(rows["CourseMismatchRows"] == 2, "validate 1 course mismatch row is displayed");      //1 row is split b/w 2 grids
            Assert.IsTrue(rows["PriceMismatchRows"] == 2, "validate 1 price mismatch row is displayed");
        }

        [Then(@"provider will see all price episodes on single page")]
        public void ThenProviderWillSeeAllPriceEpisodesOnSinglePage()
        {
            var rows = GetRowCountForMismatch();

            Assert.IsTrue(rows["CourseMismatchRows"] == 0, "validate no course mismatch row is displayed");
            Assert.IsTrue(rows["PriceMismatchRows"] == 4, "validate 1 price mismatch row is displayed");        //1 row is split b/w 2 grids
        }

        [Then(@"the Employer can approve the ILR mismatch changes")]
        public void ThenTheEmployerCanApproveTheILRMismatchChanges()
        {
            var apprenticeDetails = _employerStepsHelper.ViewCurrentApprenticeDetails();

            _employerStepsHelper.ApproveChangesAndSubmit(apprenticeDetails);

            apprenticeDetails.VerifyIfChangeRequestWasApproved();
        }

        [Then(@"the Employer can stop the live apprentice")]
        public void ThenTheEmployerCanStopTheLiveApprentice() => _employerStepsHelper.StopApprenticeThisMonth(StopApprentice.Withdrawn);

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
            var providerApprenticeDetailsPage = SelectViewCurrentApprenticeDetails();

            Assert.IsTrue(providerApprenticeDetailsPage.IsPricemismatchLinkDisplayed(), "Validate price mismatch link is displayed");
            Assert.IsTrue(providerApprenticeDetailsPage.IsCoursemismatchLinkDisplayed(), "Validate course mismatch link is displayed");
        }

        private void ConfirmIlrismatch()
        {
            SelectViewCurrentApprenticeDetails()
            .ClickViewIlrMismatchDetails()
            .RequestEmployerTheseDetailsAreUpdatedToMatchTheILR()
            .ConfirmRequestToFixILRMismatch()
            .ConfirmChangeRequestPendingMessage();
        }

        private ProviderApprenticeDetailsPage SelectViewCurrentApprenticeDetails() =>
            _providerStepsHelper.GoToProviderHomePage(false).GoToProviderManageYourApprenticePage().SelectViewCurrentApprenticeDetails();

        private Dictionary<string, int?> GetRowCountForMismatch() => SelectViewCurrentApprenticeDetails().ClickViewIlrMismatchDetails().GetRowCountForMismatch();

    }
}
