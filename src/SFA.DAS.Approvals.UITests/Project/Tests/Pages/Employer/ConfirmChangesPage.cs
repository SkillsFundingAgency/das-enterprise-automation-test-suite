using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmChangesPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm changes";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ConfirmChangesRadio => By.CssSelector("#ConfirmChanges");
        private By ConfirmChangesCancelRadio => By.CssSelector("#ConfirmChanges-no");
        private By FinishButton => By.CssSelector("#submit-confirm-change");

        public ConfirmChangesPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeDetailsPage AcceptChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByLocator(ConfirmChangesRadio);
            formCompletionHelper.ClickElement(FinishButton);
            return new ApprenticeDetailsPage(_context);
        }
    }
}