using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Inner_CommitmentsApiRestClient : Inner_BaseApiRestClient
    {
        public Inner_CommitmentsApiRestClient(ObjectContext objectContext, API.Framework.Configs.Inner_ApiAuthConfigUsingOAuth config) : base(objectContext, new API.Framework.RestClients.Inner_ApiAuthUsingOAuth(config)) { }

        protected override string Inner_ApiBaseUrl => UrlConfig.InnerApiUrlConfig.Inner_CommitmentsApiBaseUrl;

        public void GetApprenticeship(long app, HttpStatusCode expectedResponse) => Execute(Method.GET, $"/api/apprenticeships/{app}", string.Empty, expectedResponse);
    }
}
