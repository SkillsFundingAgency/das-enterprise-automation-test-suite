
namespace SFA.DAS.API.Framework.Helpers;

public class ApiAssertHelper
{
    private readonly ObjectContext _objectContext;

    public ApiAssertHelper(ObjectContext objectContext) => _objectContext = objectContext; 

    public IRestResponse ExecuteAuthTokenAndAssertResponse(RestClient client, IRestRequest request)
    {
        var response = client.Execute(request);

        var apidataCollector = new AuthApiDataCollectorHelper(client, request, response);

        SetDebugInformation(apidataCollector);

        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode, $"Failed to get auth token.{Environment.NewLine} {apidataCollector.GetErrorResponseData()}");

        return response;
    }

    public IRestResponse ExecuteAndAssertResponse(HttpStatusCode expectedResponse, RestClient client, IRestRequest request)
    => ExecuteAndAssertResponse(expectedResponse, string.Empty, client, request);

    public IRestResponse ExecuteAndAssertResponse(HttpStatusCode expectedResponse, string responseContent, RestClient client, IRestRequest request)
    {
        var response = client.Execute(request);

        var apidataCollector = new ApiDataCollectorHelper(client, request, response);

        SetDebugInformation(apidataCollector);

        Assert.Multiple(() =>
        {
            if (expectedResponse == HttpStatusCode.OK)
                Assert.IsTrue(response.IsSuccessful, "Expected HttpStatusCode.OK, response status code does not indicate success");

            Assert.AreEqual(expectedResponse, response.StatusCode, apidataCollector.GetErrorResponseData());

            if (!string.IsNullOrEmpty(responseContent)) StringAssert.Contains(responseContent, response.Content);
        });

        return response;
    }

    private void SetDebugInformation(ApiBaseDataCollectorHelper apidataCollector)
        => _objectContext.SetDebugInformation($"{apidataCollector.GetRequestData()}{Environment.NewLine}{apidataCollector.GetResponseData()}");

}