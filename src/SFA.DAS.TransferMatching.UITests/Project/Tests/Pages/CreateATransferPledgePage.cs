using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class CreateATransferPledgePage : TransferMatchingBasePage
    {

        protected override string PageTitle => "Create a transfer pledge";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public CreateATransferPledgePage(ScenarioContext context) : base(context) => _context = context;


        public EnterPledgeAmountPage EnterPledgeAmount()
        {
            formCompletionHelper.ClickLinkByText("Amount you want to pledge");
            return new EnterPledgeAmountPage(_context);
        }
    }
}