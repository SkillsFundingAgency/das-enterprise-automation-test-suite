using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class EmpProRelationSteps(ScenarioContext context)
    {
        private readonly EmployerPortalLoginHelper _employerLoginHelper = new(context);

        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [Given(@"Levy employer grant create cohort permission to a provider")]
        public void LevyEmployerGrantCreateCohortPermissionToAProvider()
        {
            _employerLoginHelper.Login(context.GetUser<EPRLevyUser>(), true);

            context.Get<TabHelper>().GoToUrl(UrlConfig.EmployerProviderRelationships_BaseUrl(_objectContext.GetHashedAccountId()));
        }

        [Then(@"the provider should be added with the correct permissions")]
        public void TheProviderShouldBeAddedWithTheCorrectPermissions()
        {

        }

    }
}
