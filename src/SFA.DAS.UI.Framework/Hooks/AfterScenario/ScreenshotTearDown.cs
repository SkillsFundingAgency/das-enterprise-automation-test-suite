using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
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
        private readonly TryCatchExceptionHelper _tryCatch;

        public ScreenshotTeardown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchExceptionHelper>();
        }

        [AfterScenario(Order = 11)]
        public void TakeScreenshotOnTeardown()
        {
            _tryCatch.AfterScenarioException(() =>
            {
                var scenarioTitle = _context.TestError != null ? "TestFailedOnThisPage" : "TestCompletedOnThisPage";
                var webDriver = _context.GetWebDriver();
                var directory = _objectContext.GetDirectory();

                ScreenshotHelper.TakeScreenShot(webDriver, directory, scenarioTitle, true, true);
            });
        }
    }
}

