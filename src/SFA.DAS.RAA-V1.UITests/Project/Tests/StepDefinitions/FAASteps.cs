using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAASteps
    {
        private readonly FAAStepsHelper _faaStepsHelper;

        public FAASteps(ScenarioContext context)
        {
            _faaStepsHelper = new FAAStepsHelper(context);
        }

        [When(@"the Applicant apply for a Vacancy in FAA '(.*)','(.*)','(.*)'")]
        public void WhenTheApplicantApplyForAVacancyInFAA(string qualificationdetails, string workExperience, string trainingCourse)
        {
            var homePage = _faaStepsHelper.GoToFAAHomePage();

            var applicationFormPage = _faaStepsHelper.ApplyForVacancy(homePage);

             _faaStepsHelper.ConfirmApplicationSubmission(applicationFormPage, qualificationdetails, workExperience, trainingCourse);
        }
        
        [When(@"the Applicant withdraw the application")]
        public void WhenTheApplicantWithdrawTheApplication()
        {
            var homePage = _faaStepsHelper.GoToFAAHomePage();

            _faaStepsHelper.WithdrawVacancy(homePage);
        }

    }
}

