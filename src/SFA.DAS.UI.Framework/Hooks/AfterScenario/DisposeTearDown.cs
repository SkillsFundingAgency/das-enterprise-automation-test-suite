using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class DisposeTeardown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private string url;

        public DisposeTeardown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [AfterScenario(Order = 12)]
        public void DisposeOnTestRun()
        {
            try
            {
                var WebDriver = _context.GetWebDriver();

                url = WebDriver?.Url;

                if (_objectContext.GetBrowser().IsCloudExecution() && _objectContext.FailedtoUpdateTestResultInBrowserStack())
                {
                    // Browserstack will leave the tests as inconclusive if they are timeout 
                    WebDriver?.Quit();
                    WebDriver?.Dispose();
                }
            }
            catch (Exception ex)
            {
                _objectContext.SetAfterScenarioException(ex);
            }
            
        }

        [AfterScenario(Order = 13)]
        public void ErrorMessage()
        {
            var exception = _context.TestError;

            if (exception != null)
            {
                var messages = new List<string>();

                messages.AddRange(_objectContext.GetAfterScenarioExceptions().Select(x => x.Message));
                
                if (url != string.Empty)
                {
                    messages.Add($"Url : {url}");
                }
                
                throw new Exception(string.Join(Environment.NewLine, messages));
            }
        }
    }
}
