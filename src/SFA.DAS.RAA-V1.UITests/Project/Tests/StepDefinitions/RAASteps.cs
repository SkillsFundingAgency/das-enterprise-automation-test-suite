using NUnit.Framework;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RAASteps
    {
        private RAA_EmployerSelectionPage _employerSelection;
        private RAA_EmployerInformationPage _raaEmployerInformation;
        private RAA_EnterTrainingDetailsPage _enterTrainingDetails;
        private RAA_EnterFurtherDetailsPage _enterFurtherDetails;
        private RAA_EnterOpportunityDetailsPage _enterOpportunityDetails;
        private RAA_RequirementsAndProspectsPage _requirementsAndProspects;
        private RAA_VacancyLinkBasePage _vacancyLinkBasePage;
        private readonly RAAStepsHelper _raaStepsHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;

        public RAASteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _raaStepsHelper = new RAAStepsHelper(context);
        }
        
        [Then(@"Provider is able to archive vacancy")]
        public void ThenProviderIsAbleToArchiveVacancy()
        {
            new RAA_RecruitmentHomePage(_context, true).SearchClosedVacancy();

            _vacancyLinkBasePage = new RAA_VacancySummaryPage(_context);

            if (_vacancyLinkBasePage.IsRespondToCandidateLinkDisplayed())
            {
                _vacancyLinkBasePage.ArchiveVacancyAndRespondToCandidates()
                .RespondToRemainingCandidates()
                .ConfirmAndContinue()
                .SendFeedback()
                .ReturnToVacancyApplications();
            }
            _vacancyLinkBasePage.ArchiveVacancy().Confirm();
        }

        [Then(@"Provider is able to respond to candidates")]
        public void ThenProviderIsAbleToRespondToCandidates()
        {
            new RAA_VacancySummaryPage(_context).
                RespondToCandidates()
                .ConfirmAndContinue()
                .SendFeedback();
        }

        [Then(@"Provider is able to share vacancy application")]
        public void ThenProviderIsAbleToShareVacancyApplication()
        {
            new RAA_VacancySummaryPage(_context)
                .ShareApplications()
                .Send();
        }

        [Then(@"Provider is able to increase vacancy wage with no application")]
        public void ThenProviderIsAbleToIncreaseVacancyWageWithNoApplication()
        {
            InIncreaseVacancyWage(new RAA_VacancyPreviewPage(_context));
        }

        [Then(@"Provider is able to increase vacancy wage")]
        public void ThenProviderIsAbleToIncreaseVacancyWage()
        {
            InIncreaseVacancyWage(new RAA_VacancySummaryPage(_context));
        }

        private void InIncreaseVacancyWage(RAA_VacancyLinkBasePage linkBasePage)
        {
            linkBasePage.IncreaseWage().SaveAndReturn();
        }

        [Then(@"Provider is able to change vacancy dates with no application")]
        public void ThenProviderIsAbleToChangeVacancyDatesWithNoApplication()
        {
            ChangeVacancyDate(new RAA_VacancyPreviewPage(_context));
        }

        [Then(@"Provider is able to change vacancy dates")]
        public void ThenProviderIsAbleToChangeVacancyDates()
        {
            ChangeVacancyDate(new RAA_VacancySummaryPage(_context));
        }

        private void ChangeVacancyDate(RAA_VacancyLinkBasePage linkBasePage)
        {
            linkBasePage.ChangeVacancyDates().SaveAndContinue();
        }


        [Then(@"Provider is able to close this vacancy with no application")]
        public void ThenProviderIsAbleToCloseThisVacancyWithNoApplication()
        {
            CloseVacancy(new RAA_VacancyPreviewPage(_context));
        }

        [Then(@"Provider is able to close this vacancy")]
        public void ThenProviderIsAbleToCloseThisVacancy()
        {
            CloseVacancy(new RAA_VacancySummaryPage(_context));
        }

        private void CloseVacancy(RAA_VacancyLinkBasePage linkBasePage)
        {
            linkBasePage.CloseVacancy().CloseVacancy();

            new RAA_RecruitmentHomePage(_context, true)
                .SearchClosedVacancy();
        }

        [Then(@"the vacancy should not be displayed in Recruit")]
        public void ThenTheVacancyShouldNotBeDisplayedInRecruit()
        {
            var homePage = _raaStepsHelper.GoToRAAHomePage(true);

            var vacancySummary = homePage.SearchLiveVacancy();

            var actual = vacancySummary.GetVacancyStatus();

            Assert.AreEqual("Withdrawn", actual, "Withdrawn status is not displayed");

            homePage.ExitFromWebsite();
        }

        [Given(@"the Provider clones an existing vacancy")]
        public void GivenTheProviderClonesAnExistingVacancy()
        {
            CloneVacancy();
        }

        [When(@"an offline Vacancy details are filled out for a Traineeship for a different '(.*)'")]
        public void WhenAnOfflineVacancyDetailsAreFilledOutForATraineeshipForADifferent(string location)
        {
            _raaStepsHelper.ProviderFillsOutTraineeshipDetails(location, "Yes", "Offline");
        }

        [When(@"the Vacancy details are filled out for a Traineeship for a different '(.*)'")]
        public void WhenTheVacancyDetailsAreFilledOutForATraineeshipForADifferent(string location)
        {
            _raaStepsHelper.ProviderFillsOutTraineeshipDetails(location);
        }

        [When(@"the Vacancy details are filled out with Disability Confident as No for a Traineeship for a different '(.*)'")]
        public void WhenTheVacancyDetailsAreFilledOutWithDisabilityConfidentAsNoForATraineeshipForADifferent(string location)
        {
            _raaStepsHelper.ProviderFillsOutTraineeshipDetails(location, "No");
        }

        [Given(@"the Provider initiates Create Apprenticeship Vacancy in Recruit")]
        public void GivenTheProviderInitiatesCreateApprenticeshipVacancyIn()
        {
            _employerSelection = _raaStepsHelper.CreateANewVacancy();
        }

        [When(@"the Provider chooses the employer '(.*)','(.*)'")]
        public void WhenTheProviderChoosesTheEmployer(string location, string noOfpositions)
        {
            _raaEmployerInformation = _raaStepsHelper.ChoosesTheEmployer(_employerSelection, location, noOfpositions);
        }

        [When(@"the Provider chooses their '(.*)'")]
        public void WhenTheProviderChoosesTheir(string answer)
        {
            _raaStepsHelper.ChooseAnonymous(_raaEmployerInformation, answer);
        }

        [When(@"the Provider fills out details based on WageType '(.*)','(.*)'")]
        public void WhenTheProviderFillsOutDetailsBasedOnWageType(string location, string wageType)
        {
            _raaStepsHelper.ProviderFillsOutApprenticeshipDetails(location, "Yes", "Online", "Standard", "42", "52", wageType);
        }

        [When(@"the Provider fills out details for an Offline Vacancy '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenTheProviderFillsOutDetailsForAnOfflineVacancy(string location, string disabilityConfident, string applicationMethod, string apprenticeShip, string hoursPerWeek, string vacancyDuration)
        {
            _raaStepsHelper.ProviderFillsOutApprenticeshipDetails(location, disabilityConfident, applicationMethod, apprenticeShip, hoursPerWeek, vacancyDuration, "National Minimum Wage for apprentices");
        }

        [Then(@"Provider is able to submit the vacancy for approval")]
        public void ThenProviderIsAbleToSubmitTheVacancyForApproval() => _raaStepsHelper.ApproveVacanacy().ExitFromWebsite();

        [Then(@"the vacancy status should be Referred in Recruit")]
        public void ThenTheVacancyStatusShouldBeReferredInRecruit() => _raaStepsHelper.GoToRAAHomePage(true).SearchReferredVacancy().ExitFromWebsite();

        [Then(@"the vacancy status should be Live in Recruit")]
        public void ThenTheVacancyStatusShouldBeInRecruit() => _raaStepsHelper.GoToRAAHomePage(true).SearchLiveVacancy().ExitFromWebsite();

        [Then(@"the vacancy can be viewed anonymously")]
        public void ThenTheVacancyCanBeViewedAnonymously() => _raaStepsHelper.GoToRAAHomePage(true).SearchLiveVacancy().AnonymousView();

        private void CloneVacancy()
        {
            var homePage = _raaStepsHelper.GoToRAAHomePage(false);

            _raaEmployerInformation = homePage.CloneAVacancy();

            _raaEmployerInformation.ClickOnSaveAndContinueButton();

            _enterTrainingDetails = _raaStepsHelper.EnterBasicVacancyDetails();

            if (_objectContext.IsApprenticeshipVacancyType())
            {
                _enterFurtherDetails = _enterTrainingDetails.GotoFurtherDetailsPage();

                _requirementsAndProspects = _raaStepsHelper.EnterFurtherDetails(_enterFurtherDetails);
            }
            else
            {
                _enterOpportunityDetails = _enterTrainingDetails.GotoOpportunityDetailsPage();

                _requirementsAndProspects = _raaStepsHelper.EnterFurtherDetails(_enterOpportunityDetails);
            }

            _requirementsAndProspects.ClickSaveAndContinue();

            new RAA_ExtraQuestionsPage(_context).ClickPreviewVacancyButton();
        }

    }
}

