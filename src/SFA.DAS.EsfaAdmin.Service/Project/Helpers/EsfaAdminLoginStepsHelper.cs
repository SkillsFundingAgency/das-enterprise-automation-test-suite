using SFA.DAS.EsfaAdmin.Service.Project;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

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
        new ServiceStartPage(_context).StartNow().LoginToAccess1Staff();

        new EsfaSignInPage(_context).SubmitValidLoginDetails(username, password);
    }
}
