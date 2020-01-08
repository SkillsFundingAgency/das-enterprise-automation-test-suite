using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_ConfirmApprenticePage : BasePage
    {
        protected override string PageTitle => "Confirm this is the correct apprentice";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By RadioButton => By.CssSelector("label");
        #endregion

        public AS_ConfirmApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
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
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "standard_6");
        }

        private void SelectFirstStandardFromMultipleOptions()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(RadioButton, "standard_122");
        }
    }
}
