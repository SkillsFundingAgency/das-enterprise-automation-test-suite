using SFA.DAS.Roatp.UITests.Project.Hooks;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpadmintestdataprep")]
    public class RoatpAdminTestDataPrepHooks : RoatpBaseHooks
    {
        public RoatpAdminTestDataPrepHooks(ScenarioContext context) : base(context) { }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            SetUpApplyDataHelpers();
            SetUpAdminDataHelpers();
        }

        [BeforeScenario(Order = 33)]
        public new void GetNewRoatpAdminData() => base.GetNewRoatpAdminData();

        [BeforeScenario(Order = 34)]
        public new void ClearDownApplyData() => base.ClearDownApplyData();

        [BeforeScenario(Order = 35)]
        public void WhiteListProviders() => base.WhiteListProviders();
    }
}
