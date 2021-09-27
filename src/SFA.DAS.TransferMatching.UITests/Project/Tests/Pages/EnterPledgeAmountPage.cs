using OpenQA.Selenium;
using System.Collections.Generic;
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

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public EnterPledgeAmountPage(ScenarioContext context) : base(context) => _context = context;

        public EnterPledgeAmountPage CaptureAvailablePledgeAmount()
        {
            var amount = pageInteractionHelper.GetText(AvailablePledgeAmount);

            amount = regexHelper.Replace(amount, new List<string>() {"£", "," });

            objectContext.SetAvailablePledgeAmount(int.Parse(amount));

            return this;
        }

        public CreateATransferPledgePage EnterAmountAndShowOrgName()
        {
            var amount = objectContext.GetAvailablePledgeAmount();

            amount = tMDataHelper.PledgeAmount((amount / 2 ));

            formCompletionHelper.EnterText(AmountCssSelector, amount);

            formCompletionHelper.SelectRadioOptionByText("Yes");

            Continue();

            return new CreateATransferPledgePage(_context);
        }
    }
}