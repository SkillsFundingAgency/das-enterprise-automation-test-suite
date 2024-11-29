using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;
using System.Net;

namespace SFA.DAS.ProviderFeedback.APITests.Project
{
    public class Outer_ProviderFeedbackApiClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : Outer_BaseApiRestClient(objectContext, config.ProviderFeedback_Apim_SubscriptionKey)
    {
        protected override string ApiName => "/provider-feedback"; // todo: move to config
        protected override string ApiBaseUrl => UrlConfig.OuterApiUrlConfig.Outer_ApiBaseUrl;
        public void GetProviderFeedback(long ukprn, HttpStatusCode expectedResponse) => Execute(Method.Get, $"/api/apprenticeships/{ukprn}", string.Empty, expectedResponse);
    }
}
