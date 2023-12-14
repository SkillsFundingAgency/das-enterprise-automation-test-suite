using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CoCSteps(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        private readonly EmployerPortalLoginHelper _loginHelper = new(context);

        private readonly EmployerStepsHelper _employerStepsHelper = new(context);

        private readonly ProviderStepsHelper _providerStepsHelper = new(context);

        private readonly ProviderCommonStepsHelper _providerCommonStepsHelper = new(context);

        private readonly CommitmentsSqlDataHelper _commitmentsDataHelper = context.Get<CommitmentsSqlDataHelper>();

        private readonly ApprenticeDataHelper _dataHelper = context.Get<ApprenticeDataHelper>();

        private readonly EditedApprenticeDataHelper _editedApprenticeDataHelper = context.Get<EditedApprenticeDataHelper>();

        private readonly CohortReferenceHelper _cohortReferenceHelper = new(context);

        private readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper = new(context);

        private readonly ProviderApproveStepsHelper _providerApproveStepsHelper = new(context);

        [Given(@"the listed employer has approved apprentice")]
        public void GivenTheListedEmployerHasApprovedApprentice() => ApproveCohort(true, context.GetUser<ASListedLevyUser>());

        [When(@"the Employer has approved another apprenticeship")]
        public void WhenTheEmployerHasApprovedAnotherApprenticeship() => ApproveCohortForLevyUser(false);

        [Given(@"the Employer has Live apprentice")]
        [Given(@"the Employer has approved apprentice")]
        [Given(@"the Employer creates an apprenticeship and the Provider approves it")]
        public void GivenTheEmployerHasApprovedApprentice() => ApproveCohortForLevyUser(true);

        [Given(@"the datalock has been successful")]
        public void GivenTheDatalockHasBeenSuccessful() => SetHasHadDataLockSuccessTrue();

        [When(@"the Employer edits Dob and Reference and confirm the changes after ILR match")]
        public void WhenTheEmployerEditsDobAndReferenceAndConfirmTheChangesAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();

            _employerStepsHelper.EditApprenticeDetailsPagePostApproval()
                .EditApprenticeNameDobAndReference()
                .AcceptChangesAndSubmit();
        }

        [When(@"the Employer edits cost and course and confirm the changes before ILR match")]
        public void WhenTheEmployerEditsCostAndCourseAndConfirmTheChangesBeforeILRMatch() => EmployerEditsCostAndCourse();

        [When(@"the Employer edits cost and course and confirm the changes after ILR match")]
        public void WhenTheEmployerEditsCostAndCourseAndConfirmTheChangesAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();
            EmployerEditsCostAndCourse();
        }

        [Then(@"the provider can review and approve the changes")]
        public void ThenTheProviderCanReviewAndApproveTheChanges() => _providerStepsHelper.ApproveChangesAndSubmit();

        [When(@"the provider edits Dob and Reference and confirm the changes after ILR match")]
        public void WhenTheProviderEditsDobAndReferenceAndConfirmTheChangesAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();

            ProviderEditApprentice()
            .EditApprenticeNameDobAndReference()
            .AcceptChangesAndSubmit();
        }

        [When(@"the provider edits cost and course and confirm the changes before ILR match")]
        public void WhenTheProviderEditsCostAndCourseAndConfirmTheChangesBeforeILRMatch() => ProviderEditsCostAndCourse();

        [When(@"the provider edits cost and course and confirm the changes after ILR match")]
        public void WhenTheProviderEditsCostAndCourseAndConfirmTheChangesAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();
            ProviderEditsCostAndCourse();
        }

        [Then(@"the employer can review and approve the changes")]
        public void TheEmployerCanReviewAndApproveTheChanges() => _employerStepsHelper.ApproveChangesAndSubmit();

        [Then(@"Employer cannot make changes to cost and course after ILR match")]
        public void ThenEmployerCannotMakeChangesToCostAndCourseAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();

            _employerStepsHelper
                .EditApprenticeDetailsPagePostApproval()
                 .VerifyCourseAndCostAreReadOnly();
        }

        [Then(@"provider cannot make changes to cost and course after ILR match")]
        public void ThenProviderCannotMakeChangesToCostAndCourseAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();

            ProviderEditApprentice().VerifyCourseAndCostAreReadOnly();
        }

        [When(@"the provider edits Name Dob and Reference")]
        public void ProviderEditsDobAndReference() => ProviderEditApprentice().EditApprenticeNameDobAndReference().AcceptChangesAndSubmit();

        [When(@"the employer accepts these changes")]
        public void WhenTheEmployerAcceptsTheseChanges()
        {
            _apprenticeHomePageStepsHelper
                .GoToManageYourApprenticesPage()
                    .SelectViewCurrentApprenticeDetails()
                    .ClickReviewChanges()
                    .SelectApproveChangesAndSubmit();

            _dataHelper.UpdateCurrentApprenticeName(_editedApprenticeDataHelper.ApprenticeEditedFirstname, _editedApprenticeDataHelper.ApprenticeEditedLastname);
        }

        [Then(@"the changes should be displayed on the view apprentice page")]
        public void ThenTheChangesShouldBeDisplayedOnTheViewApprenticePage()
        {
            var expectedName = _editedApprenticeDataHelper.ApprenticeEditedFullName;

            var expectedDob = new DateTime(_editedApprenticeDataHelper.DateOfBirthYear,
                _editedApprenticeDataHelper.DateOfBirthMonth, _editedApprenticeDataHelper.DateOfBirthDay);

            var expectedReference = _editedApprenticeDataHelper.ProviderRefernce;

            SelectViewCurrentApprenticeDetails().ConfirmNameDOBAndReferenceChanged(expectedName, expectedDob, expectedReference);
        }

        private void ApproveCohortForLevyUser(bool isFirstCourse) => ApproveCohort(isFirstCourse, context.GetUser<LevyUser>());

        private void ApproveCohort(bool isFirstCourse, EasAccountUser loginUser)
        {
            if (isFirstCourse)
                _loginHelper.Login(loginUser, true);
            else
                _objectContext.SetIsSameApprentice();

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider();

            if (!(_objectContext.IsSameApprentice()))
                _cohortReferenceHelper.SetCohortReference(cohortReference);
            else
                _cohortReferenceHelper.UpdateCohortReference(cohortReference);

            _providerApproveStepsHelper.EditAndApprove();
        }

        private void EmployerEditsCostAndCourse()
        {
            _employerStepsHelper.EditApprenticeDetailsPagePostApproval()
                    .EditCostCourseAndReference()
                    .AcceptChangesAndSubmit();
        }

        private void ProviderEditsCostAndCourse() => ProviderEditApprentice().EditCostCourseAndReference().AcceptChangesAndSubmit();

        private void SetHasHadDataLockSuccessTrue() => _commitmentsDataHelper.SetHasHadDataLockSuccessTrue(_dataHelper.ApprenticeULN);

        private ProviderApprenticeDetailsPage SelectViewCurrentApprenticeDetails() =>
                _providerCommonStepsHelper.GoToProviderHomePage().GoToProviderManageYourApprenticePage().SelectViewCurrentApprenticeDetails();

        private ProviderEditApprenticeCoursePage ProviderEditApprentice() => SelectViewCurrentApprenticeDetails().EditApprentice();
    }
}
