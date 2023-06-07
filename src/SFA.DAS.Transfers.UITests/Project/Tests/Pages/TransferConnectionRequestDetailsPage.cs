using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Transfers.UITests.Project.Tests.Pages
{
    public class TransferConnectionRequestDetailsPage : TransfersBasePage
    {
        protected override string PageTitle => "Connection request details";

        private By DoYouWishToConnectToThisEmpoyerOptions => By.CssSelector(".govuk-radios__label");
        protected override By ContinueButton => By.XPath("//button[text()='Continue']");

        public TransferConnectionRequestDetailsPage(ScenarioContext context) : base(context) { }

        public ConnectionConfirmedPage AcceptTransferConnectionRequest()
        {
            formCompletionHelper.SelectRadioOptionByText(DoYouWishToConnectToThisEmpoyerOptions, "Yes, I want to approve the connection request");
            Continue();
            return new ConnectionConfirmedPage(context);
        }
    }
}