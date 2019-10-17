using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmApprenticeDeletionPage : BasePage
    {
        protected override string PageTitle => "Confirm apprentice deletion";
        private By ConfirmDeleteOptions => By.CssSelector(".selection-button-radio");
        private By ContinueButton => By.CssSelector(".button");

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ProviderConfirmApprenticeDeletionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        internal ProviderReviewYourCohortPage ConfirmDeleteAndSubmit()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmDeleteOptions, "DeleteConfirmed-True");
            _formCompletionHelper.ClickElement(ContinueButton);
            return new ProviderReviewYourCohortPage(_context);
        }
    }
}
