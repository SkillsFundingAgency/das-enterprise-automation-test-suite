using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFOrgDetailsTab2Page : VRFBasePage
    {
        protected override string PageTitle => "Provide organisation details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        private By OrganisationName => By.CssSelector("#supplier_name");
        private By TelephoneNumber => By.CssSelector("#supplier_tel");

        public VRFOrgDetailsTab2Page(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public VRFNonBankingInfoTab3Page SubmitOrgDetails()
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

            return new VRFNonBankingInfoTab3Page(_context);
        }
    }
}
