using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmpProRelationSteps(ScenarioContext context)
    {
        private readonly EmployerPortalLoginHelper _employerLoginHelper = new(context);

        [Given(@"Levy employer grant create cohort permission to a provider")]
        public void LevyEmployerGrantCreateCohortPermissionToAProvider()
        {
            var homePage = _employerLoginHelper.Login(context.GetUser<EPRLevyUser>(), true);
        }

        [Then(@"the provider should be added with the correct permissions")]
        public void TheProviderShouldBeAddedWithTheCorrectPermissions()
        {

        }

    }
}
