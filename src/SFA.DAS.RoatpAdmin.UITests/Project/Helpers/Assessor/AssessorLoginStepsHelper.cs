using SFA.DAS.Roatp.UITests.Project;
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

        public AssessorApplicationsPage Assessor1Login()
        {
            new AssessorSignInPage(_context).Login(_config.Assessor1UserName, _config.Assessor1Password);
            return new AssessorApplicationsPage(_context);
        }

        public AssessorApplicationsPage Assessor2Login()
        {
            new AssessorSignInPage(_context).Login(_config.Assessor2UserName, _config.Assessor2Password);
            return new AssessorApplicationsPage(_context);
        }
    }
}
