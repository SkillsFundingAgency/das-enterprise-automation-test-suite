using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpapplyinprogressapplication")]
    public class RoatpApplyInProgressHooks : RoatpBaseHooks
    {
        public RoatpApplyInProgressHooks(ScenarioContext context) : base(context) { }

        [BeforeScenario(Order = 33)]
        public new void GetRoatpFullData() => base.GetRoatpFullData();
    }
}
