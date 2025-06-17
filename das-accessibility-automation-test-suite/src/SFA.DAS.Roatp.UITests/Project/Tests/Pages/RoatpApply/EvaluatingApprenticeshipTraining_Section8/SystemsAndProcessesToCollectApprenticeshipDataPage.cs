using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.EvaluatingApprenticeshipTraining_Section8
{
    public class SystemsAndProcessesToCollectApprenticeshipDataPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Does your organisation have systems and processes in place to collect apprenticeship data?";

        public SystemsAndProcessesToCollectApprenticeshipDataPage(ScenarioContext context) : base(context) => VerifyPage();

        public SubmitILRDataPage SelectYesAndContinueOnCollectingDataPage()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new SubmitILRDataPage(context);
        }
    }
}
