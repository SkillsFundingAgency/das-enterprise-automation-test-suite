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
        private readonly RAAStepsHelper _raaStepsHelper;
        private readonly ObjectContext _objectContext;
        private readonly ScenarioContext _context;

        public RAASteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _raaStepsHelper = new RAAStepsHelper(context);
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
            string disabilityConfident = "Yes";
            string applicationMethod = "Online";
            switch (location)
            {
                case "Use the main employer address":
                    break;

                case "Add different location":
                    _raaStepsHelper.AddMultipleVacancy();
                    disabilityConfident = "No";
                    break;

                case "Set as a nationwide vacancy":
                    break;
            }

            _enterTrainingDetails = _raaStepsHelper.EnterBasicVacancyDetails(VacancyType.Traineeship, disabilityConfident, applicationMethod);

            _enterOpportunityDetails = _raaStepsHelper.EnterTrainingDetails(_enterTrainingDetails);

            _requirementsAndProspects = _raaStepsHelper.EnterOpportunityDetails(_enterOpportunityDetails, "18");

            _raaStepsHelper.EnterRequirementsAndProspects(_requirementsAndProspects);

            _raaStepsHelper.EnterExtraQuestions();
        }

        [Given(@"the Provider initiates Create Apprenticeship Vacancy in Recruit")]
        public void GivenTheProviderInitiatesCreateApprenticeshipVacancyIn()
        {
            _employerSelection = _raaStepsHelper.CreateANewVacancy();
        }

        [When(@"the Provider chooses the employer '(.*)','(.*)'")]
        public void WhenTheProviderChoosesTheEmployer(string location, string noOfpositions)
        {
            _raaEmployerInformation = _employerSelection.SelectAnEmployer();

            switch (location)
            {
                case "Use the main employer address":
                    _raaEmployerInformation = _raaEmployerInformation.UseTheMainEmployerAddress(noOfpositions);
                    break;

                case "Add different location":
                    _raaEmployerInformation = _raaEmployerInformation.AddDifferentLocation();
                    break;
                case "Set as a nationwide vacancy":
                    _raaEmployerInformation = _raaEmployerInformation.SetAsANationWideVacancy(noOfpositions);
                    break;
            }
        }

        [When(@"the Provider chooses their '(.*)'")]
        public void WhenTheProviderChoosesTheir(string answer)
        {
            switch (answer)
            {
                case "Yes":
                    _raaEmployerInformation.EmployerDoesNotWantToBeAnonymous();
                    break;

                case "No":
                    _raaEmployerInformation.EmployerWishesToBeAnonymous();
                    break;
            }
        }

        [When(@"the Provider fills out details for an Offline Vacancy '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenTheProviderFillsOutDetailsForAnOfflineVacancy(string location, string disabilityConfident, string applicationMethod, string apprenticeShip, string hoursPerWeek, string vacancyDuration)
        {
            switch (location)
            {
                case "Use the main employer address":
                    break;

                case "Add different location":
                    _raaStepsHelper.AddMultipleVacancy();
                    break;

                case "Set as a nationwide vacancy":
                    hoursPerWeek = "37";
                    vacancyDuration = "52";
                    break;
            }

            _objectContext.SetApprenticeshipVacancyType();

            _enterTrainingDetails = _raaStepsHelper.EnterBasicVacancyDetails(VacancyType.Apprenticeship, disabilityConfident, applicationMethod);

            _enterFurtherDetails = _raaStepsHelper.EnterTrainingDetails(_enterTrainingDetails, apprenticeShip);

            _requirementsAndProspects = _raaStepsHelper.EnterFurtherDetails(_enterFurtherDetails, hoursPerWeek, vacancyDuration);

            _raaStepsHelper.EnterRequirementsAndProspects(_requirementsAndProspects);

            if (applicationMethod != "Offline")
            {
                _raaStepsHelper.EnterExtraQuestions();
            }
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

