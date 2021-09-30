using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class TransferFundDetailsPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Transfer fund details for";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected override By ContinueButton => By.CssSelector("#apply-application-continue");

        public TransferFundDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public void ApplyForTransferFunds()
        {
            SelectRadioOptionByText("Yes, apply for transfer funds");

            Continue();
        }
    }
}