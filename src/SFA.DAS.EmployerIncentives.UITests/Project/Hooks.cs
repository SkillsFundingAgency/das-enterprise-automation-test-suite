using OpenQA.Selenium;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly EIConfig _eIConfig;
        private readonly TabHelper _tabHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _eIConfig = context.GetEIConfig<EIConfig>();
            _tabHelper = _context.Get<TabHelper>();
        }

        [BeforeScenario(Order = 41)]
        public void Navigate()
        {
            if (_context.ScenarioInfo.Tags.Contains("dfeuatachieveservice"))
            {
                _tabHelper.GoToUrl(UrlConfig.EI_DfeAchieveServiceUrl);

                _tabHelper.OpenInNewTab(UrlConfig.EmployerApprenticeshipService_BaseUrl);
            }
            else
            {
                _tabHelper.GoToUrl(UrlConfig.EmployerApprenticeshipService_BaseUrl);
            }
        }

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers() => _context.Set(new EISqlHelper(_eIConfig));
    }
}
