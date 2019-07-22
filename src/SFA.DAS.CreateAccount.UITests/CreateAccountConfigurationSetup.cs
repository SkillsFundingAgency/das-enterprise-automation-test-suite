using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.CreateAccount.UITests
{
    [Binding]
    public class CreateAccountConfigurationSetup
    {
        private readonly ScenarioContext _context;
        
        public CreateAccountConfigurationSetup(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 20)]
        public void SetupCreateAccountConfiguration()
        {
            var config = _context.GetConfigSection<CreateAccountConfig>();
            _context.Set(new CreateAccountConfig { MACurrentUserName = config.MACurrentUserName, MACurrentUserPassword = config.MACurrentUserPassword });
        }
    }

    public class CreateAccountConfig
    {
        public string MACurrentUserName { get; set; }

        public string MACurrentUserPassword { get; set; }
    }
}
