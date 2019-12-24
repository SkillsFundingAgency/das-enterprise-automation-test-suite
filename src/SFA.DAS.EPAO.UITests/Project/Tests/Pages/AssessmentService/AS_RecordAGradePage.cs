using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_RecordAGradePage : BasePage
    {
        protected override string PageTitle => "Record a grade";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By FamilyNameTextBox => By.Name("Surname");
        private By ULNTextBox => By.Name("Uln");
        #endregion

        public AS_RecordAGradePage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_ConfirmApprenticePage SearchApprentice(string familyName, string uLN)
        {
            _formCompletionHelper.EnterText(FamilyNameTextBox, familyName);
            _formCompletionHelper.EnterText(ULNTextBox, uLN);
            Continue();
            return new AS_ConfirmApprenticePage(_context);
        }
    }
}
