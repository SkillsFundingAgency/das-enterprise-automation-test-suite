using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    [Binding, Scope(Tag = "roatpapply"), Scope(Tag = "roatpfulle2e")]
    public class RoatpFullE2EHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;

        public RoatpFullE2EHooks(ScenarioContext context) : base(context) => _context = context;

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _context.Set(new RoatpApplyDataHelpers(_context.Get<RandomDataGenerator>()));

            _context.Set(new RoatpAdminDataHelpers(_context.Get<RandomDataGenerator>()));
        }
    }
}
