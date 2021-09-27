using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class CreateATransferPledgePage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Create a transfer pledge";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#pledge-create-submit");

        private By ColumnIdentifier => By.CssSelector(".das-task-list__task-tag");

        private string TableIdentifier => ".das-task-list__items";

        private string TableRowIdentifier => ".das-task-list__item";

        public CreateATransferPledgePage(ScenarioContext context) : base(context) => _context = context;

        public EnterPledgeAmountPage GoToPledgeAmountAndOptionPage()
        {
            formCompletionHelper.ClickLinkByText("Amount you want to pledge");
            return new EnterPledgeAmountPage(_context);
        }

        public PledgeVerificationPage ContinueToPledgeVerificationPage()
        {
            Continue();
            return new PledgeVerificationPage(_context);
        }

        public string GetAmount(string key) => GetValue(key, 0);

        public string GetCriteriaValue(string key) => GetValue(key, 1);

        private string GetValue(string key, int tableposition) => tableRowHelper.GetColumn(key, ColumnIdentifier, TableIdentifier, TableRowIdentifier, tableposition).Text;
    }
}