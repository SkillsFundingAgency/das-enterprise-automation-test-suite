using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;

namespace SFA.DAS.IdamsLogin.Service.Project;

[Binding]
public class DfeAdminsConfigurationSetup
{
    private readonly ScenarioContext _context;

    private const string DfeAdminsConfig = "DfeAdminsConfig";

    public DfeAdminsConfigurationSetup(ScenarioContext context) => _context = context;

    [BeforeScenario(Order = 1)]
    public void SetUpDfeAdminsConfiguration() => new DfeSignConfigurationSetupHelper(_context).SetUpDfeSignConfiguration<DfeAdminUsers>(DfeAdminsConfig);
}
