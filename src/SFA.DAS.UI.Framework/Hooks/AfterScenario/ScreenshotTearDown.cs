using System;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class ScreenshotTeardown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TryCatchException _tryCatch;

        public ScreenshotTeardown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchException>();
        }

        [AfterScenario(Order = 11)]
        public void TakeScreenshotOnFailure()
        {
            if (_context.TestError != null)
            {
                _tryCatch.AfterScenarioException(() =>
                {
                    var scenarioTitle = _context.ScenarioInfo.Title;
                    var webDriver = _context.GetWebDriver();
                    var directory = _objectContext.GetDirectory();

                    ScreenshotHelper.TakeScreenShot(webDriver, directory, scenarioTitle);
                });
            }
        }
    }
}

