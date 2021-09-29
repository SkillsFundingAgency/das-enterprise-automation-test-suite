using OpenQA.Selenium;
using System.Collections.Generic;
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

            amount = regexHelper.Replace(amount, new List<string>() {"£", "," });

            objectContext.SetAvailablePledgeAmount(int.Parse(amount));

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
                randomAmount = tMDataHelper.GenerateRandomNumberBetweenTwoValues(amount, (amount + randomAmount));
            else
                randomAmount = tMDataHelper.GenerateRandomNumberBetweenTwoValues(randomAmount);

            formCompletionHelper.EnterText(AmountCssSelector, randomAmount);

            if (showOrg)
                formCompletionHelper.SelectRadioOptionByText("Yes");
            else
                formCompletionHelper.SelectRadioOptionByText("No, I'd like our organisation to be anonymous");

            Continue();
        }
    }
}