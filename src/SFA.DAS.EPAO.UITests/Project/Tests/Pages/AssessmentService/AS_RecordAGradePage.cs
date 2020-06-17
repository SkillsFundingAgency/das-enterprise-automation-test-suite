using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.EPAO.UITests.Project.Helpers;

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

        public AS_ConfirmApprenticePage SearchApprentice(string enrolledStandard)
        {
            switch (enrolledStandard)
            {
                case "single":
                    _ePAOSqlDataHelper.DeleteCertificate(ePAOConfig.ApprenticeUlnWithSingleStandard);
                    EnterApprentcieDetailsAndContinue(ePAOConfig.ApprenticeNameWithSingleStandard, ePAOConfig.ApprenticeUlnWithSingleStandard);
                    break;
                case "deleting":
                    _ePAOSqlDataHelper.DeleteCertificate(ePAOConfig.ApprenticeUlnDeleteWithAStandardHavingLearningOption);
                    EnterApprentcieDetailsAndContinue(ePAOConfig.ApprenticeNameDeleteWithAStandardHavingLearningOption, ePAOConfig.ApprenticeUlnDeleteWithAStandardHavingLearningOption);
                    break;
                case "ReRequesting":
                    EnterApprentcieDetailsAndContinue(ePAOConfig.ApprenticeNameDeleteWithAStandardHavingLearningOption, ePAOConfig.ApprenticeUlnDeleteWithAStandardHavingLearningOption);
                    break;
                case "more than one":
                    _ePAOSqlDataHelper.DeleteCertificate(ePAOConfig.ApprenticeUlnWithMultipleStandards);
                    EnterApprentcieDetailsAndContinue(ePAOConfig.ApprenticeNameWithMultipleStandards, ePAOConfig.ApprenticeUlnWithMultipleStandards);
                    break;
                case "additional learning option":
                    _ePAOSqlDataHelper.DeleteCertificate(ePAOConfig.ApprenticeUlnWithAStandardHavingLearningOption);
                    EnterApprentcieDetailsAndContinue(ePAOConfig.ApprenticeNameWithAStandardHavingLearningOption, ePAOConfig.ApprenticeUlnWithAStandardHavingLearningOption);
                    break;
            }

            return new AS_ConfirmApprenticePage(_context);
        }

        public AS_DeclarationPage SearchPrivatelyFundedApprentice()
        {
            _ePAOSqlDataHelper.DeleteCertificate(ePAOConfig.PrivatelyFundedApprenticeUln);
            SelectPrivatelyFundedCheckBox();
            EnterApprentcieDetailsAndContinue(ePAOConfig.PrivatelyFundedApprenticeLastName, ePAOConfig.PrivatelyFundedApprenticeUln);
            return new AS_DeclarationPage(_context);
        }

        public void EnterApprentcieDetailsAndContinue(string familyName, string uLN)
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

        private void SelectPrivatelyFundedCheckBox() => formCompletionHelper.SelectRadioOptionByForAttribute(PrivatelyFundedCheckBox, "IsPrivatelyFunded");
    }
}