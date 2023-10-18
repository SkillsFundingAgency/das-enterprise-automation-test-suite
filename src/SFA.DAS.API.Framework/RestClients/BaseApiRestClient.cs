using RestSharp.Authenticators;
using SFA.DAS.API.FrameworkHelpers;

namespace SFA.DAS.API.Framework.RestClients;

public abstract class BaseApiRestClient
{
    protected RestClient restClient;

    protected RestRequest restRequest;

    protected readonly ObjectContext objectContext;

    public BaseApiRestClient(ObjectContext objectContext)
    {
        this.objectContext = objectContext;

        var restOptions = new RestClientOptions(ApiBaseUrl);

        if (HasAuthenticator) restOptions.Authenticator = GetAuthenticator();

        restClient = new(restOptions);

        restRequest = new RestRequest();
    }

    protected virtual bool HasAuthenticator => false;

    protected virtual IAuthenticator GetAuthenticator() => default;

    protected abstract string ApiBaseUrl { get; }

    protected abstract void AddResource(string resource);

    protected abstract void AddAuthHeaders();

    protected virtual void AddParameter() { }

    public void CreateRestRequest(Method method, string resource, string payload)
    {
        restRequest.Method = method;

        AddResource(resource);

        foreach (var item in restRequest.Parameters.GetParameters(ParameterType.RequestBody)) restRequest.Parameters.RemoveParameter(item);

        AddParameter();

        AddAuthHeaders();

        AddPayload(payload);
    }

    public RestResponse Execute(HttpStatusCode expectedResponse) => Execute(expectedResponse, string.Empty);

    public RestResponse Execute(HttpStatusCode expectedResponse, string resourceContent) => new ApiAssertHelper(objectContext).ExecuteAndAssertResponse(expectedResponse, resourceContent, restClient, restRequest);

    protected RestResponse Execute<T>(Method method, string resource, T payload, HttpStatusCode expectedResponse)
    {
        CreateRestRequest(method, resource, JsonHelper.Serialize(payload));

        return Execute(expectedResponse);
    }

    protected RestResponse Execute(string resource, HttpStatusCode expectedResponse) => Execute(Method.Get, resource, string.Empty, expectedResponse);

    protected void Addheader(string key, string value) => restRequest.AddHeader(key, value);

    protected void Addheaders(Dictionary<string, string> dictionary)
    {
        foreach (var item in dictionary) Addheader(item.Key, item.Value);
    }

    private void AddPayload(string payload)
    {
        if (restRequest.Method == Method.Get || string.IsNullOrEmpty(payload)) return;
        else
        {
            if (payload.EndsWith(".json")) restRequest.AddJsonBody(JsonHelper.ReadAllText(payload));
            else restRequest.AddJsonBody(payload);
        }
    }
}
