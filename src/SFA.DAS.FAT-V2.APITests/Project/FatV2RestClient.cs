using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;

namespace SFA.DAS.FAT_V2.APITests.Project
{
    public class FatV2RestClient : Outer_BaseApiRestClient
    {
        public FatV2RestClient(Outer_ApiAuthTokenConfig config) : base(config) { }

        protected override string ApiName => "/epaoregister";
    }
}
