using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class RemovedFromProfessionalOrTradeRegistersPage : RoatpBasePage
    {
        protected override string PageTitle => "Has your organisation been removed from any professional or trade registers in the last 3 years?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea_RemovedFromProfessionalOrTradeRegisters => By.Id("CC-25.1");

        public RemovedFromProfessionalOrTradeRegistersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public InvoluntaryWithdrawlFromITTAccreditationPage SelectYesEnterInformationForFundingRemovedFromEducationBodies()
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(LongTextArea_RemovedFromProfessionalOrTradeRegisters, applydataHelpers.RemovedFromProfessionalOrTradeRegisters);
            Continue();
            return new InvoluntaryWithdrawlFromITTAccreditationPage(_context);
        }
    }
}