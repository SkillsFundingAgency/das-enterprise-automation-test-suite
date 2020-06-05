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

        private By AcceptChangesOptions => By.CssSelector(".selection-button-radio");
        private By FinishButton => By.CssSelector("#submit-confirm-change");

        public ConfirmChangesPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeDetailsPage AcceptChangesAndSubmit()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(AcceptChangesOptions, "changes-confirmed-true");
            formCompletionHelper.ClickElement(FinishButton);
            return new ApprenticeDetailsPage(_context);
        }
    }
}