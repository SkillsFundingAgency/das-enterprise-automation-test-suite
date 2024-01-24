using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Outer_ApprenticeCommitmentsHealthApiRestClient(ObjectContext objectContext) : Outer_HealthApiRestClient(objectContext, UrlConfig.OuterApiUrlConfig.Outer_ApprenticeCommitmentsHealthBaseUrl)
    {
    }
}
