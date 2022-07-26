
namespace SFA.DAS.API.Framework.Helpers;

public class AssertHelper
{
    private readonly ObjectContext _objectContext;

    public AssertHelper(ObjectContext objectContext) => _objectContext = objectContext; 
    
    public IRestResponse ExecuteAndAssertResponse(HttpStatusCode expectedResponse, RestClient client, IRestRequest request)
    => ExecuteAndAssertResponse(expectedResponse, string.Empty, client, request);

    public IRestResponse ExecuteAndAssertResponse(HttpStatusCode expectedResponse, string responseContent, RestClient client, IRestRequest request)
    {
        var response = client.Execute(request);

        var apidataCollector = new ApiDataCollectorHelper(client, request, response);

        _objectContext.SetDebugInformation(apidataCollector.GetRequestData());

        Assert.Multiple(() =>
        {
            if (expectedResponse == HttpStatusCode.OK)
                Assert.IsTrue(response.IsSuccessful, "Expected HttpStatusCode.OK, response status code does not indicate success");

            Assert.AreEqual(expectedResponse, response.StatusCode, apidataCollector.GetResponseData());

            if (!string.IsNullOrEmpty(responseContent)) StringAssert.Contains(responseContent, response.Content);
        });

        return response;
    }
}