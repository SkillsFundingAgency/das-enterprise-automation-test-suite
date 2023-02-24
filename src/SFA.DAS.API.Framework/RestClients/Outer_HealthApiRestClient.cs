
using SFA.DAS.API.FrameworkHelpers;

namespace SFA.DAS.API.Framework.RestClients;

public class Outer_HealthApiRestClient
{
    private readonly string _baseUrl;

    private readonly ObjectContext _objectContext;

    public Outer_HealthApiRestClient(ObjectContext objectContext, string baseurl) 
    {
        _objectContext = objectContext;
        _baseUrl = baseurl;
    }

    public RestResponse Ping(HttpStatusCode expectedResponse) => Execute($"/ping", expectedResponse);

    public RestResponse CheckHealth(HttpStatusCode expectedResponse) => Execute($"/health", expectedResponse);

    private RestResponse Execute(string resource, HttpStatusCode expectedResponse) => new ApiAssertHelper(_objectContext).ExecuteAndAssertResponse(expectedResponse, new RestClient(_baseUrl), new RestRequest { Method = Method.Get, Resource = resource });
}
