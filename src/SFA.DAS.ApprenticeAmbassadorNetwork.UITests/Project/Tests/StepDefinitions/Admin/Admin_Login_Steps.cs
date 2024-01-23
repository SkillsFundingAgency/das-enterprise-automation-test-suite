using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;
using SFA.DAS.Login.Service;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin;

[Binding, Scope(Tag = "@aanadmin")]
public class Admin_Login_Steps(ScenarioContext context) : Admin_BaseSteps(context)
{
    [Given(@"an admin logs into the AAN portal")]
    public void AnAdminLogsIntoTheAANPortal() => SubmitValidLoginDetails(context.GetUser<AanAdminUser>());

    [Given(@"a super admin logs into the AAN portal")]
    public void ASuperAdminLogsIntoTheAANPortal() => SubmitValidLoginDetails(context.GetUser<AanSuperAdminUser>());

    private void SubmitValidLoginDetails(DfeAdminUser user) => new DfeSignInPage(context).SubmitValidLoginDetails(user);
}
