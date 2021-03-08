using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFAmendNonBankingInfoTabPage : VRFBasePage
    {
        protected override string PageTitle => "New remittance details";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public VRFAmendNonBankingInfoTabPage(ScenarioContext context) : base(context, false)
        {
            _context = context;
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
        }

        public VRFSubmitterDetailsTabPage SubmitNewRemittanceEmail(string email)
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                formCompletionHelper.EnterText(ContactEmail, email);
                Continue();
            });
            return new VRFSubmitterDetailsTabPage(_context);
        }
    }
}
