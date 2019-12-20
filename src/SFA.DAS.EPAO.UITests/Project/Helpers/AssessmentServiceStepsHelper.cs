using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class AssessmentServiceStepsHelper
    {

        private readonly ScenarioContext _context;
        private readonly EPAOConfig _ePAOConfig;
        private readonly EPAOSqlDataHelper _ePAOSqlDataHelper;

        public AssessmentServiceStepsHelper(ScenarioContext context)
        {
            _context = context;
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            _ePAOSqlDataHelper = context.Get<EPAOSqlDataHelper>();
        }

        public AS_LoggedInHomePage LoginToAssessmentServiceApplication() => new AS_LandingPage(_context).ClickStartButton().SignInWithValidDetails();

        public void CertifyApprentice(string enrolledStandards)
        {
            switch (enrolledStandards)
            {
                case "single":
                    _ePAOSqlDataHelper.DeleteCertificate(_ePAOConfig.ApprenticeUlnWithSingleStandard);
                    break;
                case "more than one":
                    _ePAOSqlDataHelper.DeleteCertificate(_ePAOConfig.ApprenticeNameWithMultipleStandards);
                    break;
                case "standard with learning option":
                    _ePAOSqlDataHelper.DeleteCertificate(_ePAOConfig.ApprenticeUlnWithAStandardHavingLearningOption);
                    break;
            }

            new AS_LoggedInHomePage(_context).ClickOnRecordAGrade()
                .SearchApprentice(_ePAOConfig.ApprenticeNameWithSingleStandard, _ePAOConfig.ApprenticeUlnWithSingleStandard)
                .ClickConfirmInConfirmApprenticePage()
                .ClickConfirmInDeclarationPage()
                .SelectPassAndContinueInGradeSelectionPage()
                .EnterAchievementDateAndContinue()
                .SearchAndSelectEmployerAddress()
                .ClickContinueInSearchEmployerAddressPage()
                .ClickContinueInConfirmEmployerAddressPage()
                .EnterRecipientDetailsAndContinue()
                .ClickContinueInCheckAndSubmitAssessmentPage();
        }
    }
}
