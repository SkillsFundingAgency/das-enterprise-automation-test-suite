using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmApprenticeDeletionPage : BasePage
    {
        protected override string PageTitle => "Confirm apprentice deletion";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion
        private By ConfirmDeleteOptions => By.CssSelector(".selection-button-radio");
        private By ContinueButton => By.CssSelector(".button");

        public ConfirmApprenticeDeletionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ReviewYourCohortPage ConfirmDeleteAndSubmit()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmDeleteOptions, "DeleteConfirmed-True");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ReviewYourCohortPage(_context);
        }
    }
}