using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class RemovedFromProfessionalOrTradeRegistersPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation been removed from any professional or trade registers in the last 3 years?";

        public RemovedFromProfessionalOrTradeRegistersPage(ScenarioContext context) : base(context) => VerifyPage();

        public InvoluntaryWithdrawlFromITTAccreditationPage SelectYesEnterInformationForRemovedFromProfessionalOrTradeRegisters()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.RemovedFromProfessionalOrTradeRegisters);
            return new InvoluntaryWithdrawlFromITTAccreditationPage(context);
        }
    }
}