using SFA.DAS.API.Framework;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ApprenticeCommitmentsAPISteps(ScenarioContext context)
    {
        private readonly ApprenticeCommitmentsApiHelper _apprenticeCommitmentsApiHelper = new(context);
        private readonly Inner_CommitmentsApiRestClient _innerApiRestClient = context.GetRestClient<Inner_CommitmentsApiRestClient>();
        private readonly AccountsAndCommitmentsSqlHelper _apprenticeCommitmentSqlHelper = context.Get<AccountsAndCommitmentsSqlHelper>();

        [Then(@"the apprentice commitments api dependent api's are reachable")]
        public void ThenTheApprenticeCommitmentsApiDependentApisAreReachable() => _apprenticeCommitmentsApiHelper.CheckHealth();

        [Then(@"the apprentice commitments api is reachable")]
        public void ThenTheApprenticeCommitmentsApiIsReachable() => _apprenticeCommitmentsApiHelper.Ping();

        [Then(@"the apprenticeship records can be fetched")]
        public void ThenTheApprenticeshipRecordsCanBeFetched() => _apprenticeCommitmentsApiHelper.GetApprenticeships();

        [Then(@"the apprenticeship record can be fetched")]
        public void ThenTheApprenticeshipRecordCanBeFetched() => _apprenticeCommitmentsApiHelper.GetApprenticeship();

        [Given(@"an apprentice has created an account")]
        public void GivenAnApprenticeHasCreatedAnAccount()
        {
            _apprenticeCommitmentsApiHelper.CreateApprovalsCreatedEvent();
            _apprenticeCommitmentsApiHelper.CreateApprentice();
            _apprenticeCommitmentsApiHelper.CreateApprenticeship();
        }

        [Then(@"das-commitments-api endpoint can be accessed")]
        public void ThenDasCommitmentsApiCanBeAccessed()
        {
            var (_, apprenticeshipid, _, _, _, _, _, _, _, _, _, _) = _apprenticeCommitmentSqlHelper.GetCommitmentData();

            _innerApiRestClient.GetApprenticeship(apprenticeshipid, HttpStatusCode.OK);
        }
    }
}