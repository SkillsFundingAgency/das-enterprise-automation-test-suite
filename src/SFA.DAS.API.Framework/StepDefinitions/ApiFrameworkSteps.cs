using NUnit.Framework;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.API.Framework.StepDefinitions
{
    [Binding]
    public class ApiFrameworkSteps
    {
        private readonly ScenarioContext _context;

        public ApiFrameworkSteps(ScenarioContext context) => _context = context;

        [Then(@"a (OK|BadRequest|Unauthorized|Forbidden|NotFound|Accepted) response is received")]
        public void AResponseIsReceived(HttpStatusCode responsecode)
        {
            var _restClient = _context.GetRestClient<FrameworkRestClient>();

            var response = _restClient.Execute();

            Assert.Multiple(() =>
            {
                if (responsecode == HttpStatusCode.OK) Assert.IsTrue(response.IsSuccessful, "Expected HttpStatusCode.OK, response status code does not indicate success");

                Assert.AreEqual(responsecode, response.StatusCode, $"{response.StatusCode} - {response.Content}");
            });
        }
    }
}
