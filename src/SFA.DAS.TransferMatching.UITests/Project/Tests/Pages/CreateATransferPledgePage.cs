using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{

    public class PledgeVerificationPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Your pledge has been created as pledge";

        protected override By PageHeader => By.CssSelector(".govuk-panel__title");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PledgeVerificationPage(ScenarioContext context) : base(context) => _context = context;


        public PledgeVerificationPage SetPledgeId()
        {
            var value = pageInteractionHelper.GetText(PageHeader);

            var pledgeid = regexHelper.Replace(value, new List<string>() { PageTitle });

            objectContext.SetPledgeId(pledgeid);

            return this;
        }

        public MyTransferPledgesPage ViewYourPledges()
        {
            formCompletionHelper.ClickLinkByText("View your pledges");

            return new MyTransferPledgesPage(_context);
        }
    }

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


        public EnterPledgeAmountPage EnterPledgeAmount()
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