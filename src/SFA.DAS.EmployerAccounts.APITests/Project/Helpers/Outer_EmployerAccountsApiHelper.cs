using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.ConfigurationBuilder;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerAccounts.APITests.Project.Helpers
{
    public class Outer_EmployerAccountsApiHelper
    {
        private readonly Outer_EmployerAccountsApiRestClient _outerEmployerAccountsApiRestClient;
        private readonly Outer_EmployerAccountsHealthApiRestClient _outerEmployerAccountsHealthApiRestClient;
        private readonly ObjectContext _objectContext;
        protected readonly FrameworkHelpers.RetryAssertHelper _assertHelper;

        internal Outer_EmployerAccountsApiHelper(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<FrameworkHelpers.RetryAssertHelper>();
            _outerEmployerAccountsApiRestClient = new Outer_EmployerAccountsApiRestClient(_objectContext, context.GetOuter_ApiAuthTokenConfig());
            _outerEmployerAccountsHealthApiRestClient = new Outer_EmployerAccountsHealthApiRestClient(_objectContext);
        }

        public IRestResponse Ping() => _outerEmployerAccountsHealthApiRestClient.Ping(HttpStatusCode.OK);

        public IRestResponse CheckHealth() => _outerEmployerAccountsHealthApiRestClient.CheckHealth(HttpStatusCode.OK);

        public IRestResponse GetAccountEnglishFractionCurrent(string hashedAccountId)
        {
            return _outerEmployerAccountsApiRestClient.GetAccountEnglishFractionCurrent(hashedAccountId, HttpStatusCode.OK);
        }

        public IRestResponse GetAccountEnglishFractionHistory(string hashedAccountId)
        {
            return _outerEmployerAccountsApiRestClient.GetAccountEnglishFractionHistory(hashedAccountId, HttpStatusCode.OK);
        }
    }
}