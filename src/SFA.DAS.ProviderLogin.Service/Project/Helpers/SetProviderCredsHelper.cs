using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers;

public static class SetProviderCredsHelper
{
    public static T SetProviderCreds<T>(List<DfeProvider> dfeProviderList, T t) where T : ProviderConfig
    {
        var provider = dfeProviderList.Single(x => x.Listofukprn.Select(y => y.ToString()).Contains(t.Ukprn));

        t.UserId = provider.UserId;

        t.Password = provider.Password;

        return t;
    }
}
