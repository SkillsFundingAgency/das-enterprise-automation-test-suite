using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFAmendmentsTabPage : VRFBasePage
    {
        protected override string PageTitle => "Provide amendments";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public VRFAmendmentsTabPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public VRFNonBankingInfoTabPage SelectChangeNonBankingInfoOptionAndContinue()
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                SelectOptionByText("change_address", "Yes");
                SelectOptionByText("c_rem_email", "remittance email");
                Continue();
            });

            return new VRFNonBankingInfoTabPage(_context);
        }
    }
}
