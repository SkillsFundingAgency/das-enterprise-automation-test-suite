using SFA.DAS.RoatpAdmin.Service.Project;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpapply")]
    public class RoatpApplyHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;

        public RoatpApplyHooks(ScenarioContext context) : base(context) => _context = context;

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
        public void AllowListProviders() => base.AllowListProviders();

        [BeforeScenario(Order = 36)]
        public void ClearDownTrainingProvider()
        {
            if (_context.ScenarioInfo.Tags.Contains("roatpapplye2e"))
            {
                DeleteTrainingProvider();
            }
        }
    }
}
