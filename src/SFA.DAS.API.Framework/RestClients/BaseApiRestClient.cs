
namespace SFA.DAS.API.Framework.RestClients;

public abstract class BaseApiRestClient
{
    protected RestClient restClient;

    protected RestRequest restRequest;

    protected abstract void AddResource(string resource);

    protected abstract void AddAuthHeaders();

    protected virtual void AddParameter() { }

    public void CreateRestRequest(Method method, string resource, string payload)
    {
        restRequest.Method = method;

        AddResource(resource);

        restRequest.Parameters.Clear();

        AddParameter();

        AddAuthHeaders();

        AddPayload(payload);
    }

    public IRestResponse Execute(HttpStatusCode expectedResponse)
    {
        var restResponse = restClient.Execute(restRequest);

        AssertHelper.AssertResponse(expectedResponse, restResponse);

        return restResponse;
    }

    protected IRestResponse Execute<T>(Method method, string resource, T payload, HttpStatusCode expectedResponse)
    {
        CreateRestRequest(method, resource, JsonHelper.Serialize(payload));

        return Execute(expectedResponse);
    }

    protected IRestResponse Execute(string resource, HttpStatusCode expectedResponse) => Execute(Method.GET, resource, string.Empty, expectedResponse);

    protected void Addheader(string key, string value) => restRequest.AddHeader(key, value);

    protected void Addheaders(Dictionary<string, string> dictionary)
    {
        foreach (var item in dictionary) Addheader(item.Key, item.Value);
    }

    private void AddPayload(string payload)
    {
        if (string.IsNullOrEmpty(payload)) restRequest.Body = null;
        else
        {
            if (payload.EndsWith(".json")) restRequest.AddJsonBody(JsonHelper.ReadAllText(payload));
            else restRequest.AddJsonBody(payload);
        }
    }
}
