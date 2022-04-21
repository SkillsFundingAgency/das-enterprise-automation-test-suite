
//namespace SFA.DAS.CollectingStandards.UITests.Project.Helper
using SFA.DAS.ConfigurationBuilder;
using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.CollectingStandards.UITests.Project.Tests.Pages.Provider;

namespace SFA.DAS.CollectingStandards.UITests.Project.Helper
{
    public class CollectingStandardsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;

        public CollectingStandardsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();

        }
    }
}

