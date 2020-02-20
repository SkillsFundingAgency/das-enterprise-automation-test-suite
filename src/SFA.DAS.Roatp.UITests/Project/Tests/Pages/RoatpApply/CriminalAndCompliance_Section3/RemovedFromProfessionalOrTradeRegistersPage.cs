using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class RemovedFromProfessionalOrTradeRegistersPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation been removed from any professional or trade registers in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RemovedFromProfessionalOrTradeRegistersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public InvoluntaryWithdrawlFromITTAccreditationPage SelectYesEnterInformationForFundingRemovedFromEducationBodies()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.RemovedFromProfessionalOrTradeRegisters);
            return new InvoluntaryWithdrawlFromITTAccreditationPage(_context);
        }
    }
}