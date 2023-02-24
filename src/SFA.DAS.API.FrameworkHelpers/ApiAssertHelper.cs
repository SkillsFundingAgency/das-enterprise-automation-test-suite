namespace SFA.DAS.API.FrameworkHelpers;

public class ApiAssertHelper
{
    private readonly ObjectContext _objectContext;

    public ApiAssertHelper(ObjectContext objectContext) => _objectContext = objectContext;

    public RestResponse ExecuteAndAssertResponse(HttpStatusCode expectedResponse, RestClient client, RestRequest request)
    => ExecuteAndAssertResponse(expectedResponse, string.Empty, client, request);

    public RestResponse ExecuteAndAssertResponse(HttpStatusCode expectedResponse, string responseContent, RestClient client, RestRequest request)
    {
        var response = client.Execute(request);

        var apidataCollector = new ApiDataCollectionHelper(client, request, response);

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

    private void SetDebugInformation(RequestAndResponseCollectionHelper apidataCollector)
        => _objectContext.SetDebugInformation($"{apidataCollector.GetRequestData()}{Environment.NewLine}{apidataCollector.GetResponseData()}");

}