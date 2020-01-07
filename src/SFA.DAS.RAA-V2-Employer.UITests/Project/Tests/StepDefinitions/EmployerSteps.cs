using NUnit.Framework;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        private readonly EmployerStepsHelper _employerStepsHelper;
        private VacanciesPage _vacanciesPage;
        private VacancyPreviewPart2Page _vacancyPreviewPart2Page;
        private VacancyPreviewPart2WithErrorsPage _vacancyPreviewPart2WithErrorsPage;

        public EmployerSteps(ScenarioContext context) 
        { 
            _employerStepsHelper = new EmployerStepsHelper(context); 
        }

        [When(@"Employer selects '(National Minimum Wage|National Minimum Wage For Apprentices|Fixed Wage Type)' in the first part of the journey")]
        public void WhenEmployerSelectsInTheFirstPartOfTheJourney(string wageType) => _employerStepsHelper.CreateANewVacancy(wageType);

        [Given(@"the Employer completes the first part of the journey")]
        public void GivenTheEmployerCompletesTheFirstPartOfTheJourney() => _vacancyPreviewPart2Page = _employerStepsHelper.PreviewVacancy(string.Empty, true, false);

        [When(@"the Employer submits the vacancy")]
        public void WhenTheEmployerSubmitsTheVacancy() => _vacancyPreviewPart2WithErrorsPage = _vacancyPreviewPart2Page.SubmitVacancyWithMissingData();
        
        [When(@"the Employer saves the vacancy as a draft")]
        public void WhenTheEmployerSavesTheVacancyAsADraft() => _vacanciesPage = _vacancyPreviewPart2Page.ReturnToDashboard();

        [When(@"Employer cancels after saving the title of the Vacancy")]
        public void WhenEmployerCancelsAfterSavingTheTitleOfTheVacancy() => _vacanciesPage = _employerStepsHelper.CancelVacancy();

        [Then(@"the Employer can cancel deleting the draft vacancy")]
        public void ThenTheEmployerCanCancelDeletingTheDraftVacancy() => _vacancyPreviewPart2Page = _vacanciesPage.GoToVacancyPreviewPart2Page().DeleteVacancy().NoDeleteVacancy();

        [Given(@"the Employer creates an offline vacancy with disability confidence")]
        public void GivenTheEmployerCreatesAnOfflineVacancyWithDisabilityConfidence() => _employerStepsHelper.CreateOfflineVacancy(true);

        [Given(@"the Employer clones and creates a vacancy")]
        public void GivenTheEmployerClonesAndCreatesAVacancy() => _employerStepsHelper.CloneAVacancy();

        [Given(@"the Employer can create a vacancy by entering all the Optional fields")]
        public void GivenTheEmployerCanCreateAVacancyByEnteringAllTheOptionalFields() => _employerStepsHelper.CreateANewVacancy("anonymous", true, true);
        
        [Given(@"the Employer creates a vacancy by selecting different work location")]
        public void GivenTheEmployerCreatesAVacancyBySelectingDifferentWorkLocation() => _employerStepsHelper.CreateANewVacancy("legal-entity-name", false);

        [Given(@"the Employer creates an anonymous vacancy")]
        public void GivenTheEmployerCreatesAnAnonymousVacancy() => _employerStepsHelper.CreateANewVacancy("anonymous", true);

        [Given(@"the Employer creates a vacancy by using a trading name")]
        public void GivenTheEmployerCreatesAVacancyByUsingATradingName() => _employerStepsHelper.CreateANewVacancy("existing-trading-name", true);

        [Given(@"the Employer creates a vacancy by using a registered name")]
        public void GivenTheEmployerCreatesAVacancyByUsingARegisteredName() => _employerStepsHelper.CreateANewVacancy("legal-entity-name", true);

        [Then(@"Employer can make the application successful")]
        public void ThenEmployerCanMakeTheApplicationSuccessful() => _employerStepsHelper.ApplicantSucessful();

        [Then(@"Employer can make the application unsuccessful")]
        public void ThenEmployerCanMakeTheApplicationUnsuccessful() => _employerStepsHelper.ApplicantUnSucessful();

        [Then(@"the Employer can close the vacancy")]
        public void ThenTheEmployerCanCloseTheVacancy() => _employerStepsHelper.CloseVacancy();
        
        [Then(@"the Employer can edit the vacancy")]
        public void ThenTheEmployerCanEditTheVacancy() => _employerStepsHelper.EditVacancyDates();

        [Then(@"the vacancy is saved as a draft")]
        public void ThenTheVacancyIsSavedAsADraft() => _vacanciesPage.GoToApprenticeshipTrainingPage();

        [Then(@"Employer is able to open the draft and create the vacancy by filling the data for the second part")]
        public void ThenEmployerIsAbleToOpenTheDraftAndCreateTheVacancyByFillingTheDataForTheSecondPart() => _employerStepsHelper.SubmitVacancy(_vacanciesPage.GoToVacancyPreviewPart2Page(), true, false);

        [Then(@"the Employer is able to delete the draft vacancy")]
        public void ThenTheEmployerIsAbleToDeleteTheDraftVacancy() => _employerStepsHelper.DeleteDraftVacancy(_vacancyPreviewPart2Page);

        [Then(@"submission errors displayed for not completing the mandatory information")]
        public void ThenSubmissionErrorsDisplayedForNotCompletingTheMandatoryInformation()
        {
            List<string> expectedMessges = new List<string>
            {
                "You must provide an overview of the vacancy",
                "You must provide information on what the apprenticeship will involve",
                "You must provide information on the training to be provided",
                "You must provide information on what to expect at the end of the apprenticeship",
                "You must include a skill or quality",
                "You must add a qualification",
                "You must select an application method",
            };

            var actualMessages = _vacancyPreviewPart2WithErrorsPage.GetErrorMessages();

            Assert.IsTrue(expectedMessges.All(x => actualMessages.Contains(x)), $"Not all messages are found. {_employerStepsHelper.DeleteDraftVacancy(_vacancyPreviewPart2Page)}");

        }

        [Then(@"the Employer verify '(National Minimum Wage For Apprentices|National Minimum Wage|Fixed Wage Type)' the wage option selected in the Preview page")]
        public void ThenTheEmployerVerifyTheWageOptionSelectedInThePreviewPage(string wageType) => _employerStepsHelper.VerifyWageType(wageType);
    }
}
