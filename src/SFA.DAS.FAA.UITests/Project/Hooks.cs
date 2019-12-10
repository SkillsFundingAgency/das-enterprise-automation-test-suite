using SFA.DAS.FAA.UITests.Helpers;
using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        
        public Hooks(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            _context.Set(new VacancyTitleDatahelper(random));

            _context.Set(new FAADataHelper(random));

            var regexHelper = _context.Get<RegexHelper>();
            
            var objectContext = _context.Get<ObjectContext>();

            var pageInteractionHelper = _context.Get<PageInteractionHelper>();

            _context.Set(new VacancyReferenceHelper(pageInteractionHelper, objectContext, regexHelper));
        }
    }
}
