using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFBankDetailsTabPage : VRFBasePage
    {
        protected override string PageTitle => "Bank details";

        #region Locators
        private static By NameOfTheBank => By.CssSelector("#Name_of_bank");
        private static By AccountName => By.CssSelector("#Bank_account_name");
        private static By AccountNumber => By.CssSelector("#Account_number");
        private static By SortCode => By.CssSelector("#sort_code");
        private static By AddBankDetails => By.CssSelector("#exp_validate");
        private static By BankDetailsAcceptedMessage => By.CssSelector(".fieldContent strong");
        #endregion

        public VRFBankDetailsTabPage(ScenarioContext context) : base(context, false) => frameHelper.SwitchFrameAndAction(() => VerifyPage());

        public VRFSubmitterDetailsTabPage SubmitBankDetails()
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                SelectOptionByText("account_type", "UK bank account");
                formCompletionHelper.EnterText(NameOfTheBank, eIDataHelper.BankName);
                formCompletionHelper.EnterText(AccountName, registrationDataHelper.CompanyTypeOrg);
                formCompletionHelper.EnterText(AccountNumber, eIDataHelper.AccountNumber);
                formCompletionHelper.EnterText(SortCode, eIDataHelper.Sortcode);
                formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(AddBankDetails), false);
                VerifyElement(BankDetailsAcceptedMessage);
                Continue();
            });

            return new VRFSubmitterDetailsTabPage(context);
        }
    }
}
