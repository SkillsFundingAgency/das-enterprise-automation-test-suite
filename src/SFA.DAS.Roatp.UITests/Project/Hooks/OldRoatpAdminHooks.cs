using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "oldroatpadmin")]
    public class OldRoatpAdminHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;
 
        public OldRoatpAdminHooks(ScenarioContext context) : base(context) => _context = context;

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => SetUpAdminDataHelpers();

        [BeforeScenario(Order = 33)]
        public new void GetOldRoatpAdminData()
        {
            if (!_context.ScenarioInfo.Tags.Contains("oldroatpadmindownloadprovider")) base.GetOldRoatpAdminData();
        }

        [BeforeScenario(Order = 34)]
        public void ClearDownAdminData()
        {
            if (_context.ScenarioInfo.Tags.Contains("deletetrainingprovider"))
                DeleteTrainingProvider();
        }
    }
}
