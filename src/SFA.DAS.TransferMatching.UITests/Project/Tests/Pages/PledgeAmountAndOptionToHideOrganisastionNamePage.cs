using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.Pages
{
    public class PledgeAmountAndOptionToHideOrganisastionNamePage : TransferMatchingBasePage
    {
        protected override string PageTitle => "Pledge amount and option to hide organisation name";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By AvailablePledgeAmount => By.CssSelector(".app-highlight__figure");

        private By AmountCssSelector => By.CssSelector("#Amount");

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public PledgeAmountAndOptionToHideOrganisastionNamePage(ScenarioContext context) : base(context) => _context = context;

        public PledgeAmountAndOptionToHideOrganisastionNamePage CaptureAvailablePledgeAmount()
        {
            var amount = pageInteractionHelper.GetText(AvailablePledgeAmount);

            var availablepledgeamount = regexHelper.GetAmount(amount);

            objectContext.SetEmployerTotalPledgeAmount(availablepledgeamount);

            ValidatePledgeAmount(availablepledgeamount);

            return this;
        }

        public PledgeAmountAndOptionToHideOrganisastionNamePage EnterInValidAmount(bool exceedMaxFunding)
        {
            EnterAmountAndOrgName(true, exceedMaxFunding);

            return new PledgeAmountAndOptionToHideOrganisastionNamePage(_context);
        }

        public CreateATransferPledgePage EnterValidAmountAndOrgName(bool showOrg)
        {
            EnterAmountAndOrgName(showOrg, false);

            return new CreateATransferPledgePage(_context);
        }

        private void EnterAmountAndOrgName(bool showOrg, bool exceedMaxFunding)
        {
            int amount = objectContext.GetEmployerTotalPledgeAmount();

            int randomAmount = amount / 2;

            if (exceedMaxFunding)
                randomAmount = tMDataHelper.GenerateRandomNumberMoreThanMaxAmount(amount);
            else
                randomAmount = ShouldValidatePledgeAmount() ? tMDataHelper.GenerateRandomNumberMoreThanMinAmount(amount) : tMDataHelper.GenerateRandomNumberLessThanMaxAmount(randomAmount);

            formCompletionHelper.EnterText(AmountCssSelector, randomAmount);

            if (showOrg)
                formCompletionHelper.SelectRadioOptionByText("Yes");
            else
                formCompletionHelper.SelectRadioOptionByText("No, I'd like our organisation to be anonymous");

            Continue();

            objectContext.SetPledgeAmount(randomAmount);
        }

        private void ValidatePledgeAmount(int availablepledgeamount)
        {
            if (ShouldValidatePledgeAmount())
            {
                var minAmount = tMDataHelper.MinAmount;

                Assert.GreaterOrEqual(availablepledgeamount, minAmount, $"Available pledge amount is less than the minimum amount needed, availablepledgeamount - {availablepledgeamount}, minAmount {minAmount}");
            }
        }

        private bool ShouldValidatePledgeAmount() => _context.ScenarioInfo.Tags.Contains("validatepledgeamount");

    }
}