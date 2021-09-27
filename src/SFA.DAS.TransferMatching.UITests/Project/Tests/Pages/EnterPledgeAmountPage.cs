using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class EnterPledgeAmountPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Pledge amount and option to hide organisation name";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AvailablePledgeAmount => By.CssSelector(".app-highlight__figure");

        private By AmountCssSelector => By.CssSelector("#Amount");

        public EnterPledgeAmountPage(ScenarioContext context) : base(context) => _context = context;

        public EnterPledgeAmountPage CaptureAvailablePledgeAmount()
        {
            var amount = pageInteractionHelper.GetText(AvailablePledgeAmount);

            objectContext.SetAvailablePledgeAmount(amount);

            return this;
        }

        public void EnterAmount()
        {
            var amount = objectContext.GetAvailablePledgeAmount();

            formCompletionHelper.EnterText(AmountCssSelector, amount);

            formCompletionHelper.SelectRadioOptionByText("Yes");
        }


    }
}