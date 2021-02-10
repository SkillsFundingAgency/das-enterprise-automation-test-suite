using SFA.DAS.API.Framework;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class ApprenticeCommitmentsRestClient : OuterApiRestClient
    {
        public ApprenticeCommitmentsRestClient(string subscriptionkey) : base(subscriptionkey) { }

        protected override string ApiName => "/apprenticecommitments";
    }
}
