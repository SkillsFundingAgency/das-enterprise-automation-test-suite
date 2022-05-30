using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;

        public BeforeScenarioHooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 41)]
        public void LoginToVRFService()
        {
            var tabHelper = _context.Get<TabHelper>();

            _context.Set(new EIDataHelper());

            if (_context.ScenarioInfo.Tags.Contains("vrfservice"))
            {
                tabHelper.GoToUrl(UrlConfig.EI_VRFUrl);
                new VRFLoginPage(_context).SignIntoVRF();
                tabHelper.OpenInNewTab(UrlConfig.EmployerApprenticeshipService_BaseUrl);
            }
        }

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers() => _context.Set(new EISqlHelper(_context.Get<DbConfig>()));

        [BeforeScenario(Order = 44)]
        public void ResetPeriodEndInProgress() => _context.Get<EISqlHelper>().ResetPeriodEndInProgress();
    }
}
