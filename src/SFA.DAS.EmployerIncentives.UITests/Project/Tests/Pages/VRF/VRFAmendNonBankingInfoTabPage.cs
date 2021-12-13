using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFAmendNonBankingInfoTabPage : VRFBasePage
    {
        protected override string PageTitle => "New remittance details";

        #region Locators
        
        #endregion

        public VRFAmendNonBankingInfoTabPage(ScenarioContext context, Action action) : base(context, false) => frameHelper.SwitchFrameAndAction(() => VerifyPage(action));

        public VRFSubmitterDetailsTabPage SubmitNewRemittanceEmail(string email)
        {
            frameHelper.SwitchFrameAndAction(() =>
            {
                formCompletionHelper.EnterText(ContactEmail, email);
                Continue();
            });
            return new VRFSubmitterDetailsTabPage(context);
        }
    }
}
