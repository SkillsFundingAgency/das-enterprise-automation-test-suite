global using OpenQA.Selenium;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.ManagingStandards.UITests.Project.Helpers;
global using SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;
global using SFA.DAS.ProviderLogin.Service;
global using SFA.DAS.ProviderLogin.Service.Helpers;
global using SFA.DAS.UI.Framework;
global using SFA.DAS.UI.Framework.TestSupport;
global using SFA.DAS.UI.FrameworkHelpers;
global using System.Linq;
global using TechTalk.SpecFlow;

namespace SFA.DAS.ManagingStandards.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "managingstandards")]
    public class ManagingStandardsHooks
    {
        private readonly string[] _tags;
        private ManagingStandardsSqlDataHelper _managingStandardsSqlDataHelper;
        protected readonly DbConfig _dbConfig;
        private readonly ScenarioContext _context;
        private readonly ProviderConfig _config;

        public ManagingStandardsHooks(ScenarioContext context)
        {
            _tags = context.ScenarioInfo.Tags;
            _context = context;
            _dbConfig = context.Get<DbConfig>();
            _config = context.GetProviderConfig<ProviderConfig>();
        }

        [BeforeScenario(Order = 31)]
        public void SetUpDataHelpers()
        {
            _context.Set(_managingStandardsSqlDataHelper = new ManagingStandardsSqlDataHelper(_dbConfig));
        }

        [BeforeScenario(Order = 32)]
        public void SetApprovedByRegulatorToNull()
        {
            if (_tags.Any(x => x == "managingstandards02")) _managingStandardsSqlDataHelper.ClearRegulation(_config.Ukprn);
        }

        [BeforeScenario(Order = 33)]
        public void ClearDownAdminData()
        {
            if (_tags.Any(x => x == "managingstandards03")) _managingStandardsSqlDataHelper.AddSingleProviderLocation(_config.Ukprn);
        }
    }
}
