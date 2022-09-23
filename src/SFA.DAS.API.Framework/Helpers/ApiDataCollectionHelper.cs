namespace SFA.DAS.API.Framework.Helpers;


public class ApiDataCollectionHelper : RequestAndResponseCollectionHelper
{

    public ApiDataCollectionHelper(RestClient client, IRestRequest request, IRestResponse response) : base(client, request, response)
    {
    }

    protected override string GetRequestBody()
    {
        var list = GetRequestParameters();

        return list.Count == 0 ? string.Empty : GetBody(JToken.Parse(list.ToString()).ToString(Formatting.Indented));
    }

    protected override string GetResponseBody() => GetResponseContent();

}
