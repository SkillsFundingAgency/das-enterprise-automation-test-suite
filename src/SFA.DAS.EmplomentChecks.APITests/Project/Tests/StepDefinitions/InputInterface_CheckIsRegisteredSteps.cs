using NUnit.Framework;
using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.EmploymentChecks.APITests.Project.Helpers.SqlDbHelpers;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmploymentChecks.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    internal class InputInterface_CheckIsRegisteredSteps
    {
        private ScenarioContext _context;
        private readonly Outer_EmploymentCheckApiClient _restClient;
        private readonly EmploymentChecksSqlDbHelper _employmentChecksSqlDbHelper;
        private IRestResponse apiResponse;

        public InputInterface_CheckIsRegisteredSteps(ScenarioContext context)
        {
            _context = context;
            _restClient = context.GetRestClient<Outer_EmploymentCheckApiClient>();
            _employmentChecksSqlDbHelper = context.Get<EmploymentChecksSqlDbHelper>();
        }

        [Given(@"Employer Incentives service are validing employment status of apprentice")]
        public void GivenEmployerIncentivesServiceAreValidingEmploymentStatusOfApprentice()
        {
        }

        [When(@"an employment check '([^']*)' request is successfully made to '([^']*)' with payload '([^']*)'")]
        public void WhenAnEmploymentCheckRequestIsSuccessfullyMadeToWithPayload(Method method, string endpoint, string payload)
        {
            _restClient.CreateRestRequest(method, endpoint, payload);
        }


        [Then(@"a OK response is received")]
        public void ThenAOKResponseIsReceived()
        {
            apiResponse = _restClient.Execute(HttpStatusCode.OK);
        }

        [Then(@"the check is registered in Employment Check business table")]
        public void ThenTheCheckIsRegisteredInEmploymentCheckBusinessTable()
        {
            string checkType = _context.ScenarioInfo.Title.Substring(0, 10);
            int count = _employmentChecksSqlDbHelper.GetCheckFromEmploymentCheckTable(checkType);

            Assert.AreEqual(1, count, $"Unexpected number of records for test {checkType} in [Business].[EmploymentCheck] table");
        }



    }
}
