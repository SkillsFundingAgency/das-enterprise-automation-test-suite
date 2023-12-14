namespace SFA.DAS.API.FrameworkHelpers;

public abstract class RequestAndResponseCollectionHelper(RestClient client, RestRequest request, RestResponse response)
{

    protected readonly RestResponse _response = response;
    protected readonly RestRequest _request = request;
    protected readonly RestClient _client = client;

    protected static string HashedValue => "********";

    public string GetRequestData() => $"{Environment.NewLine}REQUEST DETAILS: {GetMethod()}{GetRequestUri()}{GetRequestBody()}";

    public string GetResponseData() => $"RESPONSE DETAILS: {Environment.NewLine}{GetMethod()}{GetResponseUri()}{GetResponseBody()}";

    public string GetErrorResponseData() => $"RESPONSE DETAILS: {Environment.NewLine}{GetMethod()}{GetResponseUri()}{GetResponseContent()}{GetError()}";

    protected abstract string GetRequestBody();

    protected abstract string GetResponseBody();

    private string GetMethod() => $"Method: {_response.Request.Method}{Environment.NewLine}";

    private string GetResponseUri() => $"ResponseUri: {GetAbsoluteUri(_response.ResponseUri?.AbsoluteUri)}{Environment.NewLine}";

    private string GetRequestUri() => $"RequestUri: {GetAbsoluteUri(_client.BuildUri(_request).AbsoluteUri)}{Environment.NewLine}";

    protected string GetResponseContent() => GetBody(_response.Content);

    protected static string GetBody(string content) => $"Body: {content}{Environment.NewLine} ";

    private string GetError() => $"Exception: {_response.ErrorException?.Message}{Environment.NewLine} ";

    private static string GetAbsoluteUri(string absoluteUri)
    {
        if (string.IsNullOrEmpty(absoluteUri)) return "Null";

        if (absoluteUri.ContainsCompareCaseInsensitive("code="))
        {
            var index = absoluteUri.IndexOf("=");
            absoluteUri = absoluteUri[..(index + 5)];
            absoluteUri = $"{absoluteUri}{HashedValue}";
        }

        return absoluteUri;
    }

    protected FrameworkList<object> GetRequestParameters()
    {
        var list = new FrameworkList<object>();

        foreach (var item in _response.Request.Parameters.Where(x => x.Type == ParameterType.RequestBody)) list.Add(item.Value);

        return list;
    }
}
