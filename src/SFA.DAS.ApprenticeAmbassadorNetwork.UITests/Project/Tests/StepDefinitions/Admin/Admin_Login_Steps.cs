using Polly;
using SFA.DAS.EsfaAdmin.Service.Project.Helpers;
using SFA.DAS.IdamsLogin.Service.Project;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin;

[Binding, Scope(Tag = "@aanadmin")]
public class Admin_Login_Steps : Admin_BaseSteps
{
    private readonly EsfaAdminLoginStepsHelper _esfaAdminLoginStepsHelper;

    public Admin_Login_Steps(ScenarioContext context) : base(context)
    {
        _esfaAdminLoginStepsHelper = new EsfaAdminLoginStepsHelper(context);
    }

    [Given(@"an admin logs into the AAN portal")]
    public void AnAdminLogsIntoTheAANPortal() => SubmitValidLoginDetails(context.GetAanEsfaAdminConfig<AanAdminConfig>());

    [Given(@"a super admin logs into the AAN portal")]
    public void ASuperAdminLogsIntoTheAANPortal() => SubmitValidLoginDetails(context.GetAanEsfaSuperAdminConfig<AanEsfaSuperAdminConfig>());

    private void SubmitValidLoginDetails(EsfaAdminConfig config) => _esfaAdminLoginStepsHelper.SubmitValidLoginDetails(config);

    private void SubmitValidLoginDetails(DfeAdminConfig config) => new DfeSignInPage(context).SubmitValidLoginDetails(config);
}
