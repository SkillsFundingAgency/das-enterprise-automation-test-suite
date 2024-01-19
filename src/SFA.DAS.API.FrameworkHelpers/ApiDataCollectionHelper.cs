namespace SFA.DAS.API.FrameworkHelpers;

public class ApiDataCollectionHelper(RestClient client, RestRequest request, RestResponse response) : RequestAndResponseCollectionHelper(client, request, response)
{
    protected override string GetRequestBody()
    {
        var list = GetRequestParameters();

        return list.Count == 0 ? string.Empty : GetBody(ParseJson(list.ToString()));
    }

    protected override string GetResponseBody() => GetResponseContent();

    private static string ParseJson(string json)
    {
        try
        {
            return JToken.Parse(json).ToString(Formatting.Indented);
        }
        catch (Exception)
        {
            return json;
        }
    }
}
