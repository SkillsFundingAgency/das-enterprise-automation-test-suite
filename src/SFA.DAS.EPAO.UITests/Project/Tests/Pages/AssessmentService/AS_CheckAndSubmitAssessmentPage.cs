using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_CheckAndSubmitAssessmentPage : BasePage
    {
        protected override string PageTitle => "Check and submit the assessment details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        #endregion

        #region Locators
        private By ConfirmAndSubmitButton => By.CssSelector(".govuk-button");
        #endregion

        public AS_CheckAndSubmitAssessmentPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public AS_AssessmentRecordedPage ClickContinueInCheckAndSubmitAssessmentPage()
        {
            _formCompletionHelper.Click(ConfirmAndSubmitButton);
            return new AS_AssessmentRecordedPage(_context);
        }
    }
}
