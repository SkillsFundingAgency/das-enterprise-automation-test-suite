global using OpenQA.Selenium;
global using SFA.DAS.ConfigurationBuilder;
global using SFA.DAS.FrameworkHelpers;
global using SFA.DAS.ManagingStandards.UITests.Project.Helpers;
global using SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;
global using SFA.DAS.UI.Framework.TestSupport;
global using System.Linq;
global using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Project;

namespace SFA.DAS.ManagingStandards.UITests.Project.Hooks
{
    [Binding]
    public class ManagingStandardsHooks(ScenarioContext context)
    {
        private readonly string[] _tags = context.ScenarioInfo.Tags;
        private ManagingStandardsSqlDataHelper _managingStandardsSqlDataHelper;
        protected readonly DbConfig _dbConfig = context.Get<DbConfig>();
        private readonly ProviderConfig _config = context.GetProviderConfig<ProviderConfig>();
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [BeforeScenario(Order = 31)]
        public void SetUpDataHelpers()
        {
            context.Set(_managingStandardsSqlDataHelper = new ManagingStandardsSqlDataHelper(_objectContext, _dbConfig));
            context.Set(new ManagingStandardsDataHelpers());
        }

        [BeforeScenario(Order = 32)]
        public void SetApprovedByRegulatorToNull()
        {
            if (_tags.Any(x => x == "managingstandards02")) _managingStandardsSqlDataHelper.ClearRegulation(_config.Ukprn, ManagingStandardsDataHelpers.StandardsTestData.LarsCode);
        }

        [BeforeScenario(Order = 33)]
        public void ClearDownProviderCourseLocationData()
        {
            if (_tags.Any(x => x == "managingstandards03")) _managingStandardsSqlDataHelper.AddSingleProviderCourseLocation(_config.Ukprn, ManagingStandardsDataHelpers.StandardsTestData.LarsCode);
        }

        [BeforeScenario(Order = 34)]
        public void ClearDownProviderLocationData()
        {
            if (_tags.Any(x => x == "managingstandards04")) _managingStandardsSqlDataHelper.ClearProviderLocation(_config.Ukprn, ManagingStandardsDataHelpers.StandardsTestData.Venue);
        }
    }
}
