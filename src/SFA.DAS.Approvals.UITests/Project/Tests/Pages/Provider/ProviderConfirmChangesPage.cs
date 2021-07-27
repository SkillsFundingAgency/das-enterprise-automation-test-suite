using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderConfirmChangesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm changes";
        
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AcceptChangesOptions => By.Id("ConfirmChanges");
        private By FinishButton => By.Id("submit-confirm-change");

        public ProviderConfirmChangesPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderApprenticeDetailsPage AcceptChangesAndSubmit()
        {
            javaScriptHelper.ClickElement(AcceptChangesOptions);
            formCompletionHelper.ClickElement(FinishButton);
            return new ProviderApprenticeDetailsPage(_context);
        }

    }
}
