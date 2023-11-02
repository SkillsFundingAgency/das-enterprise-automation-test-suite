using SFA.DAS.FrameworkHelpers;
using System;
using System.Linq;

namespace SFA.DAS.IdamsLogin.Service.Project.Helpers;

public static class SetDfeAdminCredsHelper
{
    public static T SetDfeAdminCreds<T>(FrameworkList<DfeAdmin> dfeAdmins, T t) where T : DfeAdminConfig
    {
        if (string.IsNullOrEmpty(t.AdminServiceName)) return t;

        if (!dfeAdmins.Any(x => x.Listofservices.Select(y => y.ToString()).Contains(t.AdminServiceName)))
        {
            FrameworkList<string> message = new() { Environment.NewLine };

            foreach (var item in dfeAdmins) message.Add($"{item.UserId} [{string.Join(",", item.Listofservices)}]");

            throw new Exception($"Service '{t.AdminServiceName}' is not found in list of dfeadmins {message}");
        }

        var adminCreds = dfeAdmins.Single(x => x.Listofservices.Select(y => y.ToString()).Contains(t.AdminServiceName));

        t.AdminUserName = adminCreds.UserId;

        t.AdminPassword = adminCreds.Password;

        return t;
    }
}