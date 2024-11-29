using RestSharp;
using SFA.DAS.API.Framework;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.APITests.Project.Tests.StepDefinitions;

[Binding]
public class ProviderFeedbackApiSteps(ScenarioContext context)
{
    private readonly Outer_ProviderFeedbackApiClient _restClient = context.GetRestClient<Outer_ProviderFeedbackApiClient>();

    private RestResponse _restResponse = null;
}
