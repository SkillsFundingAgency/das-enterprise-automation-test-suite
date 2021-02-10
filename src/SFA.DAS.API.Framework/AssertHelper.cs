using NUnit.Framework;
using RestSharp;
using System.Net;

namespace SFA.DAS.API.Framework
{
    public static class AssertHelper
    {
        public static void AssertResponse(HttpStatusCode expectedResponse, IRestResponse actualResponse)
        {
            Assert.Multiple(() =>
            {
                if (expectedResponse == HttpStatusCode.OK) Assert.IsTrue(actualResponse.IsSuccessful, "Expected HttpStatusCode.OK, response status code does not indicate success");

                Assert.AreEqual(expectedResponse, actualResponse.StatusCode, $"{actualResponse.StatusCode} - {actualResponse.Content}");
            });
        }
    }
}