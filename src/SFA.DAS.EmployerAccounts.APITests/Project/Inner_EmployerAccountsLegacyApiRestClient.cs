using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;
using System.Net;

namespace SFA.DAS.EmployerAccounts.APITests.Project
{
    public class Inner_EmployerAccountsLegacyApiRestClient : Inner_BaseApiRestClient
    {
        public Inner_EmployerAccountsLegacyApiRestClient(ObjectContext objectContext, API.Framework.Configs.Inner_ApiFrameworkConfig config) : base(objectContext, config) { }

        protected override string ApiBaseUrl => UrlConfig.InnerApiUrlConfig.Inner_EmployerAccountsLegacyApiBaseUrl;

        protected override string AppServiceName => config.config.EmployerAccountsLegacyAppServiceName;

        public void ExecuteEndpoint(string endpoint, HttpStatusCode expectedResponse)
        {
           Execute(RestSharp.Method.GET, endpoint, string.Empty, expectedResponse);
        }

        public IRestResponse ExecuteEndpoint(string endpoint)
        {
            return Execute(RestSharp.Method.GET, endpoint, string.Empty, HttpStatusCode.OK);
        }
    }
}
