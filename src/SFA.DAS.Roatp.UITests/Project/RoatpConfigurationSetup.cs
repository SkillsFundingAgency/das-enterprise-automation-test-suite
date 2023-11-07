using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.DfeAdmin.Service.Project.Helpers;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project;

[Binding]
public class RoatpConfigurationSetup
{
    private readonly ScenarioContext _context;
    private readonly IConfigSection _configSection;

    public RoatpConfigurationSetup(ScenarioContext context)
    {
        _context = context;
        _configSection = context.Get<IConfigSection>();
    }

    [BeforeScenario(Order = 2)]
    public void SetUpRoatpConfigConfiguration()
    {
        _context.SetRoatpConfig(_configSection.GetConfigSection<RoatpConfig>());

        var dfeAdminUsers = _context.Get<FrameworkList<DfeAdminUsers>>();

        _context.SetNonEasLoginUser(new List<NonEasAccountUser>
        {
            SetDfeAdminCredsHelper.SetDfeAdminCreds(dfeAdminUsers, new AsAdminUser()),
            SetDfeAdminCredsHelper.SetDfeAdminCreds(dfeAdminUsers, new AsAssessor1User()),
            SetDfeAdminCredsHelper.SetDfeAdminCreds(dfeAdminUsers, new AsAssessor2User())
        });
    }
}
