using RestSharp;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;
using System.Net;

namespace SFA.DAS.EmployerFinance.APITests.Project
{
    public class Outer_EmployerFinanceApiRestClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : Outer_BaseApiRestClient(objectContext, config)
    {
        protected override string ApiName => "/employerfinance";

        public RestResponse GetAccountMinimumSignedAgreementVersion(long accountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Accounts/{accountId}/minimum-signed-agreement-version", expectedResponse);
        }

        public RestResponse GetAccountUserWhichCanReceiveNotifications(long accountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Accounts/{accountId}/users/which-receive-notifications", expectedResponse);
        }

        public RestResponse GetPledges(long accountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Pledges?accountId={accountId}", expectedResponse);
        }

        public RestResponse GetProjections(long accountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Projections/{accountId}", expectedResponse);
        }

        public RestResponse GetTrainingCoursesFrameworks(HttpStatusCode expectedResponse)
        {
            return Execute($"/TrainingCourses/frameworks", expectedResponse);
        }

        public RestResponse GetTrainingCoursesStandards(HttpStatusCode expectedResponse)
        {
            return Execute($"/TrainingCourses/standards", expectedResponse);
        }

        public RestResponse GetTransfersCounts(long accountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Transfers/{accountId}/counts", expectedResponse);
        }

        public RestResponse GetTransfersFinancialBreakdown(long accountId, HttpStatusCode expectedResponse)
        {
            return Execute($"/Transfers/{accountId}/financial-breakdown", expectedResponse);
        }
    }
}
