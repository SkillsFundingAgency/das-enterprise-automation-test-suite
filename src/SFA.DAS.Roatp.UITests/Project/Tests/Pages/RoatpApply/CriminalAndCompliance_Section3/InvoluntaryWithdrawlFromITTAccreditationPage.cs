using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.CriminalAndCompliance_Section3
{
    public class InvoluntaryWithdrawlFromITTAccreditationPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Has your organisation been involuntarily withdrawn from Initial Teacher Training accreditation in the last 3 years?";

        public InvoluntaryWithdrawlFromITTAccreditationPage(ScenarioContext context) : base(context) => VerifyPage();

        public RemovedFromCharityRegisterPage SelectYesEnterInformationForWithdrawlfromITTAccreditationAndContinue()
        {
            SelectRadioOptionByText("Yes");
            EnterLongTextAreaAndContinue(applydataHelpers.InvoluntaryWithdrawlFromITTAccreditation);
            return new RemovedFromCharityRegisterPage(context);
        }
    }
}