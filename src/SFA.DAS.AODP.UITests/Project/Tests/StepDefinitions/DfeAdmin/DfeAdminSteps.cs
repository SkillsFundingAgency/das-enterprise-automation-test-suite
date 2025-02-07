
using System;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.AODP.UITests.Project.Tests.StepDefinitions.DfeAdmin
{
    

    [Binding]
    public class DfeAdminSteps(ScenarioContext context) 
    {
        [Given(@"Dfe admin user login in to the portal")]
        public void GivenDfeAdminUserLoginInToThePortal() => SubmitValidLoginDetails(context.GetUser<AodpPortalDfeUser1>());
        private void SubmitValidLoginDetails(DfeAdminUser user) => new DfeSignInPage(context).SubmitValidLoginDetails(user);
    }
}
