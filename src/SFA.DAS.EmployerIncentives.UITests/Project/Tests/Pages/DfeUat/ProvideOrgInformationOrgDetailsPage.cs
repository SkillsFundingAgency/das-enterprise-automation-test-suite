using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.DfeUat
{
    public class ProvideOrgInformationOrgDetailsPage : ProvideOrgInformationBasePage
    {
        protected override string PageTitle => "Provide organisation details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        private By OrganisationName => By.CssSelector("#supplier_name");
        private By TelephoneNumber => By.CssSelector("#supplier_tel");

        public ProvideOrgInformationOrgDetailsPage(ScenarioContext context) : base(context) => _context = context;

        public ProvideOrgAddressDetailsPage ContinueToAddressDetailsPage()
        {
            formCompletionHelper.EnterText(OrganisationName, registrationConfig.RE_OrganisationName);
            SelectRadioOptionByText("legalname", "Yes");
            formCompletionHelper.EnterText(TelephoneNumber, "01234567899");
            SelectRadioOptionByText("provider_supplier_have_company_number", "No");
            SelectRadioOptionByText("provider_supplier_have_company_number", "No");
            SelectRadioOptionByText("supplier_sme", "No");
            formCompletionHelper.ClickButtonByText("Continue");
            return new ProvideOrgAddressDetailsPage(_context);
        }
    }
}
