using SFA.DAS.IdamsLogin.Service.Project;

namespace SFA.DAS.EsfaAdmin.Service.Project.Helpers;

public class EsfaAdminLoginStepsHelper
{
    private readonly ScenarioContext _context;
    private readonly EsfaAdminConfig _config;

    public EsfaAdminLoginStepsHelper(ScenarioContext context)
    {
        _context = context;
        _config = context.GetEsfaAdminConfig<EsfaAdminConfig>();
    }

    public void SubmitValidLoginDetails() => SubmitValidLoginDetails(_config.AdminUserName, _config.AdminPassword);

    public void SubmitValidLoginDetails(string username, string password)
    {
        new EsfaAdminServiceStartPage(_context).StartNow().LoginToAccess1Staff();

        new EsfaSignInPage(_context).SubmitValidLoginDetails(username, password);

        _context.Get<ObjectContext>().SetEsfaAdminLoginCreds((username, password));
    }
}
