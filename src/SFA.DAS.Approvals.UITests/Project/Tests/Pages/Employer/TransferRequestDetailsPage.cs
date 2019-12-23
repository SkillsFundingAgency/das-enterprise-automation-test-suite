using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class TransferRequestDetailsPage : BasePage
    {
        protected override string PageTitle => "Transfer request details";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.Id("submit-transfer-connection");
        private By ApprovalRadioButton => By.CssSelector(".selection-button-radio");

        public TransferRequestDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public TransferRequestApprovedPage ApproveTransferRequest()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ApprovalRadioButton, "ApprovalConfirmed-True");
            Continue();
            return new TransferRequestApprovedPage(_context);
        }

        public TransferRequestRejectedPage RejectTransferRequest()
        {
            _formCompletionHelper.SelectRadioOptionByForAttribute(ApprovalRadioButton, "ApprovalConfirmed-False");
            Continue();
            return new TransferRequestRejectedPage(_context);
        }
    }
}