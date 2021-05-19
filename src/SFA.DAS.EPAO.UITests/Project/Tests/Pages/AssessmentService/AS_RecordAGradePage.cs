using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_RecordAGradePage : EPAO_BasePage
    {
        protected override string PageTitle => "Record a grade";
        private readonly ScenarioContext _context;
        private readonly EPAOApplySqlDataHelper _ePAOSqlDataHelper;

        #region Locators
        private By FamilyNameTextBox => By.Name("Surname");
        private By ULNTextBox => By.Name("Uln");
        private By PrivatelyFundedCheckBox => By.CssSelector("label");
        private By FamilyNameMissingErrorText => By.LinkText("Enter the apprentice's family name");
        private By ULNMissingErrorText => By.LinkText("Enter the apprentice's ULN");
        private By InvalidUlnErrorText => By.LinkText("The apprentice's ULN should contain exactly 10 numbers");
        #endregion

        public AS_RecordAGradePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _ePAOSqlDataHelper = context.Get<EPAOApplySqlDataHelper>();
            VerifyPage();
        }

        public AS_ConfirmApprenticePage SearchReRequestingApprentice()
        {
            EnterApprenticeDetailsAndContinue(ePAOConfig.ApprenticeNameDeleteWithAStandardHavingLearningOption, ePAOConfig.ApprenticeUlnDeleteWithAStandardHavingLearningOption);
            return new AS_ConfirmApprenticePage(_context);
        }

        public AS_AssesmentAlreadyRecorded GoToAssesmentAlreadyRecordedPage()
        {
            EnterApprenticeDetailsAndContinue(ePAOAdminDataHelper.LastName, ePAOAdminDataHelper.LearnerUln);
            return new AS_AssesmentAlreadyRecorded(_context);
        }

        public AS_ConfirmApprenticePage GoToConfirmApprenticePage()
        {
            EnterApprenticeDetailsAndContinue(ePAOAdminDataHelper.LastName, ePAOAdminDataHelper.LearnerUln);
            return new AS_ConfirmApprenticePage(_context);
        }

        public AS_ConfirmApprenticePage SearchApprentice() => SearchApprentice(ePAOAdminDataHelper.LastName, ePAOAdminDataHelper.LearnerUln);

        public AS_ConfirmApprenticePage SearchApprentice(string enrolledStandard)
        {
            return enrolledStandard switch
            {
                "deleting" => SearchApprentice(ePAOConfig.ApprenticeNameDeleteWithAStandardHavingLearningOption, ePAOConfig.ApprenticeUlnDeleteWithAStandardHavingLearningOption),
                "ReRequesting" => SearchReRequestingApprentice(),
                "PrivatelyFundedApprentice" => SearchApprentice(ePAOConfig.PrivatelyFundedApprenticeLastName, ePAOConfig.PrivatelyFundedApprenticeUln),
                _ => new AS_ConfirmApprenticePage(_context)
            };
        }

        private AS_ConfirmApprenticePage SearchApprentice(string apprenticeFamilyName, string leanerUln)
        {
            _ePAOSqlDataHelper.DeleteCertificate(leanerUln);

            EnterApprenticeDetailsAndContinue(apprenticeFamilyName, leanerUln);

            return new AS_ConfirmApprenticePage(_context);
        }


        public void EnterApprenticeDetailsAndContinue(string familyName, string uLN)
        {
            formCompletionHelper.EnterText(FamilyNameTextBox, familyName);
            formCompletionHelper.EnterText(ULNTextBox, uLN);
            Continue();
        }

        public void VerifyErrorMessage(string pageTitle) => VerifyPage(PageHeader, pageTitle);

        public bool VerifyFamilyNameMissingErrorText() => pageInteractionHelper.IsElementDisplayed(FamilyNameMissingErrorText);

        public bool VerifyULNMissingErrorText() => pageInteractionHelper.IsElementDisplayed(ULNMissingErrorText);

        public bool VerifyInvalidUlnErrorText() => pageInteractionHelper.IsElementDisplayed(InvalidUlnErrorText);

        public string GetPageTitle() => pageInteractionHelper.GetText(PageHeader);
    }
}