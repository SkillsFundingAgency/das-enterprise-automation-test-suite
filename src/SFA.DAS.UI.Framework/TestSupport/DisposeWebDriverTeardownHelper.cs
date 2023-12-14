using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport;

public class DisposeWebDriverTeardownHelper(ScenarioContext context)
{
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
    private readonly TryCatchExceptionHelper _tryCatch = context.Get<TryCatchExceptionHelper>();

    public void DisposeWebDriver()
    {
        _tryCatch.AfterScenarioException(() =>
        {
            var WebDriver = context.GetWebDriver();

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
        return context.TestError != null && _objectContext.GetBrowser().IsCloudExecution() && _objectContext.FailedtoUpdateTestResultInBrowserStack();
    }
}
