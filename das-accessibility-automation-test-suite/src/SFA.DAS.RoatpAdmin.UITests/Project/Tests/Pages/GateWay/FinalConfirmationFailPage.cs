using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class FinalConfirmationFailPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Are you sure you want to fail this application?";

        public FinalConfirmationFailPage(ScenarioContext context) : base(context) => VerifyPage();

        public GateWayOutcomePage YesSureFailThisApplicationAndGoToGovernance()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new GateWayOutcomePage(context);
        }
    }
}