using SFA.DAS.API.Framework;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.StandardsVersioning.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CoursesApiSteps
    {
        private readonly Inner_CoursesApiRestClient _innerApiRestClient;

        public CoursesApiSteps(ScenarioContext context)
        {
            _innerApiRestClient = context.GetRestClient<Inner_CoursesApiRestClient>();
        }

        [Then(@"das-courses-api (/ping) endpoint can be accessed")]
        public void ThenDasCoursesApiCanBeAccessed(string endpoint)
        {
            _innerApiRestClient.PerformHeathCheck(endpoint);

            var response = _innerApiRestClient.Execute();

            AssertHelper.AssertResponse(HttpStatusCode.OK, response);
        }
    }
}
