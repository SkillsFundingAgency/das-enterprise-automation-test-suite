using SFA.DAS.API.Framework;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.APITests.Project
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => context.SetRestClient(new FatV2RestClient(context.Get<ObjectContext>(), context.GetOuter_ApiAuthTokenConfig()));
    }
}