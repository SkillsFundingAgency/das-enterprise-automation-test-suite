using SFA.DAS.API.Framework;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;



namespace SFA.DAS.EarlyConnect.APITests.Project
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            var objectContext = context.Get<ObjectContext>();

            context.SetRestClient(new Outer_EarlyConnectAPIClient(objectContext, context.GetOuter_ApiAuthTokenConfig()));

        }
    }
}
