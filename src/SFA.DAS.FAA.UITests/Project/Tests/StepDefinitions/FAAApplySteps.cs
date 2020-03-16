using SFA.DAS.FAA.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class FAAApplySteps
    {
        private readonly FAAStepsHelper _faaStepsHelper;
        
        public FAAApplySteps(ScenarioContext context)
        {
            _faaStepsHelper = new FAAStepsHelper(context);
        }

        [Given(@"the Applicant can apply for a Vacancy in FAA")]
        [Then(@"the Applicant can apply for a Vacancy in FAA")]
        [When(@"the Applicant can apply for a Vacancy in FAA")]
        public void WhenTheApplicantCanApplyForAVacancyInFAA()
        {
            _faaStepsHelper.ApplyForAVacancy("No", "No", "No");
        }
        
        [When(@"the Applicant apply for a Vacancy in FAA '(.*)','(.*)','(.*)'")]
        public void WhenTheApplicantApplyForAVacancyInFAA(string qualificationdetails, string workExperience, string trainingCourse)
        {
            _faaStepsHelper.ApplyForAVacancy(qualificationdetails, workExperience, trainingCourse);
        }
    }
}