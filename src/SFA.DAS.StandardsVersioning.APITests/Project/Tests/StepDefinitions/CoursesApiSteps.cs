using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.StandardsVersioning.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CoursesApiSteps
    {
        private readonly ManageIdentityApiRestClient _manageIdentityRestClient;

        public CoursesApiSteps(ScenarioContext context)
        {
            _manageIdentityRestClient = context.GetRestClient<ManageIdentityApiRestClient>();
        }

        [Then(@"das-courses-api (/ping) endpoint can be accessed")]
        public void ThenDasCoursesApiCanBeAccessed(string endpoint)
        {
            var restClient = new CoursesInnerApiRestClient(_manageIdentityRestClient);

            restClient.PerformHeathCheck(endpoint);

            var response = restClient.Execute();

            AssertHelper.AssertResponse(HttpStatusCode.OK, response);
        }

    }
}
