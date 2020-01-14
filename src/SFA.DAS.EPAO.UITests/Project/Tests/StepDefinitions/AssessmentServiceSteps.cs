using NUnit.Framework;
using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AssessmentServiceSteps
    {
        private readonly ScenarioContext _context;
        private readonly AssessmentServiceStepsHelper _stepsHelper;
        private readonly EPAOConfig _ePAOConfig;
        private readonly TabHelper _tabHelper;
        private readonly EPAODataHelper _epaoDataHelper;
        private AS_RecordAGradePage _recordAGradePage;
        private AS_AchievementDatePage _achievementDatePage;
        private AS_CheckAndSubmitAssessmentPage _checkAndSubmitAssessmentPage;
        private AS_LoggedInHomePage _loggedInHomePage;

        public AssessmentServiceSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new AssessmentServiceStepsHelper(_context);
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            _epaoDataHelper = context.Get<EPAODataHelper>();
            _tabHelper = context.Get<TabHelper>();
        }

        [Given(@"the User is logged into Assessment Service Application")]
        public void GivenTheUserIsLoggedIntoAssessmentServiceApplication()
        {
            _tabHelper.GoToUrl(_ePAOConfig.EPAOAssessmentServiceUrl);
            _loggedInHomePage = _stepsHelper.LoginToAssessmentServiceApplication();
        }

        [When(@"the User goes through certifying an Apprentice as '(.*)' who has enrolled for '(.*)' standard")]
        public void WhenTheUserGoesThroughCertifyingAnApprenticeAsWhoHasEnrolledForStandard(string grade, string enrolledStandard)
        {
            _stepsHelper.CertifyApprentice(grade, enrolledStandard);
            new AS_CheckAndSubmitAssessmentPage(_context).ClickContinueInCheckAndSubmitAssessmentPage();
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
        public void ThenErrorMessageIsDisplayed(string errorMessage)
        {
            Assert.AreEqual(_recordAGradePage.GetPageTitle(), errorMessage);
        }

        [Then(@"the '(.*)' is displayed")]
        public void ThenErrorIsDisplayed(string errorMessage)
        {
            switch (errorMessage)
            {
                case "Family name and ULN missing error":
                    Assert.IsTrue(_recordAGradePage.VerifyFamilyNameMissingErrorText(), "FamilyName missing Error Text is incorrect");
                    Assert.IsTrue(_recordAGradePage.VerifyULNMissingErrorText(), "ULN missing Error Text is incorrect");
                    break;
                case "Family name missing error":
                    Assert.IsTrue(_recordAGradePage.VerifyFamilyNameMissingErrorText(), "FamilyName missing Error Text is incorrect");
                    break;
                case "ULN missing error":
                    Assert.IsTrue(_recordAGradePage.VerifyULNMissingErrorText(), "ULN missing Error Text is incorrect");
                    break;
                case "ULN validation error":
                    Assert.IsTrue(_recordAGradePage.VerifyInvalidUlnErrorText(), "ULN validation Error Text is incorrect");
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
            Assert.AreEqual(_achievementDatePage.GetDateErrorText(), errorText);
        }

        [When(@"the User is on the Confirm Assessment Page")]
        public void WhenTheUserIsOnTheConfirmAssessmentPage()
        {
            GivenTheUserIsLoggedIntoAssessmentServiceApplication();
            _stepsHelper.CertifyApprentice("Passed", "additional learning option");
        }

        [Then(@"the Change links navigate to the respective pages")]
        public void ThenTheChangeLinksNavigateToTheRespectivePages()
        {
            _checkAndSubmitAssessmentPage = new AS_CheckAndSubmitAssessmentPage(_context);

            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickGradeChangeLink().ClickBackLink();
            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickOptionChangeLink().ClickBackLink();
            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickAchievementDateChangeLink().ClickBackLink();
            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickNameChangeLink().ClickBackLink();
            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickDepartmentChangeLink().ClickBackLink();
            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickOrganisationChangeLink().ClickBackLink();
            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickCertificateAddressChangeLink().ClickBackLink();
        }

        [When(@"the User navigates to the Completed assessments tab")]
        public void WhenTheUserNavigatesToTheCompletedAssessmentsTab()
        {
            _loggedInHomePage.ClickCompletedAssessmentsLink();
        }

        [Then(@"the User is able to view the history of the assessments")]
        public void ThenTheUserIsAbleToViewTheHistoryOfTheAssessments()
        {
            new AS_CompletedAssessmentsPage(_context).VerifyTableHeaders();
        }
    }
}
