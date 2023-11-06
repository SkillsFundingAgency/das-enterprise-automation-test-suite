using SFA.DAS.IdamsLogin.Service.Project.Helpers;
using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using System.Collections.Generic;

namespace SFA.DAS.ManagingStandards.UITests.Project;

[Binding]
public class ManagingStandardsConfigurationSetup
{
    private readonly ScenarioContext _context;

    public ManagingStandardsConfigurationSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 2)]
    public void SetUpManagingStandardsProjectConfiguration()
    {
        var dfeAdminUsers = _context.Get<FrameworkList<DfeAdminUsers>>();

        _context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            SetDfeAdminCredsHelper.SetDfeAdminCreds(dfeAdminUsers, new EsfaAdminUser()),
        });
    }
}