using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer
{
    public class EmployerStepsHelper(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        protected readonly ScenarioContext context = context;
        private readonly ApprenticeDataHelper _dataHelper = context.Get<ApprenticeDataHelper>();
        private readonly CohortReferenceHelper _cohortReferenceHelper = new(context);
        private readonly SetApprenticeDetailsHelper _setApprenticeDetailsHelper = new(context);
        private readonly ConfirmProviderDetailsHelper _confirmProviderDetailsHelper = new(context);
        protected readonly ApprenticeHomePageStepsHelper _apprenticeHomePageStepsHelper = new(context);
        private readonly RofjaaDbSqlHelper _rofjaaDbSqlHelper = context.Get<RofjaaDbSqlHelper>();
        protected readonly ReplaceApprenticeDatahelper _replaceApprenticeDatahelper = new(context);

        public void Approve() => EmployerReviewCohort().EmployerDoesSecondApproval();

        public void Reject() => EmployerReviewCohort().EmployerSendsToTrainingProviderForReview();

        public void ApproveMultipleCohorts()
        {
            foreach (var cohort in _objectContext.GetCohortReferenceList())
            {
                _objectContext.ReplaceCohortReference(cohort);

                Approve();

                _objectContext.SetDebugInformation($"Approved Cohort - {cohort}");
            }
        }

        public StoppedApprenticeDetailsPage StopApprenticeThisMonth(StopApprentice reason) => StopApprenticeThisMonth(ViewCurrentApprenticeDetails(), reason);

        internal static EditedApprenticeDetailsPage ApproveChangesAndSubmit(ApprenticeDetailsPage apprenticeDetailsPage) =>
            apprenticeDetailsPage.ClickReviewChanges().SelectApproveChangesAndSubmit();

        internal EditedApprenticeDetailsPage ApproveChangesAndSubmit() => ApproveChangesAndSubmit(ViewCurrentApprenticeDetails());

        internal static StoppedApprenticeDetailsPage StopApprenticeThisMonth(ApprenticeDetailsPage apprenticeDetailsPage, StopApprentice reason)
        {
            return apprenticeDetailsPage
                .ClickEditStatusLink()
                .SelectStopAndContinueForAStartedApprentice()
                .SelectedReasonToStop(reason)
                .EditStopDateToThisMonthAndSubmit()
                .ClickARadioButtonAndContinue()
                .SelectYesAndConfirm()
                .ValidateEditLinkIsNoLongerVisible()
                .ValidateRedundancyStatusAndStopDate();
        }

        public ApprenticeDetailsPage ViewCurrentApprenticeDetails(bool openInNewTab = true) => _apprenticeHomePageStepsHelper.GoToManageYourApprenticesPage(openInNewTab).SelectViewCurrentApprenticeDetails();

        public EditApprenticeDetailsPage EditApprenticeDetailsPagePostApproval(bool openInNewTab = true) => ViewCurrentApprenticeDetails(openInNewTab).ClickEditApprenticeDetailsLink();

        public ApproveApprenticeDetailsPage EmployerReviewCohort()
        {
            var employerReviewYourCohortPage = _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage()
                .ClickApprenticeRequestsLink()
                .GoToReadyToReview()
                .SelectViewCurrentCohortDetails();

            _setApprenticeDetailsHelper.SetApprenticeTotalCost(employerReviewYourCohortPage);

            return employerReviewYourCohortPage;
        }

        public ApproveApprenticeDetailsPage EmployerAddApprentice(List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentice) => AddApprentices(listOfApprentice);

        public ApproveApprenticeDetailsPage EmployerAddApprentice(int numberOfApprentices) => AddApprentices(numberOfApprentices);

        public string EmployerApproveAndSendToProvider() => EmployerApproveAndSendToProvider(1);

        public string EmployerApproveAndSendToProvider(int numberOfApprentices) => EmployerApproveAndSendToProvider(EmployerAddApprentice(numberOfApprentices));

        public static string EmployerApproveAndSendToProvider(ApproveApprenticeDetailsPage employerReviewYourCohortPage)
        {
            return employerReviewYourCohortPage.
                 EmployerFirstApproveAndNotifyTrainingProvider()
                .CohortReference();
        }

        public static DynamicHomePages DynamicHomePageStartToAddApprentice(AddAnApprenitcePage addAnApprenitcePage)
        {
            return addAnApprenitcePage.StartNowToAddTrainingProvider()
                 .SubmitValidUkprn()
                 .ConfirmProviderDetailsAreCorrect()
                 .DynamicHomePageNonLevyEmployerAddsApprentices()
                 .DynamicHomePageClickSaveAndContinueToAddAnApprentices()
                 .EmployerSelectsAStandard()
                 .DraftDynamicHomePageAddValidApprenticeDetails()
                 .DraftReturnToHomePage()
                 .CheckDraftStatusAndAddDetails()
                 .ContinueToAddValidApprenticeDetails()
                 .DynamicHomePageChangeRequestFromTrainingProvider()
                 .ClickHomeLink()
                 .CheckWithTrainingProviderStatus();
        }

        public DynamicHomePages DynamicHomePageFinishToAddApprenticeJourney()
        {
            return new DynamicHomePages(context).CheckReadyToReviewStatus()
                .ApproveAndNotifyTrainingProvider()
                .ClickHome()
                .VerifyViewApprenticeDetailsLink();
        }

        internal void ValidateStatusOnManageYourApprenticesPage(string expectedStatus)
        {
            var name = _dataHelper.ApprenticeFullName;

            var actualStatus = _apprenticeHomePageStepsHelper.GoToManageYourApprenticesPage().SearchForApprentice(name).GetStatus(name);

            Assert.AreEqual(actualStatus.ToUpper(), expectedStatus.ToUpper(), "Validate status on Manage Your Apprentices page");
        }

        public ChangeOfTrainingProviderRequestedPage StartChangeofNewTrainingProvider()
        {
            return _apprenticeHomePageStepsHelper.GoToManageYourApprenticesPage()
                  .SelectViewCurrentApprenticeDetails()
                  .ClickOnChangeOfProviderLink()
                  .ClickOnContinueButton()
                  .ChooseTrainingProviderPage()
                  .NewTrainingProviderWillAddThemLater()
                  .SelectYesAndContinue();
        }

        private ApproveApprenticeDetailsPage AddApprentices(List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)> listOfApprentice)
        {
            _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(0);

            var employerReviewYourCohortPage = EmployerAddApprenticeFromHomePage();

            for (int i = 1; i < listOfApprentice.Count; i++)
            {
                _replaceApprenticeDatahelper.ReplaceApprenticeDataInContext(i);

                employerReviewYourCohortPage = SubmitValidTrainingDetails(employerReviewYourCohortPage);
            }

            return SetApprenticeDetails(employerReviewYourCohortPage, listOfApprentice.Count);
        }

        private ApproveApprenticeDetailsPage AddApprentices(int numberOfApprentices)
            => AddApprentices(context.Get<List<(ApprenticeDataHelper, ApprenticeCourseDataHelper)>>().Take(numberOfApprentices).ToList());
        private ApproveApprenticeDetailsPage EmployerAddApprenticeFromHomePage()
            => ConfirmProviderDetailsAreCorrect().EmployerAddsApprentices().EmployerSelectsAStandard().SubmitValidApprenticeDetails(false);

        private static ApproveApprenticeDetailsPage SubmitValidTrainingDetails(ApproveApprenticeDetailsPage employerReviewYourCohortPage) => employerReviewYourCohortPage.SelectAddAnotherApprentice().EmployerSelectsAStandard().SubmitValidApprenticeDetails(false);

        public AddApprenticeDetailsPage FlexiEmployerAddsApprenticeAndSelectsFlexiJobAgencyDeliveryModel()
        {
            return ConfirmProviderDetailsAreCorrect()
                  .EmployerAddsApprentices()
                  .SelectsAStandardAndNavigatesToSelectDeliveryModelPage()
                  .SelectFlexiJobAgencyDeliveryModelAndContinue();
        }

        public AddApprenticeDetailsPage FlexiEmployerAddsApprenticeAndSelectsRegularDeliveryModel()
        {
            return ConfirmProviderDetailsAreCorrect()
                  .EmployerAddsApprentices()
                  .SelectsAStandardAndNavigatesToSelectDeliveryModelPage()
                  .EmployerSelectRegularDeliveryModelAndContinue();
        }

        public AddApprenticeDetailsPage AddsPortableFlexiJobCourseAndDeliveryModelForPilotProvider()
        {
            return new ApprenticesHomePage(context).AddAnApprentice()
                .StartNowToAddTrainingProvider()
                .EnterUkprnForPortableFlexiJobPilotProvider()
                .ConfirmProviderDetailsAreCorrect()
                .EmployerAddsApprentices()
                .SelectsAStandardAndNavigatesToSelectDeliveryModelPage()
                .SelectPortableFlexiJobDeliveryModelAndContinue();
        }

        public void EmployerFirstApproveCohortAndNotifyProvider()
        {
            var cohortReference = new ApproveApprenticeDetailsPage(context).EmployerFirstApproveAndNotifyTrainingProvider().CohortReferenceFromUrl();

            _cohortReferenceHelper.SetCohortReference(cohortReference);
        }

        public ApprenticeRequestsPage GoToApprenticeRequestsPage() => _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage(true).ClickApprenticeRequestsLink();

        public void EmployerValidateApprenticeIsFlexiJobAndDeliveryModelEditable()
        {
            var employerEditTrainingDetailsPage = _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage()
                .ClickApprenticeRequestsLink()
                .GoToReadyToReview()
                .SelectViewCurrentCohortDetails()
                .SelectEditApprenticeLink();

            Assert.True(employerEditTrainingDetailsPage.ConfirmDeliveryModelLabelText("Flexi-job agency"));
            Assert.True(employerEditTrainingDetailsPage.IsEditDeliveryModelLinkVisible());
        }

        public NotificationSentToTrainingProviderPage EmployerChangeDeliveryModelToFlexiAndSendsBackToProvider_PreApproval()
        {
            return _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage()
                  .ClickApprenticeRequestsLink()
                  .GoToReadyToReview()
                  .SelectViewCurrentCohortDetails()
                  .SelectEditApprenticeLink()
                  .ClickEditDeliveryModelLink()
                  .EditDeliveryModelToFlexiAndContinue()
                  .SaveEditedTrainingDetails()
                  .EmployerSendsToTrainingProviderForReview();

        }

        public ApprenticeDetailsPage EmployerChangeDeliveryModelToRegularAndSendsBackToProvider_PostApproval()
        {
            return _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage()
                  .ClickManageYourApprenticesLink()
                  .SelectViewCurrentApprenticeDetails()
                  .ClickEditApprenticeDetailsLink()
                  .ClickEditDeliveryModelLink()
                  .EmployerEditDeliveryModelToRegularAndContinue()
                  .ClickUpdateDetailsButtonAfterChange()
                  .AcceptChangesAndSubmit();
        }

        private ApproveApprenticeDetailsPage SetApprenticeDetails(ApproveApprenticeDetailsPage employerReviewYourCohortPage, int numberOfApprentices) => _setApprenticeDetailsHelper.SetApprenticeDetails(employerReviewYourCohortPage, numberOfApprentices);

        protected virtual Func<AddAnApprenitcePage, AddTrainingProviderDetailsPage> AddTrainingProviderDetailsFunc() => AddTrainingProviderStepsHelper.AddTrainingProviderDetailsFunc();

        private StartAddingApprenticesPage ConfirmProviderDetailsAreCorrect() => _confirmProviderDetailsHelper.ConfirmProviderDetailsAreCorrect(false, AddTrainingProviderDetailsFunc());

        public ApprenticeDetailsApprovedPage ValidateFlexiJobContentAndApproveCohort()
        {
            return _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage()
                  .ClickApprenticeRequestsLink()
                  .GoToReadyToReview()
                  .SelectViewCurrentCohortDetails()
                  .ValidateFlexiJobTagAndApprove();
        }

        public EditApprenticeDetailsPage ValidateDeliveryModelDisplayedInDMSections(string deliveryModel)
        {
            return _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage()
                .ClickManageYourApprenticesLink()
                .SelectViewCurrentApprenticeDetails()
                .ValidateDeliveryModelDisplayed(deliveryModel)
                .ClickEditApprenticeDetailsLink()
                .ValidateDeliveryModelDisplayed(deliveryModel);
        }

        public ApprenticeDetailsPage ValidateDeliveryModelNotDisplayed()
        {
            return _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage()
                .ClickManageYourApprenticesLink()
                .SelectViewCurrentApprenticeDetails()
                .ValidateDeliveryModelNotDisplayed();
        }

        public void RemoveEmployerFromFlexiJobAgencyRegister() => _rofjaaDbSqlHelper.RemoveFJAAEmployerFromRegister();

        public ApprenticeRequestsPage DeleteCurrentCohort()
        {
            return _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage()
                  .ClickApprenticeRequestsLink()
                  .GoToReadyToReview()
                  .SelectViewCurrentCohortDetails()
                  .SelectDeleteThisGroup()
                  .ConfirmDeleteAndSubmit();
        }

        public ApproveApprenticeDetailsPage ValidateEmployerCanNoLongerApproveCohort()
        {
            return _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage()
                  .ClickApprenticeRequestsLink()
                  .GoToReadyToReview()
                  .SelectViewCurrentCohortDetails()
                  .ValidateEmployerCannotApproveCohort();
        }

        public ApproveApprenticeDetailsPage RemovedFJAEmployerEditsDeliveryModelAndApproves()
        {
            return new ApproveApprenticeDetailsPage(context)
                .SelectEditApprenticeLink()
                .ClickEditDeliveryModel()
                .ConfirmDeliveryModelChangeToRegular()
                .ValidateDeliveryModelDisplayed("Regular")
                .SaveEditedTrainingDetails();
        }

        public ApprenticeDetailsPage EmployerChangeDeliveryModelToFlexiAndSendsBackToProvider_PostApproval()
        {
            return _apprenticeHomePageStepsHelper.GoToEmployerApprenticesHomePage()
                  .ClickManageYourApprenticesLink()
                  .SelectViewCurrentApprenticeDetails()
                  .ClickEditApprenticeDetailsLink()
                  .ClickEditDeliveryModelLink()
                  .EmployerEditDeliveryModelToFlexiAndContinue()
                  .ClickUpdateDetailsButtonAfterChange()
                  .AcceptChangesAndSubmit();
        }
    }
}