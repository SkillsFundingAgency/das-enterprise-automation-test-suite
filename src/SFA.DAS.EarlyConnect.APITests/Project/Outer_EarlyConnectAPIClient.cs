using SFA.DAS.API.Framework.Configs;
using SFA.DAS.API.Framework.RestClients;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EarlyConnect.APITests.Project;

public class Outer_EarlyConnectAPIClient(ObjectContext objectContext, Outer_ApiAuthTokenConfig config) : Outer_BaseApiRestClient(objectContext, config.Apim_SubscriptionKey)
{
    protected override string ApiName => "/earlyconnect";

}
