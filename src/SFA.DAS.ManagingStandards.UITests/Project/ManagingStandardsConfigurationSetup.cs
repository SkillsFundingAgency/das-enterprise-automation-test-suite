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
    public void SetUpManagingStandardsProjectConfiguration() => _context.SetNonEasLoginUser(SetDfeAdminCredsHelper.SetDfeAdminCreds(_context.Get<FrameworkList<DfeAdminUsers>>(), new AsAdminUser()));
}