using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class TransferConnectionRequestDetailsPage : TransfersBasePage
    {
        protected override string PageTitle => "Connection request details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By DoYouWishToConnectToThisEmpoyerOptions => By.CssSelector(".selection-button-radio");
        protected override By ContinueButton => By.CssSelector(".button");

        public TransferConnectionRequestDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public ConnectionConfirmedPage AcceptTransferConnectionRequest()
        {
            formCompletionHelper.SelectRadioOptionByText(DoYouWishToConnectToThisEmpoyerOptions, "Yes, I want to approve the connection request");
            Continue();
            return new ConnectionConfirmedPage(_context);
        }
    }
}