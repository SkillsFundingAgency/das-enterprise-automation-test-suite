using SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmployerSteps(ScenarioContext context)
    {
        private readonly EmployerStepsHelper _employerStepsHelper = new(context);

        [Then(@"Employer can make the application successful")]
        public void ThenEmployerCanMakeTheApplicationSuccessful() => _employerStepsHelper.ApplicantSucessful();

        [Then(@"Employer can make the application unsuccessful")]
        public void ThenEmployerCanMakeTheApplicationUnsuccessful() => _employerStepsHelper.ApplicantUnsucessful();

        [Then(@"the Employer can close the vacancy")]
        public void ThenTheEmployerCanCloseTheVacancy() => _employerStepsHelper.CloseVacancy();

        [Then(@"the Employer can edit the vacancy")]
        public void ThenTheEmployerCanEditTheVacancy() => _employerStepsHelper.EditVacancyDates();

        [Then(@"the Employer verify '(National Minimum Wage For Apprentices|National Minimum Wage|Fixed Wage Type|Set As Competitive)' the wage option selected in the Preview page")]
        public void ThenTheEmployerVerifyTheWageOptionSelectedInThePreviewPage(string wageType) => _employerStepsHelper.VerifyWageType(wageType);
    }
}
