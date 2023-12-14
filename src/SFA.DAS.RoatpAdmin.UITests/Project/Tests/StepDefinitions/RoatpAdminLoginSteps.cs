using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class RoatpAdminLoginSteps(ScenarioContext context)
    {
        private readonly DfeAdminLoginStepsHelper _dfeAdminLoginStepsHelper = new(context);

        [Given(@"the admin lands on the Dashboard as Assessor1")]
        public void GivenTheAdminLandsOnTheDashboardAsAssessor() => _dfeAdminLoginStepsHelper.LoginToAsAssessor1();

        [Given(@"the admin lands on the Dashboard")]
        public void GivenTheAdminLandsOnTheDashboard() => _dfeAdminLoginStepsHelper.NavigateAndLoginToASAdmin();
    }
}