using SFA.DAS.FrameworkHelpers;
using System;
using System.Linq;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers;

internal static class SetProviderCredsHelper
{
    internal static T SetProviderCreds<T>(FrameworkList<DfeProvider> dfeProviderList, T t) where T : ProviderConfig
    {
        if (string.IsNullOrEmpty(t.Ukprn)) return t;

        if (!(dfeProviderList.Any(x => x.Listofukprn.Select(y => y.ToString()).Contains(t.Ukprn))))
        {
            FrameworkList<string> message = new() {Environment.NewLine};  

            foreach (var item in dfeProviderList) message.Add($"{item.UserId} [{string.Join(",", item.Listofukprn)}]");

            throw new Exception($"Ukprn '{t.Ukprn}' is not found in list of dfeproviders {message}");
        }

        var provider = dfeProviderList.Single(x => x.Listofukprn.Select(y => y.ToString()).Contains(t.Ukprn));

        t.UserId = provider.UserId;

        t.Password = provider.Password;

        return t;
    }
}
