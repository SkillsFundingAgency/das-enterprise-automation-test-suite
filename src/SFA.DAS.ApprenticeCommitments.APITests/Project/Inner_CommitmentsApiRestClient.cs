using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Inner_CommitmentsApiRestClient : Inner_BaseApiRestClient
    {
        public Inner_CommitmentsApiRestClient(Inner_ApiAuthTokenConfig config) : base(config) { }

        protected override string Inner_ApiBaseUrl => UrlConfig.Inner_CommitmentsApiBaseUrl;

        public void GetApprenticeship(long app)
        {
            CreateRestRequest(RestSharp.Method.GET, $"/api/apprenticeships/{app}", string.Empty);
        }
    }
}
