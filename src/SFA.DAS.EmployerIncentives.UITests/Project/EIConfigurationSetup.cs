using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project
{
    [Binding]
    public class EIConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public EIConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpEIConfigConfiguration()
        {
            var config = _configSection.GetConfigSection<EIConfig>();

            _context.SetEIConfig(config);

            _context.SetEasLoginUser(new List<EasAccountUser>()
            {
                _configSection.GetConfigSection<EILevyUser>(),
                _configSection.GetConfigSection<EIWithdrawLevyUser>(),
                _configSection.GetConfigSection<EIMultipleAccountUser>(),
                _configSection.GetConfigSection<Version4AgreementUser>(),
                _configSection.GetConfigSection<Version5AgreementUser>(),
                _configSection.GetConfigSection<Version6AgreementUser>(),
                _configSection.GetConfigSection<Version7AgreementUser>(),
                _configSection.GetConfigSection<EINonLevyUnsignedUser>()
            });
        }
    }
}
