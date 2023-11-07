using SFA.DAS.EsfaAdmin.Service.Project.Helpers;
using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RoatpAdminLoginSteps
    {
        private readonly ScenarioContext _context;
        private readonly RoatpConfig _config;

        public RoatpAdminLoginSteps(ScenarioContext context)
        {
            _context = context;
            _config = context.GetRoatpConfig<RoatpConfig>();
        }

        [Given(@"the admin lands on the Dashboard as Assessor1")]
        public void GivenTheAdminLandsOnTheDashboardAsAssessor() => new EsfaAdminLoginStepsHelper(_context).SubmitValidLoginDetails(_config.Assessor1UserName, _config.Assessor1Password);

        [Given(@"the admin lands on the Dashboard")]
        public void GivenTheAdminLandsOnTheDashboard() => new DfeAdminLoginStepsHelper(_context).NavigateAndLoginToASAdmin();
    }
}