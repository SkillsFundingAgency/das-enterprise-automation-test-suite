using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
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
        private readonly EILevyUser _eILevyUser;
        private readonly RegistrationSqlDataHelper _registrationSqlDataHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _eIConfig = context.GetEIConfig<EIConfig>();
            _tabHelper = context.Get<TabHelper>();
            _eILevyUser = context.GetUser<EILevyUser>();
            _registrationSqlDataHelper = context.Get<RegistrationSqlDataHelper>();
        }

        [BeforeScenario(Order = 41)]
        public void LoginToDfeUatService()
        {
            _context.Set(new EIDataHelper(_context.Get<RandomDataGenerator>()));

            if (_context.ScenarioInfo.Tags.Contains("dfeuatachieveservice"))
            {
                _tabHelper.GoToUrl(UrlConfig.EI_DfeAchieveServiceUrl);

                new VRFLoginPage(_context).SignIntoDfeUat();

                _tabHelper.OpenInNewTab(UrlConfig.EmployerApprenticeshipService_BaseUrl);
            }
        }

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers() => _context.Set(new EISqlHelper(_eIConfig));

        [BeforeScenario(Order = 43)]
        public void RemoveExistingApplications()
        {
            if (_context.ScenarioInfo.Tags.Contains("eie2ejourney"))
                _context.Get<EISqlHelper>().DeleteIncentiveApplication(_registrationSqlDataHelper.GetAccountId(_eILevyUser.Username));
        }
    }
}
