using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly DbConfig _dbConfig;
        private readonly TabHelper _tabHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _dbConfig = context.Get<DbConfig>();
            _tabHelper = context.Get<TabHelper>();
        }

        [BeforeScenario(Order = 41)]
        public void LoginToVRFService()
        {
            _context.Set(new EIDataHelper(_context.Get<RandomDataGenerator>()));

            if (_context.ScenarioInfo.Tags.Contains("vrfservice"))
            {
                _tabHelper.GoToUrl(UrlConfig.EI_VRFUrl);
                new VRFLoginPage(_context).SignIntoVRF();
                _tabHelper.OpenInNewTab(UrlConfig.EmployerApprenticeshipService_BaseUrl);
            }
        }

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers() => _context.Set(new EISqlHelper(_dbConfig));

        [BeforeScenario(Order=44)]
        public void ResetPeriodEndInProgress()
        {
            _context.Get<EISqlHelper>().ResetPeriodEndInProgress();
        }
    }
}
