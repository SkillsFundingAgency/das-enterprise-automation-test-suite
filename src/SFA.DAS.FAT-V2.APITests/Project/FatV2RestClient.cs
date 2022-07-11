using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.FAT_V2.APITests.Project
{
    public class FatV2RestClient : Outer_BaseApiRestClient
    {
        public FatV2RestClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : base(objectContext, config) { }

        protected override string ApiName => "/epaoregister";
    }
}
