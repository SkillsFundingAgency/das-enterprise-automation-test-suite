using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprenticeshipVacancy
    {
        private readonly ScenarioContext _context;
        private RAA_EmployerSelection _employerSelection;
        private RAA_EmployerInformation _raaEmployerInformation;
        private RAA_BasicVacancyDetails _basicVacancyDetails;
        private RAA_EnterTrainingDetails _enterTrainingDetails;
        private RAA_EnterFurtherDetails _enterFurtherDetails;
        private RAA_RequirementsAndProspects _requirementsAndProspects;


        public ApprenticeshipVacancy(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"the Provider initiates Create Apprenticeship Vacancy in Recruit")]
        public void GivenTheProviderInitiatesCreateApprenticeshipVacancyIn()
        {
            _employerSelection = new RAAIndexPage(_context)
                .ClickOnSignInButton()
                .ClickRecruitStaffIdams()
                .SubmitValidLoginDetails()
                .CreateANewVacancy();
        }

        [When(@"the Provider chooses the employer '(.*)','(.*)'")]
        public void WhenTheProviderChoosesTheEmployer(string location, string noOfpositions)
        {
            _raaEmployerInformation = _employerSelection.SelectAndEmployer();
            
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
                    _basicVacancyDetails = _raaEmployerInformation.EmployerDoesNotWantToBeAnonymous();
                    break;

                case "No":
                    _basicVacancyDetails = _raaEmployerInformation.EmployerWishesToBeAnonymous();
                    break;
            }
        }

        [When(@"the Provider fills out details for an Offline Vacancy '(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)','(.*)'")]
        public void WhenTheProviderFillsOutDetailsForAnOfflineVacancy(string location, string title, string typeOfVacancy, string disabilityConfident, string applicationMethod, string apprenticeShip, string hoursPerWeek, string vacancyDuration)
        {
            switch (location)
            {
                case "Use the main employer address":

                    _basicVacancyDetails
                        .EnterVacancyTitle(title, typeOfVacancy)
                        .EnterVacancyShortDescription()
                        .ClickOnVacancyType(VacancyType.Apprenticeship)
                        .CickDisabilityConfident(disabilityConfident)
                        .ApplicationMethod(applicationMethod)
                        .ClickSaveAndContinueButton();

                    _enterTrainingDetails
                        .SelectApprenticeshipType(apprenticeShip)
                        .EnterTrainingToBeProvided()
                        .EnterContactName()
                        .ContactTelephone()
                        .EnterEmailDetails()
                        .ClickOnSaveAndContinue();

                    _enterFurtherDetails
                        .EnterWorkingInformation()
                        .EnterHoursPerWeek(hoursPerWeek)
                        .ClickApprenticeshipMinimumWage()
                        .EnterVacancyDuration(vacancyDuration)
                        .EnterVacancyClosingDate()
                        .EnterPossibleStartDate()
                        .EnterVacancyDescription()
                        .ClickSaveAndContinueButton();

                    _requirementsAndProspects
                        .EnterDesiredQualificationsText()
                        .EnterPersonalQualitiesText()
                        .EnterDesiredSkillsText()
                        .EnterFutureProspectsText()
                        .EnterThingsToConsiderText()
                        .ClickSaveAndContinue();
                    if (applicationMethod != "Offline")
                    {
                        _extraQuestions
                            .EnterFirstQuestion()
                            .EnterSecondQuestion()
                            .ClickPreviewVacacncyButton();
                    }
                    break;

                case "Add different location":

                    _multipleVacancyLocationPage
                        .EnterPostCode("CV1 2WT")
                        .ClickOnTheFirstAddress()
                        .EnterNumberOfVacancy()
                        .ClickAddAnotherLocationLink()
                        .EnterPostCode("BS16 4EA")
                        .ClickOnTheFirstAddress()
                        .EnterNumberOfVacancy2()
                        .EnterAdditionalLocationInformation()
                        .ClickSaveAndContinue();

                    const string multiLocation = "Multi-Location ";

                    _basicVacancyDetails
                        .EnterVacancyTitle(title, typeOfVacancy + multiLocation)
                        .EnterVacancyShortDescription()
                        .ClickOnVacancyType(VacancyType.Apprenticeship)
                        .CickDisabilityConfident(disabilityConfident)
                        .ApplicationMethod(applicationMethod)
                        .ClickSaveAndContinueButton();

                    _enterTrainingDetails
                        .SelectApprenticeshipType(apprenticeShip)
                        .EnterTrainingToBeProvided()
                        .EnterContactName()
                        .ContactTelephone()
                        .EnterEmailDetails()
                        .ClickOnSaveAndContinue();

                    _enterFurtherDetails
                        .EnterWorkingInformation()
                        .EnterHoursPerWeek(hoursPerWeek)
                        .ClickApprenticeshipMinimumWage()
                        .EnterVacancyDuration(vacancyDuration)
                        .EnterVacancyClosingDate()
                        .EnterPossibleStartDate()
                        .EnterVacancyDescription()
                        .ClickSaveAndContinueButton();

                    _requirementsAndProspects
                        .EnterDesiredQualificationsText()
                        .EnterPersonalQualitiesText()
                        .EnterDesiredSkillsText()
                        .EnterFutureProspectsText()
                        .EnterThingsToConsiderText()
                        .ClickSaveAndContinue();

                    if (applicationMethod != "Offline")
                    {
                        _extraQuestions
                            .EnterFirstQuestion()
                            .EnterSecondQuestion()
                            .ClickPreviewVacacncyButton();
                    }
                    break;

                case "Set as a nationwide vacancy":

                    const string nationwide = "NationwideVacancy ";

                    _basicVacancyDetails
                        .EnterVacancyTitle(title, typeOfVacancy + nationwide)
                        .EnterVacancyShortDescription()
                        .ClickOnVacancyType(VacancyType.Apprenticeship)
                        .CickDisabilityConfident("Yes")
                        .ApplicationMethod(applicationMethod)
                        .ClickSaveAndContinueButton();

                    _enterTrainingDetails
                        .SelectApprenticeshipType(apprenticeShip)
                        .EnterTrainingToBeProvided()
                        .EnterContactName()
                        .ContactTelephone()
                        .EnterEmailDetails()
                        .ClickOnSaveAndContinue();

                    _enterFurtherDetails
                        .EnterWorkingInformation()
                        .EnterHoursPerWeek("37")
                        .ClickApprenticeshipMinimumWage()
                        .EnterVacancyDuration("52")
                        .EnterVacancyClosingDate()
                        .EnterPossibleStartDate()
                        .EnterVacancyDescription()
                        .ClickSaveAndContinueButton();

                    _requirementsAndProspects
                        .EnterDesiredQualificationsText()
                        .EnterPersonalQualitiesText()
                        .EnterDesiredSkillsText()
                        .EnterFutureProspectsText()
                        .EnterThingsToConsiderText()
                        .ClickSaveAndContinue();

                    if (applicationMethod != "Offline")
                    {
                        _extraQuestions
                            .EnterFirstQuestion()
                            .EnterSecondQuestion()
                            .ClickPreviewVacacncyButton();
                    }
                    break;
            }
        }
    }
}
