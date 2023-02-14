using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Roatp.UITests.Project;
using SFA.DAS.EsfaAdmin.Service.Project.Helpers;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RoatpAdminLoginSteps
    {
        private readonly RoatpAdminLoginStepsHelper _loginStepsHelper;
        private readonly RoatpConfig _config;

        public RoatpAdminLoginSteps(ScenarioContext context)
        {
            _loginStepsHelper = new RoatpAdminLoginStepsHelper(context);
            _config = context.GetRoatpConfig<RoatpConfig>();
        }

        [Given(@"the admin lands on the Dashboard as Assessor1")]
        public void GivenTheAdminLandsOnTheDashboardAsAssessor() => _loginStepsHelper.SubmitValidLoginDetails(_config.Assessor1UserName, _config.Assessor1Password);


        [Given(@"the admin lands on the Dashboard")]
        public void GivenTheAdminLandsOnTheDashboard() => _loginStepsHelper.SubmitValidLoginDetails();

    }
}