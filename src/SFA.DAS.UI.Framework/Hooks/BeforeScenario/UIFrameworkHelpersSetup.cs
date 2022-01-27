using NUnit.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.BeforeScenario
{
    [Binding]
    public class UIFrameworkHelpersSetup
    {
        private readonly ScenarioContext _context;
        private readonly TestSupport.UIFrameworkHelpersSetup _helpersSetup;
        private readonly FrameworkConfig _config;

        public UIFrameworkHelpersSetup(ScenarioContext context)
        {
            _context = context;
            _config = context.Get<FrameworkConfig>();
            _helpersSetup = new TestSupport.UIFrameworkHelpersSetup(context);
        }

        [BeforeScenario(Order = 4)]
        public void SetUpUIFrameworkHelpers()
        {
            _helpersSetup.SetupUIFrameworkHelpers();

            _context.Set(new BrowserStackReportingService(_config.BrowserStackSetting));

            TestContext.Progress.WriteLine($"***************'Setting up [BeforeScenario (Order = 4]' DONE***************");
        }
    }
}
