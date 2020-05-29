using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderCheckYourInformationPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Check your information";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ConfirmButton => By.CssSelector(".govuk-button");

        public ProviderCheckYourInformationPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderMakingChangesPage ConfirmReserveFunding()
        {
            formCompletionHelper.ClickElement(ConfirmButton);
            return new ProviderMakingChangesPage(_context);
        }

    }
}
