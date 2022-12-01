using Newtonsoft.Json;
using RestSharp;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerFinance.APITests.Project.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace SFA.DAS.EmployerFinance.APITests.Project
{
    public class Outer_EmployerFinanceApiRestClient : Outer_BaseApiRestClient
    {
        public Outer_EmployerFinanceApiRestClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : base(objectContext, config) { }

        protected override string ApiName => "/employerfinance";

        public IRestResponse GetAccountMinimumSignedAgreementVersion(long accountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Accounts/{accountId}/minimum-signed-agreement-version", expectedResponse);
        }

        public IRestResponse GetAccountUserWhichCanReceiveNotifications(long accountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Accounts/{accountId}/users/which-receive-notifications", expectedResponse);
        }

        public IRestResponse GetPledges(long accountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Pledges?accountId={accountId}", expectedResponse);
        }

        public IRestResponse GetProjections(long accountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Projections/{accountId}", expectedResponse);
        }

        public IRestResponse GetProviders(HttpStatusCode expectedResponse)
        {
            return Execute($"/Providers", expectedResponse);
        }

        public IRestResponse GetProvidersById(HttpStatusCode expectedResponse)
        {
            var response = Execute($"/Providers", expectedResponse);
            var result = JsonConvert.DeserializeObject<ProviderSummary>(response.Content);
            return Execute($"/Providers/{result.Providers.ToList()[0].Ukprn}", expectedResponse);
        }

        public IRestResponse GetTrainingCoursesFrameworks(HttpStatusCode expectedResponse)
        {
            return Execute($"/TrainingCourses/frameworks", expectedResponse);
        }

        public IRestResponse GetTrainingCoursesStandards(HttpStatusCode expectedResponse)
        {
            return Execute($"/TrainingCourses/standards", expectedResponse);
        }

        public IRestResponse GetTransfersCounts(long accountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Transfers/{accountId}/counts", expectedResponse);
        }

        public IRestResponse GetTransfersFinancialBreakdown(long accountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Transfers/{accountId}/financial-breakdown", expectedResponse);
        }
    }
}
