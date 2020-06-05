using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TransferRequestDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Transfer request details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.Id("submit-transfer-connection");
        private By ApprovalRadioButton => By.CssSelector(".selection-button-radio");

        public TransferRequestDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public TransferRequestApprovedPage ApproveTransferRequest()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ApprovalRadioButton, "ApprovalConfirmed-True");
            Continue();
            return new TransferRequestApprovedPage(_context);
        }

        public TransferRequestRejectedPage RejectTransferRequest()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ApprovalRadioButton, "ApprovalConfirmed-False");
            Continue();
            return new TransferRequestRejectedPage(_context);
        }
    }
}