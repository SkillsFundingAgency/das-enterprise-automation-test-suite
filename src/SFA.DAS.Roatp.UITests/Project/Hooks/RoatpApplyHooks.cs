using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpapply")]
    public class RoatpApplyHooks : RoatpBaseHooks
    {
        public RoatpApplyHooks(ScenarioContext context) : base(context) { }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => SetUpApplyDataHelpers();

        [BeforeScenario(Order = 33)]
        public new void GetRoatpAppplyData() => base.GetRoatpAppplyData();
        
        [BeforeScenario(Order = 34)]
        public void ClearDownDataUkprnFromApply()
        {
            ClearDownApplyData();
            ClearDownDataUkprnFromApply(_objectContext.GetUkprn());
        }

        [BeforeScenario(Order = 35)]
        public void WhiteListProviders() => base.WhiteListProviders();
    }
}
