using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class ScreenshotTeardown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public ScreenshotTeardown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [AfterScenario(Order = 11)]
        public void TakeScreenshotOnFailure()
        {
            if (_context.TestError != null)
            {
                _context.Get<TryCatchExceptionHelper>().AfterScenarioException(() =>
                {
                    var scenarioTitle = _context.ScenarioInfo.Title;
                    var webDriver = _context.GetWebDriver();
                    var directory = _objectContext.GetDirectory();

                    ScreenshotHelper.TakeScreenShot(webDriver, directory, scenarioTitle, true);
                });
            }
        }
    }
}

