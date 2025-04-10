namespace SFA.DAS.ProvideFeedback.APITests.Project;

public class Outer_ProviderFeedbackApiClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : Outer_BaseApiRestClient(objectContext, config.Apim_SubscriptionKey)
{
    protected override string ApiName => "/providerfeedback";

    public void GetProviderFeedback(long ukprn, HttpStatusCode expectedResponse) => Execute(Method.Get, $"/providerFeedback/{ukprn}", string.Empty, expectedResponse);
}
