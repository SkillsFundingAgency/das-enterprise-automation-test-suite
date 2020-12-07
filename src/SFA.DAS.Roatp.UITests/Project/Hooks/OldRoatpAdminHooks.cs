using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using System;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "oldroatpadmin")]
    public class OldRoatpAdminHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;
        private readonly RoatpAdminSqlDbHelper _adminClearDownDataHelpers;
 
        public OldRoatpAdminHooks(ScenarioContext context) : base(context)
        {
            _context = context;
            _adminClearDownDataHelpers = new RoatpAdminSqlDbHelper(config);
        }

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
                _adminClearDownDataHelpers.DeleteTrainingProvider(GetUkprn());
        }
    }
}
