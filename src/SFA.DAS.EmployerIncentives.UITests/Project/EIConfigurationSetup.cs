using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
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

            _context.SetEasLoginUser(_configSection.GetConfigSection<EILevyUser>());

            _context.SetEasLoginUser(_configSection.GetConfigSection<EIWithdrawLevyUser>());

            _context.SetEasLoginUser(_configSection.GetConfigSection<EIMultipleAccountUser>());

            _context.SetEasLoginUser(_configSection.GetConfigSection<Version4AgreementUser>());

            _context.SetEasLoginUser(_configSection.GetConfigSection<Version5AgreementUser>());

            _context.SetEasLoginUser(_configSection.GetConfigSection<Version6AgreementUser>());
        }
    }
}
