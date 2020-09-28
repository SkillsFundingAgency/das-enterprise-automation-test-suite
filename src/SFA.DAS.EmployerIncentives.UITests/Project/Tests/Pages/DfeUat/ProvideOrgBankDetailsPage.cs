using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.DfeUat
{
    public class ProvideOrgBankDetailsPage : ProvideOrgInformationBasePage
    {
        protected override string PageTitle => "Bank details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        private By NameOfTheBank => By.CssSelector("#Name_of_bank");

        private By AccountName => By.CssSelector("#Bank_account_name");

        private By AccountNumber => By.CssSelector("#Account_number");

        private By SortCode => By.CssSelector("#sort_code");

        public ProvideOrgBankDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public void SubmitBankDetails()
        {
            SelectRadioOptionByText("account_type", "UK bank account");
            formCompletionHelper.EnterText(NameOfTheBank, "HSBC");
            formCompletionHelper.EnterText(AccountName, registrationConfig.RE_OrganisationName);
            formCompletionHelper.EnterText(AccountNumber, "22345610");
            formCompletionHelper.EnterText(SortCode, "000004");
            formCompletionHelper.ClickButtonByText("Add bank details");

        }

    }
}
