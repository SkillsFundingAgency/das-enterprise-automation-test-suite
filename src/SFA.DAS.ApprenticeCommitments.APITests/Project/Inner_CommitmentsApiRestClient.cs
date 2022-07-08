using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Inner_CommitmentsApiRestClient : Inner_BaseApiRestClient
    {
        public Inner_CommitmentsApiRestClient(ObjectContext objectContext, Inner_ApiAuthTokenConfig config) : base(objectContext, config) { }

        protected override string Inner_ApiBaseUrl => UrlConfig.Inner_CommitmentsApiBaseUrl;

        public void GetApprenticeship(long app, HttpStatusCode expectedResponse) => Execute(RestSharp.Method.GET, $"/api/apprenticeships/{app}", string.Empty, expectedResponse);
    }
}
