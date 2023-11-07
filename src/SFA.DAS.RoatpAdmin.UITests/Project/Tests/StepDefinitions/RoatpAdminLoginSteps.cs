using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RoatpAdminLoginSteps
    {
        private readonly DfeAdminLoginStepsHelper _dfeAdminLoginStepsHelper;

        public RoatpAdminLoginSteps(ScenarioContext context) => _dfeAdminLoginStepsHelper = new DfeAdminLoginStepsHelper(context);

        [Given(@"the admin lands on the Dashboard as Assessor1")]
        public void GivenTheAdminLandsOnTheDashboardAsAssessor() => _dfeAdminLoginStepsHelper.LoginToAsAssessor1();

        [Given(@"the admin lands on the Dashboard")]
        public void GivenTheAdminLandsOnTheDashboard() => _dfeAdminLoginStepsHelper.NavigateAndLoginToASAdmin();
    }
}