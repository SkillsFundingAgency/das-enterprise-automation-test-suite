using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.Hooks.AfterScenario
{
    [Binding]
    public class AddUrlTearDown
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TryCatchException _tryCatch;

        public AddUrlTearDown(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchException>();
        }

        [AfterScenario(Order = 10)]
        public void AddUrl() => _tryCatch.AfterScenarioException(() => _objectContext.SetUrl(_context.GetWebDriver().Url));
    }
}
