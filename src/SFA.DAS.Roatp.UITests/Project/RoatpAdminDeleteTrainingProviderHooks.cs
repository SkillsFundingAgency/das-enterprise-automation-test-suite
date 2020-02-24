using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    [Binding] [Scope(Tag = "roatpadmin")]
    public class RoatpAdminDeleteTrainingProviderHooks
    {
        private readonly ScenarioContext _context;
        private readonly RoatpAdminClearDownDataHelpers _adminClearDownDataHelpers;

        public RoatpAdminDeleteTrainingProviderHooks(ScenarioContext context) 
        {
            _context = context;
            _adminClearDownDataHelpers = new RoatpAdminClearDownDataHelpers(context.Get<ObjectContext>(), context.GetRoatpConfig<RoatpConfig>(), context.Get<SqlDatabaseConnectionHelper>()); 
        }

        [BeforeScenario(Order = 34)]
        public void ClearDownAdminData() 
        { 
            if (_context.ScenarioInfo.Tags.Contains("deletetrainingprovider"))
            _adminClearDownDataHelpers.DeleteTrainingProvider(); 
        }
    }
}
