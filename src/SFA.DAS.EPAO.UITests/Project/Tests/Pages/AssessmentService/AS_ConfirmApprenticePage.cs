using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

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
        private By ConfirmAndContinueButton => By.CssSelector(".govuk-button");
        #endregion

        public AS_ConfirmApprenticePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_DeclarationPage ClickConfirmInConfirmApprenticePage()
        {
            _formCompletionHelper.Click(ConfirmAndContinueButton);
            return new AS_DeclarationPage(_context);
        }
    }
}
