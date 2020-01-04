using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AssessmentServiceSteps
    {
        private readonly ScenarioContext _context;
        private readonly AssessmentServiceStepsHelper _stepsHelper;
        private readonly EPAOConfig _ePAOConfig;
        private AS_RecordAGradePage _recordAGradePage;
        private EPAODataHelper _epaoDataHelper;
        private AS_AchievementDatePage _achievementDatePage;

        public AssessmentServiceSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new AssessmentServiceStepsHelper(_context);
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            _epaoDataHelper = context.Get<EPAODataHelper>();
        }

        [Given(@"the User is logged into Assessment Service Application")]
        public void GivenTheUserIsLoggedIntoAssessmentServiceApplication()
        {
            _stepsHelper.LoginToAssessmentServiceApplication();
        }

        [When(@"the User goes through certifying an Apprentice as '(.*)' who has enrolled for '(.*)' standard")]
        public void WhenTheUserGoesThroughCertifyingAnApprenticeAsWhoHasEnrolledForStandard(string grade, string enrolledStandard)
        {
            _stepsHelper.CertifyApprentice(grade, enrolledStandard);
        }

        [When(@"the User goes through certifying a Privately funded Apprentice")]
        public void WhenTheUserGoesThroughCertifyingAPrivatelyFundedApprentice()
        {
            _stepsHelper.CertifyPrivatelyFundedApprentice();
        }

        [Then(@"the Assessment is recorded and the User is able to navigate back to certifying another Apprentice")]
        public void ThenTheAssessmentIsRecordedAndTheUserIsAbleToNavigateBackToCertifyingAnotherApprentice()
        {
            new AS_AssessmentRecordedPage(_context).ClickRecordAnotherGradeLinkInAssessmentRecordedPage();
        }

        [When(@"the User goes through certifying an already assessed Apprentice")]
        public void WhenTheUserGoesThroughCertifyingAnAlreadyAssessedApprentice()
        {
            new AS_LoggedInHomePage(_context).ClickOnRecordAGrade();
            _recordAGradePage = new AS_RecordAGradePage(_context);
            _recordAGradePage.EnterApprentcieDetailsAndContinue(_ePAOConfig.EPAOAlreadyAssessedApprenticeName, _ePAOConfig.EPAOAlreadyAssessedApprenticeUln);
        }

        [Then(@"'(.*)' message is displayed")]
        public void ThenMessageIsDisplayed(string errorMessage)
        {
            _recordAGradePage.VerifyErrorMessage(errorMessage);
        }

        [Then(@"the '(.*)' is displayed")]
        public void ThenErrorIsDisplayed(string errorMessage)
        {
            switch (errorMessage)
            {
                case "Family name and ULN missing error":
                    _recordAGradePage.VerifyFamilyNameMissingErrorText();
                    _recordAGradePage.VerifyULNMissingErrorText();
                    break;
                case "Family name missing error":
                    _recordAGradePage.VerifyFamilyNameMissingErrorText();
                    break;
                case "ULN missing error":
                    _recordAGradePage.VerifyULNMissingErrorText();
                    break;
                case "ULN validation error":
                    _recordAGradePage.VerifyInvalidUlnErrorText();
                    break;
            }
        }

        [When(@"the User clicks on the continue button '(.*)'")]
        public void WhenTheUserClicksOnTheContinueButton(string scenario)
        {
            _recordAGradePage = new AS_RecordAGradePage(_context);

            switch (scenario)
            {
                case "with out entering Any details":
                    _recordAGradePage.EnterApprentcieDetailsAndContinue("", "");
                    break;
                case "by entering valid Family name and blank ULN":
                    _recordAGradePage.EnterApprentcieDetailsAndContinue(_ePAOConfig.EPAOApprenticeNameWithSingleStandard, "");
                    break;
                case "by entering blank Family name and Valid ULN":
                    _recordAGradePage.EnterApprentcieDetailsAndContinue("", _ePAOConfig.EPAOApprenticeUlnWithSingleStandard);
                    break;
                case "by entering valid Family name but ULN less than 10 digits":
                    _recordAGradePage.EnterApprentcieDetailsAndContinue(_ePAOConfig.EPAOApprenticeNameWithSingleStandard, _epaoDataHelper.Get9DigitRandomULN);
                    break;
                case "by entering valid Family name and Invalid ULN":
                    _recordAGradePage.EnterApprentcieDetailsAndContinue(_ePAOConfig.EPAOApprenticeNameWithSingleStandard, _epaoDataHelper.Get10DigitRandomULN);
                    break;
            }
        }

        [Given(@"navigates to Assessment page")]
        public void GivenNavigatesToAssessmentPage() => new AS_LoggedInHomePage(_context).ClickOnRecordAGrade();

        [Given(@"the User is on the Apprenticeship achievement date page")]
        public void GivenTheUserIsOnTheApprenticeshipAchievementDatePage()
        {
            _stepsHelper.CertifyPrivatelyFundedApprentice(true);
        }

        [When(@"the User enters the date before the Year 2017")]
        public void WhenTheUserEntersTheDateBeforeTheYear2017()
        {
            _achievementDatePage = new AS_AchievementDatePage(_context);
            _achievementDatePage.EnterAchievementGradeDateForPrivatelyFundedApprenticeAndContinue(2016);
        }

        [When(@"the User enters the future date")]
        public void WhenTheUserEntersTheFutureDate()
        {
            _achievementDatePage.EnterAchievementGradeDateForPrivatelyFundedApprenticeAndContinue(_epaoDataHelper.GetCurrentYear+1);
        }

        [Then(@"(.*) is displayed in the Apprenticeship achievement date page")]
        public void ThenDateErrorIsDisplayedInTheApprenticeshipAchievementDatePage(string errorText)
        {
            _achievementDatePage.VerifyDateErrorText(errorText);
        }
    }
}
