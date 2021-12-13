using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class TransferRequestDetailsPage : TransfersBasePage
    {
        protected override string PageTitle => "Transfer request details";

        protected override By ContinueButton => By.Id("submit-approve-transfer");
        private By ApprovalRadioButton => By.CssSelector(".govuk-radios__label");

        public TransferRequestDetailsPage(ScenarioContext context) : base(context) { }

        public TransferRequestApprovedPage ApproveTransferRequest()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ApprovalRadioButton, "ApprovalConfirmed");
            Continue();
            return new TransferRequestApprovedPage(_context);
        }

        public TransferRequestRejectedPage RejectTransferRequest()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(ApprovalRadioButton, "ApprovalConfirmed-no");
            Continue();
            return new TransferRequestRejectedPage(_context);
        }
    }
}