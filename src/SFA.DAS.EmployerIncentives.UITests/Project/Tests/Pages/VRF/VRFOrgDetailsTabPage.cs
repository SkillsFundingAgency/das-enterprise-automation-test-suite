using OpenQA.Selenium;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFOrgDetailsTabPage : VRFBasePage
    {
        protected override string PageTitle => "Provide organisation details";
        private readonly EISqlHelper _eISqlHelper;

        #region Locators
        private readonly ScenarioContext _context;
        private By OrganisationName => By.CssSelector("#supplier_name");
        private By TelephoneNumber => By.CssSelector("#supplier_tel");
        private By VendorNumber => By.CssSelector("#vendor_number");
        #endregion

        public VRFOrgDetailsTabPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
            _eISqlHelper = _context.Get<EISqlHelper>();
        }

        public VRFNonBankingInfoTabPage SubmitOrgDetails()
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                SelectOptionByText("legalname", "Yes");
                AddOtherOrgDetails();
            });

            return new VRFNonBankingInfoTabPage(_context);
        }

        public VRFAmendmentsTabPage SubmitOrgDetailsForAmendJourney(string email)
        {
            var vendorNumber = _eISqlHelper.FetchAccountId(email);
            frameHelper.SwitchFrameAndAction(() =>
            {
                formCompletionHelper.EnterText(VendorNumber, $"P{vendorNumber}");
                AddOtherOrgDetails();
            });

            return new VRFAmendmentsTabPage(_context);
        }

        private void AddOtherOrgDetails()
        {
            formCompletionHelper.EnterText(OrganisationName, registrationConfig.RE_OrganisationName);
            formCompletionHelper.EnterText(TelephoneNumber, eIDataHelper.TelephoneNumber);
            SelectOptionByText("provider_supplier_have_company_number", "No");
            SelectOptionByText("provider_supplier_have_vat_number", "No");
            SelectOptionByText("supplier_sme", "No");
            Continue();
        }
    }
}
