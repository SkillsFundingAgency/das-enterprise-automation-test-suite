using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using System.Threading.Tasks;

using System;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;

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
            var uln = _commitmentsSqlDataHelper.GetApprenticeshipULN(reference);
            _objectContext.SetUlnForOLTD(uln);
            _objectContext.SetStartDate(twoMonthsOldDateTime.ToString("01-MM-yyyy"));

            _providerStepsHelper
                .NavigateToProviderHomePage()
               .GotoSelectJourneyPage()
               .SelectAddManually()
               .SelectOptionCreateNewCohort()
               .ChooseAnEmployer("Levy")
               .ConfirmEmployer()
               .ProviderSelectsAStandard()
               .SubmitValidApprenticePersonalDetails()
               .SubmitApprenticeTrainingDetailsWithOverlappingTrainingDetails();
            _providerStepsHelper.NavigateToProviderHomePage()
                                .GotoSelectJourneyPage()
                                .SelectAddManually()
                                .SelectOptionCreateNewCohort()
                                .ChooseAnEmployer("Levy")
                                .ConfirmEmployer()
                                .ProviderSelectsAStandard()
                                .SubmitValidApprenticePersonalDetails()
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

        [Given(@"a live apprentice record exists with startdate of <(.*)> months and endDate of <\+(.*)> months from current date")]
        public void GivenALiveApprenticeRecordExistsWithStartdateOfMonthsAndEndDateOfMonthsFromCurrentDate(int startDateFromNow, int endDateFromNow)
        {
            var courseStartDate = DateTime.Now.AddMonths(startDateFromNow);
            var courseEndDate = DateTime.Now.AddMonths(endDateFromNow);

            _loginHelper.Login(_context.GetUser<LevyUser>(), true);
            _objectContext.SetStartDate(courseStartDate.ToString("dd-MM-yyyy", null));
            _objectContext.SetEndDate(courseEndDate.ToString("dd-MM-yyyy", null));

            var cohortReference = _employerStepsHelper.EmployerApproveAndSendToProvider(1);
            _employerStepsHelper.SetCohortReference(cohortReference);
            _providerStepsHelper.Approve();
        }

        [When(@"Provider tries to add a new apprentice using details from table below")]
        public void WhenProviderTriesToAddANewApprenticeUsingDetailsFromTableBelow(Table table)
        {
            var apprenticeshipDetails = table.CreateSet<OltdApprenticeDetails>();

            var reference = _objectContext.GetCohortReference();
            var uln = _commitmentsSqlDataHelper.GetApprenticeshipULN(reference);
            _objectContext.SetUlnForOLTD(uln);

            foreach (OltdApprenticeDetails apprenticeship in apprenticeshipDetails)
            {
                SetContextStartAnEndDates(apprenticeship.NewStartDate, apprenticeship.NewEndDate);

                _providerStepsHelper
                   .NavigateToProviderHomePage()
                   .GotoSelectJourneyPage()
                   .SelectAddManually()
                   .SelectOptionCreateNewCohort()
                   .ChooseAnEmployer("Levy")
                   .ConfirmEmployer()
                   .ProviderSelectsAStandard()
                .SubmitValidApprenticePersonalDetails()
                .VerifyOverlappingTrainingDetailsError(apprenticeship.DisplayOverlapErrorOnStartDate, apprenticeship.DisplayOverlapErrorOnEndDate);
            }
        }

        [When(@"Employer tries to add a new apprentice using details from table below")]
        public void WhenEmployerTriesToAddANewApprenticeUsingDetailsFromTableBelow(Table table)
        {
            var apprenticeshipDetails = table.CreateSet<OltdApprenticeDetails>();

            var reference = _objectContext.GetCohortReference();
            var uln = _commitmentsSqlDataHelper.GetApprenticeshipULN(reference);
            _objectContext.SetUlnForOLTD(uln);

            foreach (OltdApprenticeDetails apprenticeship in apprenticeshipDetails)
            {
                SetContextStartAnEndDates(13, 18);

                var cohortReference = _providerStepsHelper
                      .GoToProviderHomePage()
                      .GotoSelectJourneyPage()
                      .SelectAddManually()
                      .SelectOptionCreateNewCohort()
                      .ChooseAnEmployer("Levy")
                      .ConfirmEmployer()
                      .ProviderSelectsAStandard()
                      .SubmitValidApprenticePersonalDetails()
                      .SubmitValidApprenticeTrainingDetails()
                      .SubmitSendToEmployerToReview()
                      .CohortReference();

                _employerStepsHelper.UpdateCohortReference(cohortReference);

                SetContextStartAnEndDates(apprenticeship.NewStartDate, apprenticeship.NewEndDate);

                _employerStepsHelper
                    .GoToApprenticeRequestsPage()
                    .GoToReadyToReview()
                    .SelectViewCurrentCohortDetails()
                    .SelectEditApprenticeLink()
                    .ContinueToAddTrainingDetailsPage()
                    .VerifyOverlappingTrainingDetailsError(apprenticeship.DisplayOverlapErrorOnStartDate, apprenticeship.DisplayOverlapErrorOnEndDate);
            }
        }

        private void SetContextStartAnEndDates(int startDateDurationInMonths, int endDateDurationInMonths)
        {
            var courseStartDate = DateTime.Now.AddMonths(startDateDurationInMonths);
            var courseEndDate = DateTime.Now.AddMonths(endDateDurationInMonths);

            if (_objectContext.HasStartDate())
            {
                _objectContext.UpdateStartDate(courseStartDate.ToString("dd-MM-yyyy", null));
            }
            else
            {
                _objectContext.SetStartDate(courseStartDate.ToString("dd-MM-yyyy", null));
            }

            if (_objectContext.HasEndDate())
            {
                _objectContext.UpdateEndDate(courseEndDate.ToString("dd-MM-yyyy", null));
            }
            else
            {
                _objectContext.SetEndDate(courseEndDate.ToString("dd-MM-yyyy", null));
            }
        }

        [Then(@"Vaidate information is stored in database")]
        public void ThenVaidateInformationIsStoredInDatabase()
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

        [Then(@"Vaidate price update information is not stored in database")]
        public void ThenVaidatePriceUpdateInformationIsNotStoredInDatabase()
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
    }
}