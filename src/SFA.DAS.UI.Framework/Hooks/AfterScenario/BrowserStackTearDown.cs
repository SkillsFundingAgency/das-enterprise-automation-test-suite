using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class BrowserStackTearDown
    {
        private readonly BrowserStackTearDownHelper _helper;

        public BrowserStackTearDown(ScenarioContext context)
        {
            _helper = new BrowserStackTearDownHelper(context);
        }

        [AfterScenario(Order = 12)]
        public void InformBrowserStackOnFailure()
        {
            _helper.InformBrowserStackOnFailure();
        }
    }
}

