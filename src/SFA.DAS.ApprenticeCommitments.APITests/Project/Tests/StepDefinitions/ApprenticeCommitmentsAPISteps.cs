using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprenticeCommitmentsAPISteps
    {
        private readonly Outer_ApprenticeCommitmentsApiHelper _appreticeCommitmentsApiHelper;
        private readonly Inner_CommitmentsApiRestClient _innerApiRestClient;

        public ApprenticeCommitmentsAPISteps(ScenarioContext context)
        {
            _appreticeCommitmentsApiHelper = new Outer_ApprenticeCommitmentsApiHelper(context);

            _innerApiRestClient = context.GetRestClient<Inner_CommitmentsApiRestClient>();
        }

        [Then(@"das-commitments-api (/ping) endpoint can be accessed")]
        public void ThenDasCommitmentsApiCanBeAccessed(string endpoint)
        {
            _innerApiRestClient.PerformHeathCheck(endpoint);

            var response = _innerApiRestClient.Execute();

            AssertHelper.AssertResponse(HttpStatusCode.OK, response);
        }

        [When(@"an apprenticeship is posted")]
        public void WhenAnApprenticeshipIsPosted() => _appreticeCommitmentsApiHelper.CreateApprenticeship();

        [Then(@"a (OK|BadRequest|Unauthorized|Forbidden|NotFound|Accepted) response is received")]
        public void AResponseIsReceived(HttpStatusCode responsecode) => _appreticeCommitmentsApiHelper.AssertResponse(responsecode);

        [Then(@"the apprentice details are updated in the login db")]
        public void ThenTheApprenticeDetailsAreUpdatedInTheLoginDb() => _appreticeCommitmentsApiHelper.AssertApprenticeLoginData();
    }
}