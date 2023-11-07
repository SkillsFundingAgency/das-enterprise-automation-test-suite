using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin;

[Binding, Scope(Tag = "@aanadmin")]
public class Admin_Login_Steps : Admin_BaseSteps
{
    public Admin_Login_Steps(ScenarioContext context) : base(context) { }

    [Given(@"an admin logs into the AAN portal")]
    public void AnAdminLogsIntoTheAANPortal() => SubmitValidLoginDetails(context.GetUser<AanAdminUser>());

    [Given(@"a super admin logs into the AAN portal")]
    public void ASuperAdminLogsIntoTheAANPortal() => SubmitValidLoginDetails(context.GetUser<AanSuperAdminUser>());

    private void SubmitValidLoginDetails(DfeAdminUser user) => new DfeSignInPage(context).SubmitValidLoginDetails(user);
}
