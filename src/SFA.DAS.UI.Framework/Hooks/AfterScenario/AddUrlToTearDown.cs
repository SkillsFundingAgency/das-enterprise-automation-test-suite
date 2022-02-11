using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class AddUrlToTearDown
    {
        private readonly ScenarioContext _context;
        private readonly TryCatchExceptionHelper _tryCatch;
        private string _url;

        public AddUrlToTearDown(ScenarioContext context)
        {
            _context = context;
            _tryCatch = context.Get<TryCatchExceptionHelper>();
        }

        [AfterScenario(Order = 10)]
        public void AddUrl() => _tryCatch.AfterScenarioException(() => _url = _context.GetWebDriver().Url);

        [AfterScenario(Order = 101)]
        public void ReportErrorUrl() => _tryCatch.AfterScenarioException(() => { if (_context.TestError != null) throw new Exception($"Url : {_url}"); });
    }
}