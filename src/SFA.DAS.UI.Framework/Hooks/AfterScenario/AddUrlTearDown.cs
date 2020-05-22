using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class AddUrlTearDown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public AddUrlTearDown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [AfterScenario(Order = 9)]
        public void AddUrl()
        {
            var webDriver = _context.GetWebDriver();

            _objectContext.SetUrl(webDriver.Url);
        }

    }
}

