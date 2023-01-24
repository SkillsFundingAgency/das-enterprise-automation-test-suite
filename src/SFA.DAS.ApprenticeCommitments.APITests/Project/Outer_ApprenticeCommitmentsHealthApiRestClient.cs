using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Outer_ApprenticeCommitmentsHealthApiRestClient : Outer_HealthApiRestClient
    {
        public Outer_ApprenticeCommitmentsHealthApiRestClient(ObjectContext objectContext) : base(objectContext, UrlConfig.OuterApiUrlConfig.Outer_ApprenticeCommitmentsHealthBaseUrl) { }
    }
}
