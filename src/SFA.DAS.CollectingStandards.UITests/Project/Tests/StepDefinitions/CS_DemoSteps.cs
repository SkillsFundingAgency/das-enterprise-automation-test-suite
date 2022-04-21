using SFA.DAS.CollectingStandards.UITests.Project.Helper;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Helpers;

namespace SFA.DAS.CollectingStandards.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CS_DemoSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;
        private readonly CollectingStandardsHelper _collectingStandardsHelper;
        private readonly CollectingStandardsConfig _collectingStandardsConfig;
        private readonly ProviderLoginUser _providerLoginUser;


        public CS_DemoSteps(ScenarioContext context)
        {
            _context = context;
            _collectingStandardsConfig = context.GetCollectingStandardsConfig<CollectingStandardsConfig>();
            _objectContext = context.Get<ObjectContext>();
            _tabHelper = context.Get<TabHelper>();
            _collectingStandardsHelper = new CollectingStandardsHelper(context);
            
        }
    
        [Given(@"the provider land on Provider portal page")]
        public void GivenTheProviderLandOnProviderPortalPage()
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(false);

        }
        private void GoToProviderHomePage() => _tabHelper.GoToUrl(UrlConfig.Provider_BaseUrl);
    }
}
