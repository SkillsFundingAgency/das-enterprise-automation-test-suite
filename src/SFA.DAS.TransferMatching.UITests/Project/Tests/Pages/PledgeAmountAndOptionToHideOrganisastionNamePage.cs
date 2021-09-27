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

        protected override By ContinueButton => By.CssSelector("#pledge-criteria-continue");

        public PledgeAmountAndOptionToHideOrganisastionNamePage(ScenarioContext context) : base(context) => _context = context;

        public PledgeAmountAndOptionToHideOrganisastionNamePage CaptureAvailablePledgeAmount()
        {
            var amount = pageInteractionHelper.GetText(AvailablePledgeAmount);

            amount = regexHelper.Replace(amount, new List<string>() {"£", "," });

            objectContext.SetAvailablePledgeAmount(int.Parse(amount));

            return this;
        }

        public CreateATransferPledgePage EnterAmountAndOrgName(bool showOrg)
        {
            var amount = objectContext.GetAvailablePledgeAmount();

            amount = tMDataHelper.PledgeAmount((amount / 2));

            formCompletionHelper.EnterText(AmountCssSelector, amount);

            if (showOrg)
                formCompletionHelper.SelectRadioOptionByText("Yes");
            else
                formCompletionHelper.SelectRadioOptionByText("No, I'd like our organisation to be anonymous");

            Continue();

            return new CreateATransferPledgePage(_context);
        }
    }
}