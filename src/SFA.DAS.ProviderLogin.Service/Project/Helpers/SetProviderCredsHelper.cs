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

        var dfeprovider = new DfeProviderUser();

        var provider = dfeProviderList.Single(x => x.Listofukprn.Select(y => y.ToString()).Contains(t.Ukprn));

        var providerName = dfeProviderDetailsList.FirstOrDefault(x => x.Ukprn == t.Ukprn);

        dfeprovider.Username = provider.Username;

        dfeprovider.Password = provider.Password;

        dfeprovider.Ukprn = providerName.Ukprn;

        dfeprovider.Name = providerName?.Name.Trim();

        if (EnvironmentConfig.IsPPEnvironment)
        {
            if (string.IsNullOrEmpty(dfeprovider.Username) && string.IsNullOrEmpty(dfeprovider.Password))
            {
                dfeprovider.Username = $"{provider.UsernamePrefix}{t.Ukprn}@{provider.Domain}";

                dfeprovider.Password = $"{provider.PasswordPrefix}{t.Ukprn}";
            }
        }       

        t.Username = dfeprovider.Username;

        t.Password = dfeprovider.Password;

        t.Name = dfeprovider.Name;

        return t;
    }
}
