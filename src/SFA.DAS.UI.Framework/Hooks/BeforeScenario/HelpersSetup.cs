using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class HelpersSetup
    {
        private readonly ScenarioContext _context;
        private readonly FrameworkHelpersSetup _helpersSetup;
        private readonly FrameworkConfig _config;

        public HelpersSetup(ScenarioContext context)
        {
            _context = context;
            _config = context.Get<FrameworkConfig>();
            _helpersSetup = new FrameworkHelpersSetup(context);

        }

        [BeforeScenario(Order = 4)]
        public void SetUpHelpers()
        {
            _helpersSetup.SetupFrameworkHelpers();

            _context.Set(new BrowserStackReportingService(_config.BrowserStackSetting));

            _context.Set(new NServiceBusHelper(_config.NServiceBusConfig.ServiceBusConnectionString));
        }
    }
}
