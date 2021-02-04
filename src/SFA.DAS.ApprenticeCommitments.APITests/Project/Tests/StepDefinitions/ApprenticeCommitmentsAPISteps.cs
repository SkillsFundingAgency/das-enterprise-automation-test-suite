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

            JsonSerializerOptions jso = new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            var payload = JsonSerializer.Serialize(new CreateApprenticeship { EmployerAccountId = long.Parse(accountid), ApprenticeshipId = long.Parse(apprenticeshipid), Organisation = orgname }, jso);

            _restClient.CreateRestRequest(Method.POST, "/apprenticeships", payload);
        }
    }
}