using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario;

[Binding]
public class AddUrlToTearDown(ScenarioContext context)
{
    private readonly TryCatchExceptionHelper _tryCatch = context.Get<TryCatchExceptionHelper>();
    private string _url;

    [AfterScenario(Order = 10)]
    public void AddUrl() => _tryCatch.AfterScenarioException(() => _url = context.GetWebDriver().Url);

    [AfterScenario(Order = 101)]
    public void ReportErrorUrl() => _tryCatch.AfterScenarioException(() => { if (context.TestError != null) throw new Exception($"Url : {_url}"); });
}