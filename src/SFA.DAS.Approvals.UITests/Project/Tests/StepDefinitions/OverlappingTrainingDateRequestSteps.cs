using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class OverlappingTrainingDateRequestSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;
        private int _oldCost;

        public OverlappingTrainingDateRequestSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _providerStepsHelper = new ProviderStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
            _loginHelper = new EmployerPortalLoginHelper(context);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
        }

        [Given(@"Employer and provider approve an apprentice")]
        public void GivenEmployerAndProviderApproveAnApprentice()
        {
            var sixMonthsOldDateTime = DateTime.UtcNow.AddMonths(-6);
            _loginHelper.Login(_context.GetUser<LevyUser>(), true);
            var date = sixMonthsOldDateTime.ToString("01-MM-yyyy");
            _objectContext.SetStartDate(date);
            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(1);
            _employerStepsHelper.SetCohortReference(cohortReference);
            _providerStepsHelper.Approve();
        }

        [When(@"provider creates a draft apprentice which has an overlap")]
        public void WhenProviderCreatesADraftApprenticeWhichHasAnOverlap()
        {
            var twoMonthsOldDateTime = DateTime.UtcNow.AddMonths(-2);
            var reference = _objectContext.GetCohortReference();
            var uln =_commitmentsSqlDataHelper.GetApprenticeshipULN(reference);
            _objectContext.SetUlnForOLTD(uln);
            _objectContext.SetStartDate(twoMonthsOldDateTime.ToString("01-MM-yyyy"));

            _providerStepsHelper.NavigateToProviderHomePage()
                                .GotoSelectJourneyPage()
                                .SelectAddManually()
                                .SelectOptionCreateNewCohort()
                                .ChooseAnEmployer("Levy")
                                .ConfirmEmployer()
                                .ProviderSelectsAStandard()
                                .SubmitValidPersonalDetails()
                                .SubmitApprenticeTrainingDetailsWithOverlappingTrainingDetails();
        }

        [When(@"provider selects to contact the employer themselves")]
        public void WhenProviderSelectsToContactTheEmployerThemselves()
        {
            new ProviderOverlappingTrainingDateThereMayBeProblemPage(_context)
                .SelectYesTheseDetailsAreCorrect()
                .SelectContactTheEmployerThemselves();
        }

        [When(@"provider decides to send stop request email from service")]
        public void WhenProviderDecidesToSendStopRequestEmailFromService()
        {
            new ProviderOverlappingTrainingDateThereMayBeProblemPage(_context)
                .SelectYesTheseDetailsAreCorrect()
                .SendStopEmail();
        }

        [Then(@"Vaidate information is not stored in database")]
        public void ThenVaidateNotInformationIsStoredInDatabase()
        {
            var uln = _objectContext.GetUlnForOLTD();
            var numberOfApprenticesWithUln = _commitmentsSqlDataHelper.GetApprenticeshipCountFromULN(uln);
            Assert.AreEqual(1, numberOfApprenticesWithUln);
        }


        [Then(@"information is saved in the cohort")]
        public void ThenInformationIsSavedInTheCohort()
        {
            var uln = _objectContext.GetUlnForOLTD();
            var numberOfApprenticesWithUln = _commitmentsSqlDataHelper.GetApprenticeshipCountFromULN(uln);
            Assert.AreEqual(2, numberOfApprenticesWithUln);
        }


        [When(@"provider selects to edit the price")]
        public void WhenProviderSelectsToEditThePrice()
        {
            var oldCost = _commitmentsSqlDataHelper.GetLatestApprenticeshipForUln(_objectContext.GetUlnForOLTD()).cost;
            _oldCost = int.Parse(oldCost);
            new ProviderApproveApprenticeDetailsPage(_context)
                .SelectEditApprentice()
                .ClickSaveAndContinue()
                .EditCost(_oldCost + 1)
                .ClickSaveWhenOltd();
        }

        [When(@"provider selects to add apprentice details later")]
        public void WhenProviderSelectsToAddApprenticeDetailsLater()
        {
            new ProviderOverlappingTrainingDateThereMayBeProblemPage(_context)
              .SelectYesTheseDetailsAreCorrect()
              .SelectIWillAddApprenticesLater();
        }


        [Then(@"price update information is not stored in the cohort")]
        public void ThenPriceUpdateInformationIsNotStoredInTheCohort()
        {
            var newCostString = _commitmentsSqlDataHelper.GetLatestApprenticeshipForUln(_objectContext.GetUlnForOLTD()).cost;
            var newCost = int.Parse(newCostString);
            Assert.AreEqual(_oldCost, newCost);
        }


        [Then(@"Employer selects to edit the active apprentice")]
        public void ThenEmployerSelectsToEditTheActiveApprentice()
        {
            _employerStepsHelper.GoToManageYourApprenticesPage()
               .SelectViewCurrentApprenticeDetails();
        }

        [When(@"Employer selects to edit the active apprentice")]
        public void WhenEmployerSelectsToEditTheActiveApprentice()
        {
            _employerStepsHelper.GoToManageYourApprenticesPage().SelectViewCurrentApprenticeDetails();
        }

        [Then(@"overlapping training date request banner is displayed")]
        public void ThenOverlappingTrainingDateRequestBannerIsDisplayed()
        {
            var actualText = new ApprenticeDetailsPage(_context).GetAlertBanner();

            string expectedText = "You have an outstanding request that needs to be reviewed and confirmed. Confirm changes";

            Assert.AreEqual(expectedText, actualText, "Text in the changes pending banner");
        }

        [Then(@"the apprenticeship record is locked for edit")]
        public void ThenTheApprenticeshipRecordIsLockedForEdit()
        {
            var editLinkVisible = new ApprenticeDetailsPage(_context).IsEditApprenticeDetailsLinkVisible();
            Assert.IsFalse(editLinkVisible);
        }

        [When(@"provider selects to edit the draft apprenticeship")]
        public void WhenProviderSelectsToEditTheDraftApprenticeship()
        {
          var providerApproveApprenticeDetailsPage =  new ProviderOverlappingTrainingDateEmployerNotifiedPage(_context).IWillAddAnotherApprentice();
          providerApproveApprenticeDetailsPage.SelectEditApprentice(0);
        }

        [When(@"provider deletes start and end date from Draft cohort")]
        public void WhenProviderDeletesStartAndEndDateFromDraftCohort()
        {
           var providerEditApprenticeTrainingDetailsPage = new ProviderEditApprenticePersonalDetailsPage(_context).ClickSaveAndContinue();
            providerEditApprenticeTrainingDetailsPage
                .EditStartDate("", "")
                .EditEndDate("","")
                .ClickSave();
        }

        [Then(@"overlapping training date request is resolved in database with status (.*) and resolutionType (.*)")]
        [When(@"overlapping training date request is resolved in database with status (.*) and resolutionType (.*)")]
        public void ThenOverlappingTrainingDateRequestIsResolvedInDatabaseWithStatusAndResolutionType(int status, int resolutionType)
        {
          var result =  _commitmentsSqlDataHelper.GetOverlappingTrainingDateRequestDetailsForUln(_objectContext.GetUlnForOLTD());
            Assert.AreEqual(resolutionType, result.resolutionType);
            Assert.AreEqual(status, result.status);
        }

        [When(@"provider updates the draft apprentice which creates an overlap")]
        public void WhenProviderUpdatesTheDraftApprenticeWhichCreatesAnOverlap()
        {
            var startDate = _objectContext.GetStartDate();
            var endDate =  startDate.AddMonths(36);
            
            var providerEditApprenticePersonalDetailsPage = new ProviderApproveApprenticeDetailsPage(_context).SelectEditApprentice(0);
            var providerEditApprenticeTrainingDetailsPage = providerEditApprenticePersonalDetailsPage.ClickSaveAndContinue();
            providerEditApprenticeTrainingDetailsPage
                .EditStartDate(startDate.Month.ToString(), startDate.Year.ToString())
                .EditEndDate(endDate.Month.ToString(), endDate.Year.ToString())
                .ClickSaveWhenOltd();
        }

        [Given(@"Employer selects to stop the active apprentice")]
        [When(@"Employer selects to stop the active apprentice")]
        public void WhenEmployerSelectsToStopTheActiveApprentice()
        {
            var apprenticeDetailsPage = _employerStepsHelper
                .GoToManageYourApprenticesPage()
                .SelectViewCurrentApprenticeDetails();
            _employerStepsHelper.StopApprenticeThisMonth(apprenticeDetailsPage);
        }

        [When(@"overlapping training date request banner is not displayed")]
        public void WhenOverlappingTrainingDateRequestBannerIsNotDisplayed()
        {
            var page = new StoppedApprenticeDetailsPage(_context);
            Assert.IsFalse(page.IsOverlappingTrainingDateRequestLinkDisplayed());
        }

        [When(@"overlapping training date request banner is not displayed when training date is changed")]
        public void WhenOverlappingTrainingDateRequestBannerIsNotDisplayedWhenTrainingDateIsChanged()
        {
            var page = new NewTrainingDatePage(_context);
            Assert.IsFalse(page.IsOverlappingTrainingDateRequestLinkDisplayed());
        }

        [When(@"Employer selects to reject the overlapping training date request")]
        public void WhenEmployerSelectsToRejectTheOverlappingTrainingDateRequest()
        {
            var apprenticeDetailsPage = _employerStepsHelper
               .GoToManageYourApprenticesPage()
               .SelectViewCurrentApprenticeDetails();
            apprenticeDetailsPage
                .ClickOnChangeOfOverlappingTrainingDateRequestLink()
                .ClickDateIsCorrectRadionButton();
        }

        [When(@"provider goes to its home page")]
        public void WhenProviderGoesToItsHomePage()
        {
            var tabHelper = _context.Get<TabHelper>();
            tabHelper.OpenNewTab();
            tabHelper.GoToUrl(UrlConfig.Provider_BaseUrl);

            new ProviderHomePage(_context);
        }

        [When(@"provider edits draft apprenitce start date which has an overlap")]
        public void WhenProviderEditsTheStartDate()
        {
            var oneMonthOldStartDate = DateTime.UtcNow.AddMonths(-1);

            var previousApprenticeshipCohortReference = _objectContext.GetCohortReference();
            var draftApprenticeshipCohortRef = _commitmentsSqlDataHelper.GetCohortReferenceForDraftApprenitceship(previousApprenticeshipCohortReference);
            _objectContext.UpdateCohortReference(draftApprenticeshipCohortRef);

            new ProviderApprenticeRequestsPage(_context, true)
               .GoToDraftCohorts()
               .SelectViewCurrentCohortDetails()
               .SelectEditApprentice(0)
               .ClickSaveAndContinue()
               .EditStartDate(oneMonthOldStartDate.Month.ToString(), oneMonthOldStartDate.Year.ToString())
               .ClickSaveWhenOltd();

            _objectContext.UpdateCohortReference(previousApprenticeshipCohortReference);
        }

        [When(@"Employer decides to update the stopped date")]
        public void WhenEmployerDecidesToUpdateTheStoppedDate()
        {
            var threeMonthOldStartDate = DateTime.UtcNow.AddMonths(-3);
            var apprenticeDetailsPage = _employerStepsHelper
                .GoToManageYourApprenticesPage()
                .SelectViewCurrentApprenticeDetails();
            apprenticeDetailsPage
                .ClickOnChangeOfOverlappingTrainingDateRequestLink()
                .ClickDateIsWrongRadionButton()
                .EditStopDateToCourseStartDateAndSubmit(threeMonthOldStartDate.Month.ToString(), threeMonthOldStartDate.Year.ToString());
        }

        [Given(@"Completed event is received for the apprentice")]
        public void GivenCompletedEventIsReceivedForTheApprentice()
        {
            var reference = _objectContext.GetCohortReference();
            var uln = _commitmentsSqlDataHelper.GetApprenticeshipULN(reference);
            _commitmentsSqlDataHelper.UpdateApprentieshipStatusToCompleted(uln);
        }

        [When(@"Employer decides to update end date")]
        public void WhenEmployerDecidesToUpdateEndDate()
        {
            var threeMonthOldStartDate = DateTime.UtcNow.AddMonths(-3);
            var apprenticeDetailsPage = _employerStepsHelper
                .GoToManageYourApprenticesPage()
                .SelectViewCurrentApprenticeDetails();
            apprenticeDetailsPage
                .ClickEndDateLink()
                .EditEndDate(threeMonthOldStartDate.Month.ToString(), threeMonthOldStartDate.Year.ToString());
        }

        [When(@"provider navigates to approve cohort details page")]
        [When(@"provider navigates to approve cohort details page")]
        public void WhenProivderNavigatesToApproveCohortPage()
        {
            var previousApprenticeshipCohortReference = _objectContext.GetCohortReference();
            var draftApprenticeshipCohortRef = _commitmentsSqlDataHelper.GetCohortReferenceForDraftApprenitceship(previousApprenticeshipCohortReference);
            _objectContext.UpdateCohortReference(draftApprenticeshipCohortRef);

            new ProviderApprenticeRequestsPage(_context, true)
               .GoToDraftCohorts()
               .SelectViewCurrentCohortDetails();

            _objectContext.UpdateCohortReference(previousApprenticeshipCohortReference);
        }
    

        [When(@"provider overlapping training date banner is not displayed")]
        [Then(@"provider overlapping training date banner is not displayed")]
        public void WhenOverlappingTrainingDateBannerIsNotDisplayed()
        {
            throw new PendingStepException();
        }

    }
}
