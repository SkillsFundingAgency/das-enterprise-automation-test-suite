using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAASteps
    {
        private readonly FAAStepsHelper _faaStepsHelper;
        private FAA_CreateAnAccountPage accountCreationPage;

        public FAASteps(ScenarioContext context)
        {
            _faaStepsHelper = new FAAStepsHelper(context);
        }

        [When(@"the Applicant apply for a Vacancy in FAA '(.*)','(.*)','(.*)'")]
        public void WhenTheApplicantApplyForAVacancyInFAA(string qualificationdetails, string workExperience, string trainingCourse)
        {
            var homePage = _faaStepsHelper.GoToFAAHomePage(true);

            var applicationFormPage = _faaStepsHelper.ApplyForVacancy(homePage);

            _faaStepsHelper.ConfirmApplicationSubmission(applicationFormPage, qualificationdetails, workExperience, trainingCourse);
        }

        [When(@"the Applicant withdraw the application")]
        public void WhenTheApplicantWithdrawTheApplication()
        {
            var homePage = _faaStepsHelper.GoToFAAHomePage(true);

            _faaStepsHelper.WithdrawVacancy(homePage);
        }

        [When(@"an Applicant initiates Account creation journey")]
        public void WhenAnApplicantInitiatesAccountCreationJourney()
        {
           accountCreationPage = _faaStepsHelper.StartFAAAccountCreation();
        }

        [Then(@"the Applicant is able to create a FAA Account")]
        public void ThenTheApplicantIsAbleToCreateAFAAAccount()
        {
            _faaStepsHelper.CreateFAAAccount(accountCreationPage);
        }
    }
}