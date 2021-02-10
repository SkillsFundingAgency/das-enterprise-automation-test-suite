using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.APITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;

        public BeforeScenarioHooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var restClient = new FatV2RestClient(_context.Get<ApiFrameworkConfig>().Fatv2ApiKey);

            _context.SetRestClient<OuterApiRestClient>(restClient);
        }
    }
}