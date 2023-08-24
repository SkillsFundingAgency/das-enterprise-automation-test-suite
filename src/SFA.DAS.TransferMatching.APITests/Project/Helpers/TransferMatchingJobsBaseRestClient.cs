using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TransferMatching.APITests.Project.Helpers;

public abstract class TransferMatchingJobsBaseRestClient : BaseApiRestClient
{
    protected readonly string _code;

    protected abstract string ApiName { get; }

    protected virtual string Code => _code;

    protected override string ApiBaseUrl => UrlConfig.InnerApiUrlConfig.LevyTransferMatchingJobs_BaseUrl;

    protected TransferMatchingJobsBaseRestClient(ObjectContext objectContext, string code) : base(objectContext) => _code = code;

    protected override void AddResource(string resource) => restRequest.Resource = resource.Contains(ApiName) ? resource : $"{ApiName}{resource}";
  
}
