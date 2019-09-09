using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CoCSteps
    {
        private readonly ScenarioContext _context;

        private readonly ExistingAccountsStepsHelper _stepsHelper;

        private readonly EmployerStepsHelper _employerStepsHelper;

        private readonly ProviderStepsHelper _providerStepsHelper;

        private readonly CommitmentsDataHelper _commitmentsDataHelper;

        private readonly ApprovalsDataHelper _dataHelper;

        public CoCSteps(ScenarioContext context)
        {
            _context = context;
            _commitmentsDataHelper = context.Get<CommitmentsDataHelper>();
            _dataHelper = context.Get<ApprovalsDataHelper>();
            _stepsHelper = new ExistingAccountsStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
        }

        [Given(@"the Employer has approved apprentice")]
        public void GivenTheEmployerHasApprovedApprentice()
        {
            _stepsHelper.Login(_context.GetUser<LevyUser>(), true);

            var employerReviewYourCohortPage = _employerStepsHelper.EmployerAddApprentice(1);

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(employerReviewYourCohortPage);

            _employerStepsHelper.SetCohortReference(cohortReference);

            var providerReviewYourCohortPage = _providerStepsHelper.EditApprentice();

            _providerStepsHelper.Approve(providerReviewYourCohortPage);
            
        }

        [When(@"the Employer edits and confirm the changes after ILR match")]
        public void WhenTheEmployerEditsAndConfirmTheChangesAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();

            _employerStepsHelper.GoToEmployerApprenticesHomePage()
                .ClickManageYourApprenticesLink()
                .SelectViewCurrentApprenticeDetails()
                .ClickEditApprenticeDetailsLink()
                .EditTheApprenticePostApprovalAfterIlrMatchAndSubmit()
                .AcceptChangesAndSubmit();
        }

        [Then(@"the provider can review and approve the changes")]
        public void ThenTheProviderCanReviewAndApproveTheChanges()
        {
            _providerStepsHelper.GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ClickReviewChanges()
                .SelectApproveChangesAndSubmit();
        }

        [When(@"the provider edits and confirm the changes after ILR match")]
        public void WhenTheProviderEditsAndConfirmTheChangesAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();

            _providerStepsHelper.GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ClickEditApprenticeDetailsLink()
                .EditTheApprenticePostApprovalAfterIlrMatchAndSubmit()
                .AcceptChangesAndSubmit();
        }

        [Then(@"the Employer can review and approve the changes")]
        public void ThenTheEmployerCanReviewAndApproveTheChanges()
        {
            _employerStepsHelper.GoToEmployerApprenticesHomePage()
                .ClickManageYourApprenticesLink()
                .SelectViewCurrentApprenticeDetails()
                .ClickReviewChanges()
                .SelectApproveChangesAndSubmit();
        }

        private void SetHasHadDataLockSuccessTrue()
        {
            _dataHelper.Ulns.ForEach((x) => _commitmentsDataHelper.SetHasHadDataLockSuccessTrue(x));
        }


    }
}
