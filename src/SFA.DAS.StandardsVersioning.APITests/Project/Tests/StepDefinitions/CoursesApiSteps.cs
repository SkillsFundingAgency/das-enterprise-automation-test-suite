using SFA.DAS.API.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.StandardsVersioning.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CoursesApiSteps
    {
        private readonly ManageIdentityRestClient _manageIdentityRestClient;

        public CoursesApiSteps(ScenarioContext context)
        {
            _manageIdentityRestClient = context.GetRestClient<ManageIdentityRestClient>();
        }

        [Then(@"I can access dataload endpoint")]
        public void ThenICanAccessDataloadEndpoint()
        {
            _manageIdentityRestClient.GetAuthToken();
        }

    }
}
