using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class FinalConfirmationPassPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Are you sure you want to pass this application?";

        public FinalConfirmationPassPage(ScenarioContext context) : base(context) => VerifyPage();

        public GateWayOutcomePage YesSurePassThisApplicationAndGoToGovernance()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new GateWayOutcomePage(context);
        }
    }
}