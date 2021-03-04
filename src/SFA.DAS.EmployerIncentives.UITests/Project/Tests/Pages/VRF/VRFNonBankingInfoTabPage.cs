using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFNonBankingInfoTabPage : VRFBasePage
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

        public VRFNonBankingInfoTabPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public VRFBankDetailsTabPage SubmitAddressDetails(string email)
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                SelectOptionByText("uk_address", "Yes");
                formCompletionHelper.EnterText(AddressLine1, eIDataHelper.AddressLine1);
                formCompletionHelper.EnterText(Town, eIDataHelper.Town);
                formCompletionHelper.EnterText(Postcode, eIDataHelper.Poscode);
                formCompletionHelper.EnterText(ContactEmail, email);
                formCompletionHelper.EnterText(FullName, registrationConfig.RE_OrganisationName);
                formCompletionHelper.EnterText(Fc_email, email);
                Continue();
            });

            return new VRFBankDetailsTabPage(_context);
        }

        public VRFSubmitterDetailsTabPage SubmitNewRemittanceEmail(string email)
        {
            frameHelper.SwitchToFrame();
            formCompletionHelper.EnterText(ContactEmail, email);
            Continue();
            return new VRFSubmitterDetailsTabPage(_context);
        }
    }
}
