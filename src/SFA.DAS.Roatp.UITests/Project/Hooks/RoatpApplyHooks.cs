using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpapply"), Scope(Tag = "roatpapplytestdataprep")]
    public class RoatpApplyHooks : RoatpBaseHooks
    {
        public RoatpApplyHooks(ScenarioContext context) : base(context) { }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => SetUpApplyDataHelpers();

        [BeforeScenario(Order = 33)]
        public new void GetRoatpAppplyData() => base.GetRoatpAppplyData();
        
        [BeforeScenario(Order = 34)]
        public new void ClearDownApplyData() => base.ClearDownApplyData();

        [BeforeScenario(Order = 35)]
        public void WhiteListProviders() => base.WhiteListProviders();
    }
}
