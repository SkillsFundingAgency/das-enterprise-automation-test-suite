using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;
using System.Net;

namespace SFA.DAS.EarlyConnect.APITests.Project
{
    public class Outer_EarlyConnectAPIClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : Outer_BaseApiRestClient(objectContext, config.Apim_SubscriptionKey)
    {
        protected override string ApiName => "/earlyconnect";
        protected override string ApiBaseUrl => UrlConfig.OuterApiUrlConfig.Outer_ApiBaseUrl;

        public void CreateRestRequest(Method method, string resource, string payload, HttpStatusCode expectedResponse)
        {
            CreateRestRequest(method, resource, payload);

            restRequest.RequestFormat = DataFormat.Json;
            Addheader("Content-Type", "application/json");
            Addheader("Accept", "application/json");

            Execute($"/early-connect/student-data/add", expectedResponse);

        }

    }
}
