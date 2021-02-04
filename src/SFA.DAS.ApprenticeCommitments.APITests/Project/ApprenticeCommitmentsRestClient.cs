using SFA.DAS.API.Framework;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class ApprenticeCommitmentsRestClient : FrameworkRestClient
    {
        public ApprenticeCommitmentsRestClient(string subscriptionkey) : base(subscriptionkey) { }

        protected override string ApiEndpoint => "/apprenticecommitments";
    }
}
