
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;

namespace SFA.DAS.CollectingStandards.UITests.Project.Helper
{
    public class CollectingStandardsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public CollectingStandardsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();

        }
    }
}

