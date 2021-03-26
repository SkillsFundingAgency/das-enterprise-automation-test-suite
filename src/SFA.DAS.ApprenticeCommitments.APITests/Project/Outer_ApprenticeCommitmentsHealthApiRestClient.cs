using RestSharp;
using SFA.DAS.API.Framework;
using SFA.DAS.API.Framework.RestClients;
using System.Net;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class Outer_ApprenticeCommitmentsHealthApiRestClient : Outer_HealthApiRestClient
    {
        public Outer_ApprenticeCommitmentsHealthApiRestClient() : base(UrlConfig.Outer_ApprenticeCommitmentsHealthBaseUrl) { }
    }
}
