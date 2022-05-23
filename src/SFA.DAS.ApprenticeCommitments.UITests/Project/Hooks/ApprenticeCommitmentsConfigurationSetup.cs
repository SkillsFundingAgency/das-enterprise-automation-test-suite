using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Hooks
{
    [Binding]
    public class ApprenticeCommitmentsConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public ApprenticeCommitmentsConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpRegistrationConfigConfiguration()
        {
            _context.SetApprenticeCommitmentsConfig(_configSection.GetConfigSection<ApprenticeCommitmentsConfig>());

            var cocEmpUser = _configSection.GetConfigSection<ASCoCEmployerUser>();
            
            cocEmpUser.CocApprenticeUser = _configSection.GetConfigSection<CocApprenticeUser>();

            _context.SetEasLoginUser(new List<EasAccountUser>() { cocEmpUser, _configSection.GetConfigSection<ASListedLevyUser>() });
        }
    }
}
