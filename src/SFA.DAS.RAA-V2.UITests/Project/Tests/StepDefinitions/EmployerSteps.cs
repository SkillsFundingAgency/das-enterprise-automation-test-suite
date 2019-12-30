using SFA.DAS.RAA_V2.UITests.Project.Helpers;
using SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps
    {
        private readonly EmployerStepsHelper _employerStepsHelper;
        private VacanciesPage vacanciesPage;

        public EmployerSteps(ScenarioContext context) => _employerStepsHelper = new EmployerStepsHelper(context);

        [When(@"Employer cancels after saving the title of the Vacancy")]
        public void WhenEmployerCancelsAfterSavingTheTitleOfTheVacancy() => vacanciesPage = _employerStepsHelper.CancelVacancy();

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
        public void ThenTheVacancyIsSavedAsADraft() => vacanciesPage.EditAndSubmit();

    }
}
