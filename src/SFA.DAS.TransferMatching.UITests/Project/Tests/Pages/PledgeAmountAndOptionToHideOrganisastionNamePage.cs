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

        private By ErrorMessageSelector => By.CssSelector(".govuk-error-summary");

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public PledgeAmountAndOptionToHideOrganisastionNamePage(ScenarioContext context) : base(context) => _context = context;

        public string GetErrorMessage() => pageInteractionHelper.GetText(ErrorMessageSelector);

        public PledgeAmountAndOptionToHideOrganisastionNamePage CaptureAvailablePledgeAmount()
        {
            var amount = pageInteractionHelper.GetText(AvailablePledgeAmount);

            amount = regexHelper.Replace(amount, new List<string>() { "£", "," });

            var availablepledgeamount = int.Parse(amount);

            objectContext.SetAvailablePledgeAmount(availablepledgeamount);

            ValidatePledgeAmount(availablepledgeamount);

            return this;
        }
        public PledgeAmountAndOptionToHideOrganisastionNamePage EnterMoreThanAvailableFunding()
        {
            EnterAmountAndOrgName(true, true);

            return new PledgeAmountAndOptionToHideOrganisastionNamePage(_context);
        }

        public CreateATransferPledgePage EnterAmountAndOrgName(bool showOrg)
        {
            EnterAmountAndOrgName(showOrg, false);

            return new CreateATransferPledgePage(_context);
        }

        private void EnterAmountAndOrgName(bool showOrg, bool exceedMaxFunding)
        {
            int amount = objectContext.GetAvailablePledgeAmount();

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