
using SFA.DAS.API.FrameworkHelpers;

namespace SFA.DAS.API.Framework.RestClients;

public class Outer_HealthApiRestClient(ObjectContext objectContext, string baseurl)
{
    public RestResponse Ping(HttpStatusCode expectedResponse) => Execute($"/ping", expectedResponse);

    public RestResponse CheckHealth(HttpStatusCode expectedResponse) => Execute($"/health", expectedResponse);

    private RestResponse Execute(string resource, HttpStatusCode expectedResponse) => new ApiAssertHelper(objectContext).ExecuteAndAssertResponse(expectedResponse, new RestClient(baseurl), new RestRequest { Method = Method.Get, Resource = resource });
}
