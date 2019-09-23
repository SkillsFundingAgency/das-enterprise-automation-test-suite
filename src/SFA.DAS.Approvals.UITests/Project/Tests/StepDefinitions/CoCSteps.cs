using NUnit.Framework;
using OpenQA.Selenium;
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

        private readonly EmployerPortalLoginHelper _loginHelper;

        private readonly EmployerStepsHelper _employerStepsHelper;

        private readonly ProviderStepsHelper _providerStepsHelper;

        private readonly CommitmentsDataHelper _commitmentsDataHelper;

        private readonly ApprenticeDataHelper _dataHelper;

        public CoCSteps(ScenarioContext context)
        {
            _context = context;
            _commitmentsDataHelper = context.Get<CommitmentsDataHelper>();
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _loginHelper = new EmployerPortalLoginHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _providerStepsHelper = new ProviderStepsHelper(context);
        }

        [Given(@"the Employer has approved apprentice")]
        public void GivenTheEmployerHasApprovedApprentice()
        {
            _loginHelper.Login(_context.GetUser<LevyUser>(), true);

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(1);

            _employerStepsHelper.SetCohortReference(cohortReference);

            _providerStepsHelper.Approve();
        }

        [Given(@"the datalock has been successful")]
        public void GivenTheDatalockHasBeenSuccessful()
        {
            SetHasHadDataLockSuccessTrue();
        }

        [When(@"the Employer edits Dob and Reference and confirm the changes after ILR match")]
        public void WhenTheEmployerEditsDobAndReferenceAndConfirmTheChangesAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();

            _employerStepsHelper.EditApprenticeDetailsPagePostApproval()
                .EditApprenticeNameDobAndReference()
                .AcceptChangesAndSubmit();
        }

        [When(@"the Employer edits cost and course and confirm the changes before ILR match")]
        public void WhenTheEmployerEditsCostAndCourseAndConfirmTheChangesBeforeILRMatch()
        {
            EmployerEditsCostAndCourse();
        }

        [When(@"the Employer edits cost and course and confirm the changes after ILR match")]
        public void WhenTheEmployerEditsCostAndCourseAndConfirmTheChangesAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();
            EmployerEditsCostAndCourse();
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

        [When(@"the provider edits Dob and Reference and confirm the changes after ILR match")]
        public void WhenTheProviderEditsDobAndReferenceAndConfirmTheChangesAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();

            _providerStepsHelper.GoToProviderHomePage()
                .GoToProviderManageYourApprenticePage()
                .SelectViewCurrentApprenticeDetails()
                .ClickEditApprenticeDetailsLink()
                .EditApprenticeNameDobAndReference()
                .AcceptChangesAndSubmit();
        }

        [When(@"the provider edits cost and course and confirm the changes before ILR match")]
        public void WhenTheProviderEditsCostAndCourseAndConfirmTheChangesBeforeILRMatch()
        {
            ProviderEditsCostAndCourse();
        }

        [When(@"the provider edits cost and course and confirm the changes after ILR match")]
        public void WhenTheProviderEditsCostAndCourseAndConfirmTheChangesAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();
            ProviderEditsCostAndCourse();
        }

        [Then(@"the Employer can review and approve the changes")]
        public void ThenTheEmployerCanReviewAndApproveTheChanges()
        {
            var apprenticeDetails = _employerStepsHelper.ViewCurrentApprenticeDetails();
            _employerStepsHelper.ApproveChangesAndSubmit(apprenticeDetails);
        }

        [Then(@"Employer cannot make changes to cost and course after ILR match")]
        public void ThenEmployerCannotMakeChangesToCostAndCourseAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();

            void employeraction()
            {    
                _employerStepsHelper.EditApprenticeDetailsPagePostApproval()
                 .EditCostCourseAndReference()
                 .AcceptChangesAndSubmit();
            }

            Assert.Multiple(() =>
            {
                var empex = Assert.Throws(typeof(WebDriverTimeoutException), () => employeraction(), "Employer can edit cost and course after ILR match");
                Assert.That(empex.InnerException, Is.TypeOf<NoSuchElementException>(), "Employer can edit cost and course after ILR match");
            });
        }

        [Then(@"provider cannot make changes to cost and course after ILR match")]
        public void ThenProviderCannotMakeChangesToCostAndCourseAfterILRMatch()
        {
            SetHasHadDataLockSuccessTrue();

            void provideraction()
            {
                _providerStepsHelper.GoToProviderHomePage()
                  .GoToProviderManageYourApprenticePage()
                  .SelectViewCurrentApprenticeDetails()
                  .ClickEditApprenticeDetailsLink()
                  .EditCostCourseAndReference()
                  .AcceptChangesAndSubmit();
            };

            Assert.Multiple(() =>
            {
                var proex = Assert.Throws(typeof(WebDriverTimeoutException), () => provideraction(), "Provider can edit cost and course after ILR match");
                Assert.That(proex.InnerException, Is.TypeOf<NoSuchElementException>(), "Provider can edit cost and course after ILR match");
            });
        }

        private void EmployerEditsCostAndCourse()
        {
            _employerStepsHelper.EditApprenticeDetailsPagePostApproval()
                    .EditCostCourseAndReference()
                    .AcceptChangesAndSubmit();
        }

        private void ProviderEditsCostAndCourse()
        {
            _providerStepsHelper.GoToProviderHomePage()
                 .GoToProviderManageYourApprenticePage()
                 .SelectViewCurrentApprenticeDetails()
                 .ClickEditApprenticeDetailsLink()
                 .EditCostCourseAndReference()
                 .AcceptChangesAndSubmit();
        }

        private void SetHasHadDataLockSuccessTrue()
        {
            _dataHelper.Ulns.ForEach((x) => _commitmentsDataHelper.SetHasHadDataLockSuccessTrue(x));
        }
    }
}
