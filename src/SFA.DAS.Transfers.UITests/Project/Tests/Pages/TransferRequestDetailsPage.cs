using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class TransferRequestDetailsPage(ScenarioContext context) : TransfersBasePage(context)
    {
        protected override string PageTitle => "Transfer request details";

        protected override By ContinueButton => By.Id("submit-approve-transfer");

        public TransferRequestApprovedPage ApproveTransferRequest()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "ApprovalConfirmed");
            Continue();
            return new TransferRequestApprovedPage(context);
        }

        public TransferRequestRejectedPage RejectTransferRequest()
        {
            formCompletionHelper.SelectRadioOptionByForAttribute(RadioLabels, "ApprovalConfirmed-no");
            Continue();
            return new TransferRequestRejectedPage(context);
        }
    }
}