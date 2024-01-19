using NUnit.Framework;
using SFA.DAS.API.FrameworkHelpers;

namespace SFA.DAS.API.Framework.Helpers;

public class InnerApiAuthTokenAssertHelper(ObjectContext objectContext)
{
    public RestResponse ExecuteInnerApiAuthTokenAndAssertResponse(RestClient client, RestRequest request)
    {
        var response = client.Execute(request);

        var apidataCollector = new InnerApiAuthDataCollectionHelper(client, request, response);

        SetDebugInformation(apidataCollector);

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, $"Failed to get auth token.{Environment.NewLine} {apidataCollector.GetErrorResponseData()}");

        return response;
    }

    private void SetDebugInformation(RequestAndResponseCollectionHelper apidataCollector)
       => objectContext.SetDebugInformation($"{apidataCollector.GetRequestData()}{Environment.NewLine}{apidataCollector.GetResponseData()}");
}
