using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NonUcasStudentJourneyStepDefinitions(ScenarioContext context)
    {
        private readonly EarlyConnectStepsHelper _stepsHelper = new(context);

        [Given(@"I am on the landing page for a region")]
        public void GivenIAmOnTheLandingPageForARegion() => _stepsHelper.GoToEarlyConnectHomePage();

        [Given(@"I selected North East Advisor Page")]
        public void GivenIISelectedNorthEastAdvisorPage()
        {
            _stepsHelper.GoToEarlyConnectNorthEastAdvisorPage();
            _stepsHelper.GoToEarlyConnectEmailPage();
        }

        [Given(@"I selected Lancashire Advisor Page")]
        public void GivenIISelectedLancashireAdvisorPage()
        {
            _stepsHelper.GoToEarlyConnectLancashireAdvisorPage();
            _stepsHelper.GoToEarlyConnectEmailPage();
        }

        [Given(@"I enter valid details")]
        public void GivenIEnterValidDetails()
        {
            _stepsHelper.GoToAddUniqueEmailAddressPage();
            _stepsHelper.GoToCheckEmailAuthCodePage();
            _stepsHelper.GoToWhatYourNamePage();
            _stepsHelper.GoToWhatIsYourDateOfBirthPage();
            _stepsHelper.GoToPostCodePage();
            _stepsHelper.GoToWhatYourTelephonePage();
        }

        [Given(@"I answer the triage questions related to me")]
        public void GivenIAnswerTheTriageQuestionsRelatedToMe()
        {
            _stepsHelper.GoToAreasOfWorkInterestPage();
            _stepsHelper.GoToNameOfSchoolCollegePage();
            _stepsHelper.GoToApprencticeshipLevelPage();
            _stepsHelper.GoToHaveYouAppliedPage();
            _stepsHelper.GoToAreaOfEnglandPage();
            _stepsHelper.GoToSupportPage();
        }

        [Then(@"I check my answers, accept and submit")]
        public void WhenICheckMyAnswersAcceptAndSubmit() => _stepsHelper.GoToCheckYourAnswerPage();

    }
}
