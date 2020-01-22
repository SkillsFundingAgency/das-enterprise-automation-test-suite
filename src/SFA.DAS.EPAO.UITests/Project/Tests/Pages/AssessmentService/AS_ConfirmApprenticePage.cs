using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ConfirmApprenticePage : EPAO_BasePage
    {
        protected override string PageTitle => "Confirm this is the correct apprentice";
        private readonly ScenarioContext _context;

        #region Locators
        private By RadioButton => By.CssSelector("label");
        #endregion

        public AS_ConfirmApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_DeclarationPage ClickConfirmInConfirmApprenticePage(string enrolledStandard)
        {
            switch (enrolledStandard)
            {
                case "additional learning option":
                    SelectStandardWithAdditionalLearningOption();
                    break;
                case "more than one":
                    SelectFirstStandardFromMultipleOptions();
                    break;
            }

            Continue();

            return new AS_DeclarationPage(_context);
        }

        private void SelectStandardWithAdditionalLearningOption()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "standard_6");
        }

        private void SelectFirstStandardFromMultipleOptions()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "standard_122");
        }
    }
}
