using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;
using System.Net;

namespace SFA.DAS.EmployerAccounts.APITests.Project
{
    public class Inner_EmployerAccountsApiRestClient : Inner_BaseApiRestClient
    {
        public Inner_EmployerAccountsApiRestClient(ObjectContext objectContext, API.Framework.Configs.Inner_ApiFrameworkConfig config) : base(objectContext, config) { }

        protected override string ApiBaseUrl => UrlConfig.InnerApiUrlConfig.Inner_EmployerAccountsApiBaseUrl;

        protected override string AppServiceName => config.config.EmployerAccountsAppServiceName;

        public void ExecuteEndpoint(string endpoint, HttpStatusCode expectedResponse)
        {
           Execute(RestSharp.Method.GET, endpoint, string.Empty, expectedResponse);
        }
    }
}
