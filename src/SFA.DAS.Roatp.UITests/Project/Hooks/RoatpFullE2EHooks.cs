using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpfulle2e")]
    public class RoatpFullE2EHooks : RoatpBaseHooks
    {
        public RoatpFullE2EHooks(ScenarioContext context) : base(context) { }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => SetUpApplyDataHelpers();

        [BeforeScenario(Order = 33)]
        public new void GetRoatpFullData() => base.GetRoatpFullData();

        [BeforeScenario(Order = 34)]
        public new void ClearDownApplyDataAndTrainingProvider() => base.ClearDownApplyDataAndTrainingProvider();

        [BeforeScenario(Order = 35)]
        public void AllowListProviders() => base.AllowListProviders();
    }
}
