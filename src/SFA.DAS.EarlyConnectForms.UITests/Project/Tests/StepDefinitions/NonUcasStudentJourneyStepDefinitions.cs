using SFA.DAS.EarlyConnectForms.UITests.Project.Helpers;
using SFA.DAS.EarlyConnectForms.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NonUcasStudentJourneyStepDefinitions(ScenarioContext context)
    {
        private readonly EarlyConnectStepsHelper _stepsHelper = new(context);

        [Given(@"I am on the landing page for a region '([^']*)'")]
        public void GivenIAmOnTheLandingPageForARegion(string lepCode)
        {

        }

        [Given(@"I am on the landing page for a region")]
        public void GivenIAmOnTheLandingPageForARegion()
        {
            _stepsHelper.GoToEarlyConnectHomePage();
            _stepsHelper.GoToEarlyConnectAdvisorPage();
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
        }

    }
}
