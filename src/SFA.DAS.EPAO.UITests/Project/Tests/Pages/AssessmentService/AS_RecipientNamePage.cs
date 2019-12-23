using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_RecipientNamePage : BasePage
    {
        protected override string PageTitle => "What is the recipient's name?";
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By RecipientNameTextBox => By.Name("Name");
        private By DepartmentTextBox => By.Name("Dept");
        #endregion

        public AS_RecipientNamePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_CheckAndSubmitAssessmentPage EnterRecipientDetailsAndContinue()
        {
            _formCompletionHelper.EnterText(RecipientNameTextBox, "Mr Smith");
            _formCompletionHelper.EnterText(DepartmentTextBox, "IT");
            Continue();
            return new AS_CheckAndSubmitAssessmentPage(_context);
        }
    }
}
