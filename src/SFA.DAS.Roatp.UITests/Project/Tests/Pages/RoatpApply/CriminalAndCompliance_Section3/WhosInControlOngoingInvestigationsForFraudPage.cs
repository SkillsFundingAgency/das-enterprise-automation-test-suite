using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class WhosInControlOngoingInvestigationsForFraudPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "have any ongoing investigations for fraud or irregularities?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public WhosInControlOngoingInvestigationsForFraudPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public WhosInControlContractTerminatedByPublicBodyPage SelectYesEnterInformationForOngoingInvestigationForFraudAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.WhosInControlOngoingInvestigationsForFraud);
            return new WhosInControlContractTerminatedByPublicBodyPage(_context);
        }
    }
}
