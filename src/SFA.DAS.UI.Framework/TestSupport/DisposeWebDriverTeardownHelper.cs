using SFA.DAS.Configuration;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class DisposeWebDriverTeardownHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public DisposeWebDriverTeardownHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        public void DisposeWebDriver()
        {
            try
            {
                var WebDriver = _context.GetWebDriver();

                if (DoNotDisposeWebDriver() == false)
                {
                    WebDriver?.Quit();
                    WebDriver?.Dispose();
                }
            }
            catch (Exception ex)
            {
                _objectContext.SetAfterScenarioException(ex);
            }
        }

        private bool DoNotDisposeWebDriver()
        {
            //Browserstack will leave the tests as inconclusive if they are timed out 
            //we wanted to leave the tests as inconclusive if for any reason Rest Api failed to update the results)
            return _context.TestError != null && _objectContext.GetBrowser().IsCloudExecution() && _objectContext.FailedtoUpdateTestResultInBrowserStack();
        }
    }
}
