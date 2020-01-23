using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.EPAO.UITests.Project.Helpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_RecordAGradePage : EPAO_BasePage
    {
        protected override string PageTitle => "Record a grade";
        private readonly ScenarioContext _context;
        private readonly EPAOSqlDataHelper _ePAOSqlDataHelper;

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
            _ePAOSqlDataHelper = context.Get<EPAOSqlDataHelper>();
            VerifyPage();
        }

        public AS_ConfirmApprenticePage SearchApprentice(string enrolledStandard)
        {
            switch (enrolledStandard)
            {
                case "single":
                    _ePAOSqlDataHelper.DeleteCertificate(ePAOConfig.EPAOApprenticeUlnWithSingleStandard);
                    EnterApprentcieDetailsAndContinue(ePAOConfig.EPAOApprenticeNameWithSingleStandard, ePAOConfig.EPAOApprenticeUlnWithSingleStandard);
                    break;
                case "more than one":
                    _ePAOSqlDataHelper.DeleteCertificate(ePAOConfig.EPAOApprenticeUlnWithMultipleStandards);
                    EnterApprentcieDetailsAndContinue(ePAOConfig.EPAOApprenticeNameWithMultipleStandards, ePAOConfig.EPAOApprenticeUlnWithMultipleStandards);
                    break;
                case "additional learning option":
                    _ePAOSqlDataHelper.DeleteCertificate(ePAOConfig.EPAOApprenticeUlnWithAStandardHavingLearningOption);
                    EnterApprentcieDetailsAndContinue(ePAOConfig.EPAOApprenticeNameWithAStandardHavingLearningOption, ePAOConfig.EPAOApprenticeUlnWithAStandardHavingLearningOption);
                    break;
            }

            return new AS_ConfirmApprenticePage(_context);
        }

        public AS_DeclarationPage SearchPrivatelyFundedApprentice()
        {
            _ePAOSqlDataHelper.DeleteCertificate(ePAOConfig.EPAOPrivatelyFundedApprenticeUln);
            SelectPrivatelyFundedCheckBox();
            EnterApprentcieDetailsAndContinue(ePAOConfig.EPAOPrivatelyFundedApprenticeLastName, ePAOConfig.EPAOPrivatelyFundedApprenticeUln);
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
