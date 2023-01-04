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

        public RestResponse Ping() => _outerEmployerFinanceHealthApiRestClient.Ping(HttpStatusCode.OK);

        public RestResponse CheckHealth() => _outerEmployerFinanceHealthApiRestClient.CheckHealth(HttpStatusCode.OK);

        public RestResponse GetAccountMinimumSignedAgreementVersion(long accountId)
        {
            return _outerEmployerFinanceApiRestClient.GetAccountMinimumSignedAgreementVersion(accountId, HttpStatusCode.OK);
        }

        public RestResponse GetAccountUserWhichCanReceiveNotifications(long accountId)
        {
            return _outerEmployerFinanceApiRestClient.GetAccountUserWhichCanReceiveNotifications(accountId, HttpStatusCode.OK);
        }

        public RestResponse GetPledges(long accountId)
        {
            return _outerEmployerFinanceApiRestClient.GetPledges(accountId, HttpStatusCode.OK);
        }
        public RestResponse GetProjections(long accountId)
        {
            return _outerEmployerFinanceApiRestClient.GetProjections(accountId, HttpStatusCode.OK);
        }

        public RestResponse GetProviders()
        {
            return _outerEmployerFinanceApiRestClient.GetProviders(HttpStatusCode.OK);
        }

        public RestResponse GetProvidersById()
        {
            return _outerEmployerFinanceApiRestClient.GetProvidersById(HttpStatusCode.OK);
        }

        public RestResponse GetTrainingCoursesFrameworks()
        {
            return _outerEmployerFinanceApiRestClient.GetTrainingCoursesFrameworks(HttpStatusCode.OK);
        }

        public RestResponse GetTrainingCoursesStandards()
        {
            return _outerEmployerFinanceApiRestClient.GetTrainingCoursesStandards(HttpStatusCode.OK);
        }

        public RestResponse GetTransfersCounts(long accountId)
        {
            return _outerEmployerFinanceApiRestClient.GetTransfersCounts(accountId, HttpStatusCode.OK);
        }

        public RestResponse GetTransfersFinancialBreakdown(long accountId)
        {
            return _outerEmployerFinanceApiRestClient.GetTransfersFinancialBreakdown(accountId, HttpStatusCode.OK);
        }
    }
}