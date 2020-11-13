using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages;
using SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Assessor;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Helpers.Assessor
{
    public class AssessorLoginStepsHelper
    {
        private readonly RoatpConfig _config;
        private readonly ScenarioContext _context;

        public AssessorLoginStepsHelper(ScenarioContext context)
        {
            _context = context;
            _config = context.GetRoatpConfig<RoatpConfig>();
        }

        public RoatpApplicationsHomePage Assessor1Login() => AssessorLogin(_config.Assessor1UserName, _config.Assessor1Password);

        public RoatpApplicationsHomePage Assessor2Login() => AssessorLogin(_config.Assessor2UserName, _config.Assessor2Password);

        private RoatpApplicationsHomePage AssessorLogin(string username, string password)
        {
            new AssessorSignInPage(_context).Login(username, password);
            return new RoatpApplicationsHomePage(_context);
        }
    }
}
