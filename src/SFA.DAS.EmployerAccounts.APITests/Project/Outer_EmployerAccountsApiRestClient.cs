using RestSharp;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;
using System.Net;

namespace SFA.DAS.EmployerAccounts.APITests.Project
{
    public class Outer_EmployerAccountsApiRestClient : Outer_BaseApiRestClient
    {
        public Outer_EmployerAccountsApiRestClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : base(objectContext, config) { }

        protected override string ApiName => "/employeraccounts";

        public IRestResponse GetAccountEnglishFractionCurrent(string hashedAccountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Accounts/{hashedAccountId}/levy/english-fraction-current", expectedResponse);
        }

        public IRestResponse GetAccountEnglishFractionHistory(string hashedAccountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Accounts/{hashedAccountId}/levy/english-fraction-history", expectedResponse);
        }
    }
}
