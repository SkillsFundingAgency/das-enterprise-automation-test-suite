using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Inner_ApprenticeAccountsApiRestClient : Inner_BaseApiRestClient
    {
        private readonly string _appServiceName;

        public Inner_ApprenticeAccountsApiRestClient(ObjectContext objectContext, Inner_ApiFrameworkConfig config) : base(objectContext, config) => _appServiceName = config.config.ApprenticeAccountsAppServiceName;

        protected override string ApiBaseUrl => UrlConfig.InnerApiUrlConfig.Inner_ApprenticeAccountsApiBaseUrl;

        protected override string AppServiceName => _appServiceName;

        public IRestResponse CreateApprentice(Apprentice payload, HttpStatusCode expectedResponse)
        {
            return Execute(Method.POST, $"/apprentices", payload, expectedResponse);
        }
    }
}
