using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpapplyinprogressapplication")]
    public class RoatpApplyInProgressHooks(ScenarioContext context) : RoatpBaseHooks(context)
    {
        [BeforeScenario(Order = 33)]
        public new void GetRoatpFullData() => base.GetRoatpFullData();
    }
}
