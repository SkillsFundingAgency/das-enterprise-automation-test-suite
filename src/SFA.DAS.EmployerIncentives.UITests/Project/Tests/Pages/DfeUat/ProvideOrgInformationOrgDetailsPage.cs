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

        public ProvideOrgInformationOrgDetailsPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public ProvideOrgAddressDetailsPage ContinueToAddressDetailsPage()
        {
            frameHelper.SwitchFrameAndAction(() => 
            {
                formCompletionHelper.EnterText(OrganisationName, registrationConfig.RE_OrganisationName);
                SelectOptionByText("legalname", "Yes");
                formCompletionHelper.EnterText(TelephoneNumber, eIDataHelper.TelephoneNumber);
                SelectOptionByText("provider_supplier_have_company_number", "No");
                SelectOptionByText("provider_supplier_have_vat_number", "No");
                SelectOptionByText("supplier_sme", "No");
                Continue();
            });

            return new ProvideOrgAddressDetailsPage(_context);
        }
    }
}
