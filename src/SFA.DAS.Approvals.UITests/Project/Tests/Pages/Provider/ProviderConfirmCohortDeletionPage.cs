using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmCohortDeletionPage : BasePage
    {
        protected override string PageTitle => "Confirm cohort deletion";
        private By ConfirmDeleteOptions => By.CssSelector(".selection-button-radio");
        protected override By ContinueButton => By.CssSelector(".button");

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ProviderConfirmCohortDeletionPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public ProviderDeleteCohortPage ConfirmDeleteAndSubmit()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ConfirmDeleteOptions, "DeleteConfirmed-True");
            Continue();
            return new ProviderDeleteCohortPage(_context);
        }
    }
}
