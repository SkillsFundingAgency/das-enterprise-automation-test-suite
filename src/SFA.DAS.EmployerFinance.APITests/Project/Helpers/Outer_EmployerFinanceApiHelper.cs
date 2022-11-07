using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.ConfigurationBuilder;
using System;
using System.Net;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFinance.APITests.Project.Helpers
{
    public class Outer_EmployerFinanceApiHelper
    {
        private readonly Outer_EmployerFinanceApiRestClient _outerEmployerFinanceApiRestClient;
        private readonly Outer_EmployerFinanceHealthApiRestClient _outerEmployerFinanceHealthApiRestClient;
        private readonly ObjectContext _objectContext;
        protected readonly FrameworkHelpers.RetryAssertHelper _assertHelper;

        internal Outer_EmployerFinanceApiHelper(ScenarioContext context)
        {
            _objectContext = context.Get<ObjectContext>();
            _assertHelper = context.Get<FrameworkHelpers.RetryAssertHelper>();
            _outerEmployerFinanceApiRestClient = new Outer_EmployerFinanceApiRestClient(_objectContext, context.GetOuter_ApiAuthTokenConfig());
            _outerEmployerFinanceHealthApiRestClient = new Outer_EmployerFinanceHealthApiRestClient(_objectContext);
        }

        public IRestResponse Ping() => _outerEmployerFinanceHealthApiRestClient.Ping(HttpStatusCode.OK);

        public IRestResponse CheckHealth() => _outerEmployerFinanceHealthApiRestClient.CheckHealth(HttpStatusCode.OK);

        public IRestResponse GetAccountMinimumSignedAgreementVersion(long accountId)
        {
            return _outerEmployerFinanceApiRestClient.GetAccountMinimumSignedAgreementVersion(accountId, HttpStatusCode.OK);
        }

        public IRestResponse GetAccountUserWhichCanReceiveNotifications(long accountId)
        {
            return _outerEmployerFinanceApiRestClient.GetAccountUserWhichCanReceiveNotifications(accountId, HttpStatusCode.OK);
        }

        public IRestResponse GetPledges(long accountId)
        {
            return _outerEmployerFinanceApiRestClient.GetPledges(accountId, HttpStatusCode.OK);
        }
        public IRestResponse GetProjections(long accountId)
        {
            return _outerEmployerFinanceApiRestClient.GetProjections(accountId, HttpStatusCode.OK);
        }

        public IRestResponse GetProviders()
        {
            return _outerEmployerFinanceApiRestClient.GetProviders(HttpStatusCode.OK);
        }

        public IRestResponse GetProvidersById()
        {
            return _outerEmployerFinanceApiRestClient.GetProvidersById(HttpStatusCode.OK);
        }

        public IRestResponse GetTrainingCoursesFrameworks()
        {
            return _outerEmployerFinanceApiRestClient.GetTrainingCoursesFrameworks(HttpStatusCode.OK);
        }

        public IRestResponse GetTrainingCoursesStandards()
        {
            return _outerEmployerFinanceApiRestClient.GetTrainingCoursesStandards(HttpStatusCode.OK);
        }

        public IRestResponse GetTransfersCounts(long accountId)
        {
            return _outerEmployerFinanceApiRestClient.GetTransfersCounts(accountId, HttpStatusCode.OK);
        }

        public IRestResponse GetTransfersFinancialBreakdown(long accountId)
        {
            return _outerEmployerFinanceApiRestClient.GetTransfersFinancialBreakdown(accountId, HttpStatusCode.OK);
        }
    }
}