using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using TechTalk.SpecFlow;

namespace SFA.DAS.AssessorCertification.APITests.Project
{
    [Binding]
    public class BeforeScenarioHooks
    {
        private readonly ScenarioContext _context;

        public BeforeScenarioHooks(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => _context.SetRestClient(new Outer_AssessorCertificationApiRestClient(_context.GetOuter_ApiAuthTokenConfig()));
    }
}
