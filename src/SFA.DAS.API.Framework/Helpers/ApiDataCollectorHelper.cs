
namespace SFA.DAS.API.Framework.Helpers;

public class ApiDataCollectorHelper
{
    private readonly IRestResponse _response;
    private readonly IRestRequest _request;
    private readonly RestClient _client;

    public ApiDataCollectorHelper(RestClient client, IRestRequest request, IRestResponse response)
    {
        _client = client;       
        _request = request;
        _response = response;
    } 

    internal string GetRequestData() => $"{Environment.NewLine}REQUEST DETAILS: {GetMethod()}{GetRequestUri()}{GetBody()}";

    internal string GetResponseData() => $"RESPONSE: {Environment.NewLine}{GetMethod()}{GetResponseUri()}{GetBody()}{GetError()}";

    private string GetMethod() => $"Method: {_response.Request.Method}{Environment.NewLine}";

    private string GetResponseUri() => $"ResponseUri: {GetAbsoluteUri(_response.ResponseUri?.AbsoluteUri)}{Environment.NewLine}";

    private string GetRequestUri() => $"RequestUri: {_client.BuildUri(_request).AbsoluteUri}{Environment.NewLine}";

    private string GetBody() => $"Body: {GetRequestBody()}{Environment.NewLine} ";

    private string GetError() => $"Exception: {_response.ErrorException?.Message}";

    private static string GetAbsoluteUri(string absoluteUri)
    {
        if (string.IsNullOrEmpty(absoluteUri)) return "Null";

        if (absoluteUri.ContainsCompareCaseInsensitive("code="))
        {
            var index = absoluteUri.IndexOf("=");
            absoluteUri = absoluteUri[..(index + 1)];
        }

        return absoluteUri;
    }

    private string GetRequestBody()
    {
        var list = new FrameworkList<object>();

        foreach (var item in _response.Request.Parameters.Where(x => x.Type == ParameterType.RequestBody)) list.Add(item.Value);

        return list.Count == 0 ? string.Empty : JToken.Parse(list.ToString()).ToString(Formatting.Indented);
    }
}
