using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.CollectingStandards.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CS_DemoSteps
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TabHelper _tabHelper;


        public CS_DemoSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tabHelper = context.Get<TabHelper>();
        }
    
        [Given(@"the provider land on Provider portal page")]
        public void GivenTheProviderLandOnProviderPortalPage()
        {
            GoToProviderHomePage();
        }
        private void GoToProviderHomePage() => _tabHelper.GoToUrl(UrlConfig.Provider_BaseUrl);
    }
}
