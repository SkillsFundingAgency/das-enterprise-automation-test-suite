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
        private By DoYouWantToRequestChangesOptions => By.XPath("//input[@value='Confirm']");
        private By FinishButton => By.Id("finish-button");

        public ProviderChangeApprenticeDetailsPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderApprenticeDetailsPage ConfirmRequestToFixILRMismatch()
        {
            javaScriptHelper.ClickElement(DoYouWantToRequestChangesOptions);
            formCompletionHelper.ClickElement(FinishButton);
            return new ProviderApprenticeDetailsPage(_context);
        }
    }
}