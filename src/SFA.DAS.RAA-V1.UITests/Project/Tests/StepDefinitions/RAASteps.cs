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
        private RAA_VacancyPreviewPage _vacancyPreviewPage;
        private readonly RAAStepsHelper _raaStepsHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;

        public RAASteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _raaStepsHelper = new RAAStepsHelper(context);
        }
        
        [Given(@"Provider views a vacancy which has NO Applications")]
        public void GivenProviderViewsAVacancyWhichHasNOApplications()
        {
            var homePage = _raaStepsHelper.GoToRAAHomePage(false);

            _vacancyPreviewPage = homePage.SelectLiveVacancyWithNoApplications();

            _vacancyPreviewPage.SetVacancyReference();
        }

        [Then(@"Provider is able to change the '(.*)' of the vacancy")]
        public void ThenProviderIsAbleToChangeTheOfTheVacancy(string status)
        {
            switch (status)
            {
                case "Close this vacancy":
                    _vacancyPreviewPage.CloseVacancy().CloseOpportunity();

                    var vacancypreview = new RAA_RecruitmentHomePage(_context, true).SearchClosedVacancy();

                    var actual = vacancypreview.GetVacancyInfo();

                    Assert.AreEqual("This vacancy is now closed", actual, "Withdraw message is not displayed");
                    break;
                default:
                    break;
            }
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

        [Given(@"the Provider clones an existing traineeship")]
        public void GivenTheProviderClonesAnExistingTraineeship()
        {
            CloneVacancy();
        }

        [Given(@"the Provider clones an existing apprenticeship")]
        public void GivenTheProviderClonesAnExistingApprenticeship()
        {
            _objectContext.SetApprenticeshipVacancyType();

            CloneVacancy();
        }

        [When(@"the Vacancy details are filled out for a Traineeship for a different '(.*)'")]
        public void WhenTheVacancyDetailsAreFilledOutForATraineeshipForADifferent(string location)
        {
            _raaStepsHelper.ProviderFillsOutTraineeshipDetails(location);
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

        [When(@"the Provider fills out details for an Offline Vacancy '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenTheProviderFillsOutDetailsForAnOfflineVacancy(string location, string disabilityConfident, string applicationMethod, string apprenticeShip, string hoursPerWeek, string vacancyDuration)
        {
            _raaStepsHelper.ProviderFillsOutDetails(location, disabilityConfident, applicationMethod, apprenticeShip, hoursPerWeek, vacancyDuration);
        }

        [Then(@"Provider is able to submit the vacancy for approval")]
        public void ThenProviderIsAbleToSubmitTheVacancyForApproval()
        {
            _raaStepsHelper
                .ApproveVacanacy()
                .ExitFromWebsite();
        }

        [Then(@"the vacancy status should be Referred in Recruit")]
        public void ThenTheVacancyStatusShouldBeReferredInRecruit()
        {
            var homePage = _raaStepsHelper.GoToRAAHomePage(true);

            homePage.SearchReferredVacancy();

            homePage.ExitFromWebsite();
        }


        [Then(@"the vacancy status should be Live in Recruit")]
        public void ThenTheVacancyStatusShouldBeInRecruit()
        {
            var homePage = _raaStepsHelper.GoToRAAHomePage(true);

            homePage.SearchLiveVacancy();

            homePage.ExitFromWebsite();
        }

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

