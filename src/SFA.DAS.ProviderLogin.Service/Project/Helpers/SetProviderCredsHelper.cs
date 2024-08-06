using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers;

internal static class SetProviderCredsHelper
{
    internal static T SetProviderCreds<T>(FrameworkList<DfeProviderUsers> dfeProviderList, List<ProviderDetails> dfeProviderDetailsList, T t) where T : ProviderConfig
    {
        if (string.IsNullOrEmpty(t.Ukprn)) return t;

        if (!(dfeProviderList.Any(x => x.Listofukprn.Select(y => y.ToString()).Contains(t.Ukprn))))
        {
            FrameworkList<string> message = [Environment.NewLine];

            foreach (var item in dfeProviderList) message.Add($"{item.Username} [{string.Join(",", item.Listofukprn)}]");

            throw new Exception($"Ukprn '{t.Ukprn}' is not found in list of dfeproviders {message}");
        }

        var provider = dfeProviderList.Single(x => x.Listofukprn.Select(y => y.ToString()).Contains(t.Ukprn));

        var providerName = dfeProviderDetailsList.SingleOrDefault(x => x.Ukprn == t.Ukprn);

        t.Username = provider.Username;

        t.Password = provider.Password;

        t.Name = providerName?.Name;

        return t;
    }
}
