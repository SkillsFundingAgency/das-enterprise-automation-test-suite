using System.Net;
using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TransferMatching.APITests.Project;

public class TransferMatchingJobs_AutoExpireClient(ObjectContext objectContext, TransferMatchingJobsConfig config)
    : OuterJobs_BaseApiRestClient(objectContext, config.HttpAutomaticApplicationExpireFunction_Code)
{
    protected override string ApiBaseUrl => UrlConfig.InnerApiUrlConfig.LevyTransferMatchingJobs_BaseUrl;

    public RestResponse ApplicationsWithAutomaticExpireJob(HttpStatusCode expectedResponse)
    {
        return Execute($"/ApplicationsWithAutomaticExpire", expectedResponse);
    }
}
