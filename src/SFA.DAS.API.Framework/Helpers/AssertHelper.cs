using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Linq;
using System.Net;

namespace SFA.DAS.API.Framework.Helpers
{
    public static class AssertHelper
    {
        public static void AssertResponse(HttpStatusCode expectedResponse, IRestResponse response)
        {
            Assert.Multiple(() =>
            {
                if (expectedResponse == HttpStatusCode.OK) 
                    Assert.IsTrue(response.IsSuccessful, "Expected HttpStatusCode.OK, response status code does not indicate success");

                Assert.AreEqual(expectedResponse, response.StatusCode, GetResponseData(response));

                TestContext.Progress.WriteLine(GetResponseData(response));
            });
        }

        private static string GetRequestBody(IRestResponse response)
        {
            var list = new FrameworkList<object>();

            foreach (var item in response.Request.Parameters.Where(x => x.Type == ParameterType.RequestBody))
            {
                list.Add(item.Value);
            }

            return list.Count == 0 ? string.Empty : JToken.Parse(list.ToString()).ToString(Formatting.Indented);
        }

        private static string GetResponseData(IRestResponse response)
        {
            return $"REQUEST DETAILS: {Environment.NewLine}" +
                   $"Method: {response.Request.Method}{Environment.NewLine}" +
                   $"URI: {response.ResponseUri.AbsoluteUri}{Environment.NewLine}" +
                   $"Body: {Environment.NewLine} {GetRequestBody(response)}";
        }
    }
}