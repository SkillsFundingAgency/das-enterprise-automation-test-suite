using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using System.Text.Json;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprenticeCommitmentsAPISteps
    {

        private readonly FrameworkRestClient _restClient;
        private readonly ApprenticeCommitmentSqlHelper _apprenticeCommitmentSqlHelper;

        public ApprenticeCommitmentsAPISteps(ScenarioContext context)
        {
            _restClient = context.GetRestClient<FrameworkRestClient>();

            _apprenticeCommitmentSqlHelper = context.Get<ApprenticeCommitmentSqlHelper>();
        }

        [When(@"an apprenticeship is posted")]
        public void WhenAnApprenticeshipIsPosted()
        {
            var (accountid, apprenticeshipid, orgname) = _apprenticeCommitmentSqlHelper.GetEmployerData();

            var payload = JsonSerializer.Serialize(new CreateApprenticeship { EmployerAccountId = accountid, ApprenticeshipId = apprenticeshipid, Organisation = orgname });

            _restClient.CreateRestRequest(Method.POST, "/apprenticeships", payload);
        }
    }
}