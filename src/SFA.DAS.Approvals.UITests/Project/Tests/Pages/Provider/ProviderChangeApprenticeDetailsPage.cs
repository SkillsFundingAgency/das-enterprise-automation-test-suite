using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderChangeApprenticeDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Change apprentice details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By DoYouWantToRequestChangesOptions => By.CssSelector(".selection-button-radio");
        private By FinishButton => By.CssSelector("#fix-mismatch, #finish");

        public ProviderChangeApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderApprenticeDetailsPage ConfirmRequestToFixILRMismatch()
        {
            formCompletionHelper.SelectRadioOptionByText(DoYouWantToRequestChangesOptions, "Yes, request this change");
            formCompletionHelper.ClickElement(FinishButton);
            return new ProviderApprenticeDetailsPage(_context);
        }
    }
}