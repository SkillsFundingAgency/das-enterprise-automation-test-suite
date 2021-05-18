using RestSharp;
using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using System.Net;

namespace SFA.DAS.AssessorCertification.APITests.Project
{
   public class Outer_AssessorCertificationApiRestClient : Outer_BaseApiRestClient
    {
        public Outer_AssessorCertificationApiRestClient(Outer_ApiAuthTokenConfig config) : base(config) { }

        protected override string ApiName => "/epacertification";
    }
}
