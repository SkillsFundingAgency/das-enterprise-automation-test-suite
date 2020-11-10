using SFA.DAS.Roatp.UITests.Project.Hooks;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project
{
    [Binding, Scope(Tag = "roatpfulle2e")]
    public class RoatpFullE2EHooks : RoatpBaseHooks
    {
        public RoatpFullE2EHooks(ScenarioContext context) : base(context) { }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            SetUpApplyDataHelpers();
            SetUpAdminDataHelpers();
        }

        [BeforeScenario(Order = 33)]
        public new void GetRoatpFullData() => base.GetRoatpFullData();

        [BeforeScenario(Order = 34)]
        public new void ClearDownApplyData() => base.ClearDownApplyData();

        [BeforeScenario(Order = 35)]
        public new void WhiteListProviders() => base.WhiteListProviders();
    }
}
