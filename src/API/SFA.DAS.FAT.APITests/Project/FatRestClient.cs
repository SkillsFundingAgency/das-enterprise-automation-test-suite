using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.FAT.APITests.Project
{
    public class FatRestClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : Outer_BaseApiRestClient(objectContext, config)
    {
        protected override string ApiName => "/epaoregister";
    }
}
