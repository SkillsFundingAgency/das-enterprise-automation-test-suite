using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;

namespace SFA.DAS.DfeAdmin.Service.Project.Helpers;

public static class SetDfeAdminCredsHelper
{
    public static T SetDfeAdminCreds<T>(FrameworkList<DfeAdminUsers> dfeAdmins, T t) where T : DfeAdminUser
    {
        if (string.IsNullOrEmpty(t.AdminServiceName)) return t;

        if (!dfeAdmins.Any(x => x.Listofservices.Select(y => y.ToString()).Contains(t.AdminServiceName)))
        {
            FrameworkList<string> message = new() { Environment.NewLine };

            foreach (var item in dfeAdmins) message.Add($"{item.Username} [{string.Join(",", item.Listofservices)}]");

            throw new Exception($"Service '{t.AdminServiceName}' is not found in list of dfeadmins {message}");
        }

        var adminCreds = dfeAdmins.Single(x => x.Listofservices.Select(y => y.ToString()).Contains(t.AdminServiceName));

        t.Username = adminCreds.Username;

        t.Password = adminCreds.Password;

        return t;
    }
}