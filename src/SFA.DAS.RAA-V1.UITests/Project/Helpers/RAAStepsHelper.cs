using SFA.DAS.FAA.UITests.Project;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class RAAStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RAAV1Config _config;
        private readonly TabHelper _tabHelper;
        private readonly RestartWebDriverHelper _helper;
        private const string _applicationName = "Recruit";

        public RAAStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetRAAV1Config<RAAV1Config>();
            _tabHelper = context.Get<TabHelper>();
            _helper = new RestartWebDriverHelper(context);
        }

        public void GoToRAA()
        {
            _objectContext.SetCurrentApplicationName(_applicationName);
            _tabHelper.GoToUrl(_config.RecruitBaseUrl);
        }

        internal RAA_RecruitmentHomePage GoToRAAHomePage(bool restrat)
        {
            if (restrat)
            {
                _helper.RestartWebDriver(_config.RecruitBaseUrl, _applicationName);
            }
            else
            {
                GoToRAA();
            }

            return SubmitRecruitmentLoginDetails();
        }


        internal RAA_EmployerSelectionPage CreateANewVacancy()
        {
            GoToRAA();
            return SubmitRecruitmentLoginDetails()
                .CreateANewVacancy();
        }

        internal RAA_EmployerInformationPage ChoosesTheEmployer(RAA_EmployerSelectionPage employerSelection, string location, string noOfpositions)
        {
            var raaEmployerInformation = employerSelection.SelectAnEmployer();

            switch (location)
            {
                case "Use the main employer address":
                    raaEmployerInformation = raaEmployerInformation.UseTheMainEmployerAddress(noOfpositions);
                    break;

                case "Add different location":
                    raaEmployerInformation = raaEmployerInformation.AddDifferentLocation();
                    break;
                case "Set as a nationwide vacancy":
                    raaEmployerInformation = raaEmployerInformation.SetAsANationWideVacancy(noOfpositions);
                    break;
            }

            return raaEmployerInformation;
        }

        internal void ChooseAnonymous(RAA_EmployerInformationPage raaEmployerInformation, string answer)
        {
            switch (answer)
            {
                case "Yes":
                    raaEmployerInformation.EmployerDoesNotWantToBeAnonymous();
                    break;

                case "No":
                    raaEmployerInformation.EmployerWishesToBeAnonymous();
                    break;
            }
        }

        public void ProviderFillsOutTraineeshipDetails(string location, string disabilityConfident = "Yes", string applicationMethod = "Online", string postCode = "CV1 2WT")
        {
            switch (location)
            {
                case "Use the main employer address":
                    break;

                case "Add different location":
                    AddMultipleVacancy(postCode);
                    disabilityConfident = "No";
                    break;

                case "Set as a nationwide vacancy":
                    break;
            }

            var enterTrainingDetails = EnterBasicVacancyDetails(VacancyType.Traineeship, disabilityConfident, applicationMethod);

            var enterOpportunityDetails = EnterTrainingDetails(enterTrainingDetails);

            var requirementsAndProspects = EnterOpportunityDetails(enterOpportunityDetails, "18");

            EnterRequirementsAndExtraQuestions(requirementsAndProspects, applicationMethod);
        }

        internal void ProviderFillsOutApprenticeshipDetails(string location, string disabilityConfident, string applicationMethod, string apprenticeShip, string hoursPerWeek, string vacancyDuration, string wagetype, string postCode = "CV1 2WT")
        {
            switch (location)
            {
                case "Use the main employer address":
                    break;

                case "Add different location":
                    AddMultipleVacancy(postCode);
                    break;

                case "Set as a nationwide vacancy":
                    hoursPerWeek = "37";
                    vacancyDuration = "52";
                    break;
            }

            var enterTrainingDetails = EnterBasicVacancyDetails(VacancyType.Apprenticeship, disabilityConfident, applicationMethod);

            var enterFurtherDetails = EnterTrainingDetails(enterTrainingDetails, apprenticeShip);

            var requirementsAndProspects = EnterFurtherDetails(enterFurtherDetails, hoursPerWeek, vacancyDuration, wagetype);

            EnterRequirementsAndExtraQuestions(requirementsAndProspects, applicationMethod);
        }

        private void EnterRequirementsAndExtraQuestions(RAA_RequirementsAndProspectsPage requirementsAndProspects, string applicationMethod)
        {
            EnterRequirementsAndProspects(requirementsAndProspects);

            if (applicationMethod != "Offline")
            {
                EnterExtraQuestions();
            }
        }

        internal RAA_EnterTrainingDetailsPage EnterBasicVacancyDetails()
        {
            return new RAA_BasicVacancyDetailsPage(_context)
                       .EnterVacancyTitle()
                       .ClickSaveAndContinueButton();
        }

        internal RAA_EnterTrainingDetailsPage EnterBasicVacancyDetails(VacancyType vacancyType, string disabilityConfident, string applicationMethod)
        {
            return new RAA_BasicVacancyDetailsPage(_context)
                       .EnterVacancyTitle()
                       .EnterVacancyShortDescription()
                       .ClickOnVacancyType(vacancyType)
                       .CickDisabilityConfident(disabilityConfident)
                       .ApplicationMethod(applicationMethod)
                       .ClickSaveAndContinueButton();
        }

        internal RAA_EnterOpportunityDetailsPage EnterTrainingDetails(RAA_EnterTrainingDetailsPage enterTrainingDetails)
        {
            return enterTrainingDetails
                   .SelectApprenticeshipType("Traineeship")
                   .EnterTrainingToBeProvided()
                   .EnterContactName()
                   .ContactTelephone()
                   .EnterEmailDetails()
                   .GotoOpportunityDetailsPage();
        }


        internal RAA_EnterFurtherDetailsPage EnterTrainingDetails(RAA_EnterTrainingDetailsPage enterTrainingDetails, string apprenticeShip)
        {
            return enterTrainingDetails
                   .SelectApprenticeshipType(apprenticeShip)
                   .EnterTrainingToBeProvided()
                   .EnterContactName()
                   .ContactTelephone()
                   .EnterEmailDetails()
                   .GotoFurtherDetailsPage();
        }

        internal RAA_RequirementsAndProspectsPage EnterOpportunityDetails(RAA_EnterOpportunityDetailsPage enteropportunityDetails,string vacancyDuration)
        {
            return enteropportunityDetails
                   .EnterWorkingInformation()
                   .EnterVacancyDuration(vacancyDuration)
                   .EnterVacancyClosingDate()
                   .EnterPossibleStartDate()
                   .EnterVacancyDescription()
                   .SaveAndContinue();
        }

        internal RAA_RequirementsAndProspectsPage EnterFurtherDetails(RAA_EnterFurtherDetailsPage enterFurtherDetails)
        {
            return enterFurtherDetails
                   .EnterVacancyClosingDate()
                   .EnterPossibleStartDate()
                   .SaveAndContinue();
        }

        internal RAA_RequirementsAndProspectsPage EnterFurtherDetails(RAA_EnterFurtherDetailsPage enterFurtherDetails, string hoursPerWeek, string vacancyDuration, string wagetype)
        {
            return enterFurtherDetails
                   .EnterWorkingInformation()
                   .EnterHoursPerWeek(hoursPerWeek)
                   .Wage(wagetype)
                   .EnterVacancyDuration(vacancyDuration)
                   .EnterVacancyClosingDate()
                   .EnterPossibleStartDate()
                   .EnterVacancyDescription()
                   .SaveAndContinue();
        }

        internal void EnterRequirementsAndProspects(RAA_RequirementsAndProspectsPage requirementsAndProspects)
        {
            if (_objectContext.IsApprenticeshipVacancyType())
            {
                requirementsAndProspects = requirementsAndProspects
                .EnterDesiredQualificationsText();
            }
                requirementsAndProspects
                    .EnterDesiredSkillsText()
                    .EnterPersonalQualitiesText()
                    .EnterFutureProspectsText()
                    .EnterThingsToConsiderText()
                    .ClickSaveAndContinue();
        }

        internal void EnterExtraQuestions()
        {
            new RAA_ExtraQuestionsPage(_context)
                .EnterFirstQuestion()
                .EnterSecondQuestion()
                .ClickPreviewVacancyButton();
        }

        internal void AddMultipleVacancy(string postCode)
        {
            new RAA_MultipleVacancyLocationPage(_context)
                       .AddLocation(postCode)
                       .EnterNumberOfVacancy()
                       .ClickAddAnotherLocationLink()
                       .AddLocation("BS16 4EA")
                       .EnterNumberOfVacancy2()
                       .EnterAdditionalLocationInformation()
                       .ClickSaveAndContinue();
        }

        internal RAA_VacancyReferencePage ApproveVacanacy()
        {
            RAA_PreviewBasePage previewPage;

            if (_objectContext.IsApprenticeshipVacancyType())
            {
                previewPage = new RAA_VacancyPreviewPage(_context);
            }
            else
            {
                previewPage = new RAA_OppurtunityPreviewPage(_context);
            }

            var vacancyReferencepage = previewPage.ClickSubmitForApprovalButton();

            vacancyReferencepage.SetVacancyReference();

            return vacancyReferencepage;
        }

        private RAA_RecruitmentHomePage SubmitRecruitmentLoginDetails()
        {
            return new RAA_IndexPage(_context)
                .ClickOnSignInButton()
                .RecruitStaffIdams()
                .SubmitRecruitmentLoginDetails();
        }        
    }
}
