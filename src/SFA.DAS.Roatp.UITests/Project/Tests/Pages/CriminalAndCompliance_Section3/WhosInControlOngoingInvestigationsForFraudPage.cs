using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.CriminalAndCompliance_Section3
{
    public class WhosInControlOngoingInvestigationsForFraudPage : RoatpBasePage
    {
        protected override string PageTitle => "have any ongoing investigations for fraud or irregularities?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_WhosInControlOngoingInvestigationsForFraudOrganisations => By.Id("CC-70.1");

        private By LongTextArea_WhosInControlOngoingInvestigationsForFraudSoleTrader => By.Id("CC-71.1");

        public WhosInControlOngoingInvestigationsForFraudPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlContractTerminatedByPublicBodyPage SelectYesEnterInformationForOngoingInvestigationForFraudAndContinue()
        {
            SelectRadioOptionByText("Yes");
            var field = pageInteractionHelper.IsElementDisplayed(LongTextArea_WhosInControlOngoingInvestigationsForFraudOrganisations) ? LongTextArea_WhosInControlOngoingInvestigationsForFraudOrganisations : LongTextArea_WhosInControlOngoingInvestigationsForFraudSoleTrader;
            formCompletionHelper.EnterText(field, applydataHelpers.WhosInControlOngoingInvestigationsForFraud);
            Continue();
            return new WhosInControlContractTerminatedByPublicBodyPage(_context);
        }
    }
}
