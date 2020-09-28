using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.DfeUat
{
    public class ProvideOrgAddressDetailsPage : ProvideOrgInformationBasePage
    {
        protected override string PageTitle => "Address details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        private By AddressLine1 => By.CssSelector("#address1_vr");

        private By Town => By.CssSelector("#town_vr");

        private By Postcode => By.CssSelector("#postcode_vr");

        private By ContactEmail => By.CssSelector("#contact_remittance_email");

        private By FullName => By.CssSelector("#fcname");

        private By Fc_email => By.CssSelector("#fc_email");

        public ProvideOrgAddressDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public ProvideOrgBankDetailsPage SubmitAddressDetails(string email)
        {
            SelectRadioOptionByText("uk_address", "Yes");
            formCompletionHelper.EnterText(AddressLine1, "Cheylesmore House");
            formCompletionHelper.EnterText(Town, "Coventry");
            formCompletionHelper.EnterText(Postcode, "CV1 2WT");
            formCompletionHelper.EnterText(ContactEmail, email);
            formCompletionHelper.EnterText(FullName, registrationConfig.RE_OrganisationName);
            formCompletionHelper.EnterText(Fc_email, email);
            return new ProvideOrgBankDetailsPage(_context);
        }
    }
}
