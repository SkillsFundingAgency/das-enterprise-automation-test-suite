using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpapplychangeukprn")]
    public class RoatpApplyChangeUkprnHooks : RoatpBaseHooks
    {
        public RoatpApplyChangeUkprnHooks(ScenarioContext context) : base(context) { }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => SetUpApplyDataHelpers();

        [BeforeScenario(Order = 33)]
        public new void GetRoatpChangeUkprnAppplyData() => base.GetRoatpChangeUkprnAppplyData();

        [BeforeScenario(Order = 34)]
        public void ClearDownDataUkprnFromApply()
        {
            ClearDownApplyData();
            ClearDownDataUkprnFromApply(_objectContext.GetUkprn());
            ClearDownDataUkprnFromApply(_objectContext.GetNewUkprn());
        }

        [BeforeScenario(Order = 35)]
        public void WhiteListProviders()
        {
            WhiteListProviders(_objectContext.GetUkprn());
            WhiteListProviders(_objectContext.GetNewUkprn());
        }
    }
}
