using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class PledgeAmountPage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Pledge amount";

        private By AvailablePledgeAmount => By.CssSelector("#remaining-transfer-balance");

        private By AmountCssSelector => By.CssSelector("#Amount");

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public PledgeAmountPage(ScenarioContext context) : base(context) { }

        public PledgeAmountPage CaptureAvailablePledgeAmount()
        {
            var amount = pageInteractionHelper.GetText(AvailablePledgeAmount);

            var availablepledgeamount = RegexHelper.GetAmount(amount);

            objectContext.SetEmployerTotalPledgeAmount(availablepledgeamount);

            return this;
        }

        public PledgeAmountPage EnterInValidAmount()
        {
            EnterAmount(true);

            return new PledgeAmountPage(context);
        }

        public CreateATransferPledgePage EnterInValidAmountForCreateAPledge(bool useMinimalFunding = false)
        {
            EnterAmount(false, useMinimalFunding);

            return new CreateATransferPledgePage(context);
        }

        private void EnterAmount(bool exceedMaxFunding, bool useMinimalFunding = false)
        {
            int amount = objectContext.GetEmployerTotalPledgeAmount();
            if (!exceedMaxFunding && useMinimalFunding && amount > tMDataHelper.MinimalPledgeAmount)
            {
                amount = tMDataHelper.MinimalPledgeAmount;
            }
            int randomAmount = exceedMaxFunding ? tMDataHelper.GenerateRandomNumberMoreThanMaxAmount(amount) : ValidatePledgeAmount(amount);
            
            formCompletionHelper.EnterText(AmountCssSelector, randomAmount);

            Continue();

            objectContext.SetPledgeAmount(randomAmount);
        }

        private int ValidatePledgeAmount(int availablepledgeamount)
        {
            var minAmount = tMDataHelper.MinAmount;

            Assert.GreaterOrEqual(availablepledgeamount, minAmount, $"Available pledge amount is less than the minimum amount needed, availablepledgeamount - {availablepledgeamount}, minAmount {minAmount}");

            return tMDataHelper.GenerateRandomNumberMoreThanMinAmount(availablepledgeamount);
        }
    }
}