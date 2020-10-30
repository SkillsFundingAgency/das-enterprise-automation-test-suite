using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.TestDataExport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class DisposeWebDriverTeardownHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TryCatchException _tryCatch;

        public DisposeWebDriverTeardownHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchException>();
        }

        public void DisposeWebDriver()
        {
            _tryCatch.AfterScenarioException(() => 
            {
                var WebDriver = _context.GetWebDriver();

                if (DoNotDisposeWebDriver() == false)
                {
                    WebDriver?.Quit();
                    WebDriver?.Dispose();
                }
            });
        }

        private bool DoNotDisposeWebDriver()
        {
            //Browserstack will leave the tests as inconclusive if they are timed out 
            //we wanted to leave the tests as inconclusive if for any reason Rest Api failed to update the results)
            return _context.TestError != null && _objectContext.GetBrowser().IsCloudExecution() && _objectContext.FailedtoUpdateTestResultInBrowserStack();
        }
    }
}
