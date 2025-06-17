using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class ConfirmClarificationPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Are you sure you want to ask for clarification?";

        public ConfirmClarificationPage(ScenarioContext context) : base(context) => VerifyPage();

        public ClarificationOutcomePage YesClarificationRequired()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new ClarificationOutcomePage(context);
        }
    }
}
