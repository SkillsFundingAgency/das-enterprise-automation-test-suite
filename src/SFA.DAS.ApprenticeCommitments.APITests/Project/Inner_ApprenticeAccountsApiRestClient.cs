using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Inner_ApprenticeAccountsApiRestClient : Inner_BaseApiRestClientUsingMI
    {
        public Inner_ApprenticeAccountsApiRestClient(ObjectContext objectContext, Inner_ApprenticeAccountsApiAuthTokenConfig config) : base(objectContext, new Inner_ApiAuthUsingMI(config)) { }

        protected override string Inner_ApiBaseUrl => UrlConfig.InnerApiUrlConfig.Inner_ApprenticeAccountsApiBaseUrl;

        public IRestResponse CreateApprentice(Apprentice payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.POST, $"/apprentices", payload, expectedResponse);
        }
    }
}
