using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmConnectionDetailsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Confirm details";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector(".button");

        private By ConnectWithReceivingEmpoyerOptions => By.CssSelector(".selection-button-radio");
        
        public ConfirmConnectionDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public RequestSentConfirmPage SendTransferConnectionRequest()
        {
            formCompletionHelper.SelectRadioOptionByText(ConnectWithReceivingEmpoyerOptions, "Yes, I want to send a request to connect");
            Continue();
            return new RequestSentConfirmPage(_context);
        }
    }
}