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

        [Given(@"I enter an already used email")]
        public void GivenIEnterAnAlreadyUsedEmail()
        {
            _stepsHelper.GoToAddAlreadyUsedEmailAddressPage();
        }

        [Then(@"I get the Already Completed Form Page")]
        public void ThenIGetTheAlreadyCompletedFormPage() => _stepsHelper.GoToCheckUsedEmailAuthCodePage();

        [Given(@"I selected the 'How apprenticeships work' link")]
        public void GivenISelectedTheHowApprenticeshipsWorkLink()
        {
            _stepsHelper.GoToBecomeAnApprenticePage();
        }

        [Given(@"I selected the 'Find an apprenticeship' link")]
        public void GivenISelectedTheFindAnApprenticeshipWorkLink()
        {
            _stepsHelper.GoToFindAnApprenticeshipPage();
        }

        [Given(@"I answer the triage questions up to the Support Page")]
        public void GivenIAnswerTheTriageQuestionsUpToTheSupportPage()
        {
            _stepsHelper.GoToAreasOfWorkInterestPage();
            _stepsHelper.GoToNameOfSchoolCollegePage();
            _stepsHelper.GoToApprencticeshipLevelPage();
            _stepsHelper.GoToHaveYouAppliedPage();
            _stepsHelper.GoToAreaOfEnglandPage();
        }

        [Then(@"I can navigate back to the first question")]
        public void ThenICanNavigateBackToTheFirstQuestion()
        {
            _stepsHelper.GoBackToAreaOfEnglandPage();
            _stepsHelper.GoBackToHaveYouAppliedPage();
            _stepsHelper.GoBackToApprencticeshipLevelPage();
            _stepsHelper.GoBackToNameOfSchoolCollegePage();
            _stepsHelper.GoBackToAreasOfWorkInterestPage();
            _stepsHelper.GoBackToWhatYourTelephonePage();
            _stepsHelper.GoBackToPostCodePage();
            _stepsHelper.GoBackToWhatIsYourDateOfBirthPage();
            _stepsHelper.GoBackToWhatYourNamePage();
        }
    }
}
