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

        private By AcceptChangesOptions => By.CssSelector(".selection-button-radio");
        private By FinishButton => By.CssSelector(".button");

        public ProviderConfirmChangesPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderApprenticeDetailsPage AcceptChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(AcceptChangesOptions, "changes-confirmed-true");
            formCompletionHelper.ClickElement(FinishButton);
            return new ProviderApprenticeDetailsPage(_context);
        }

    }
}
