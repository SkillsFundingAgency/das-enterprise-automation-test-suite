using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class PledgeAmountPage(ScenarioContext context) : TransferMatchingBasePage(context)
    {
        protected override string PageTitle => "Pledge amount";

        private static By AvailablePledgeAmount => By.CssSelector("#remaining-transfer-balance");

        private static By AmountCssSelector => By.CssSelector("#Amount");

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

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

        public CreateATransferPledgePage EnterInValidAmountForCreateAPledge(bool useMinimalFunding = false, bool useFundingEqualToEstimatedCost = false)
        {
            EnterAmount(false, useMinimalFunding, useFundingEqualToEstimatedCost);

            return new CreateATransferPledgePage(context);
        }

        private void EnterAmount(bool exceedMaxFunding, bool useMinimalFunding = false, bool useFundingEqualToEstimatedCost = false)
        {
            int amount = objectContext.GetEmployerTotalPledgeAmount();
            if (!exceedMaxFunding && useMinimalFunding && amount > tMDataHelper.MinimalPledgeAmount)
            {
                amount = tMDataHelper.MinimalPledgeAmount;
            }

            int randomAmount = exceedMaxFunding ? Helpers.TMDataHelper.GenerateRandomNumberMoreThanMaxAmount(amount) : ValidatePledgeAmount(amount);

            int pledgeAmount = !useFundingEqualToEstimatedCost ? randomAmount
                                : tMDataHelper.GetEstimatedCostOfTrainingForApplicationDetail().CurrencyStringToInt().Value + 1;
            formCompletionHelper.EnterText(AmountCssSelector, pledgeAmount);

            Continue();

            objectContext.SetPledgeAmount(pledgeAmount);
        }

        private int ValidatePledgeAmount(int availablepledgeamount)
        {
            var minAmount = tMDataHelper.MinAmount;

            Assert.GreaterOrEqual(availablepledgeamount, minAmount, $"Available pledge amount is less than the minimum amount needed, availablepledgeamount - {availablepledgeamount}, minAmount {minAmount}");

            return tMDataHelper.GenerateRandomNumberMoreThanMinAmount(availablepledgeamount);
        }
    }
}