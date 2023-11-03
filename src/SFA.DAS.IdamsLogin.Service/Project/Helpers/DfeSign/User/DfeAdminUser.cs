namespace SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;

public abstract class DfeAdminUser : NonEasAccountUser
{
    public DfeAdminUser(string adminServiceName) => AdminServiceName = adminServiceName;

    public string AdminServiceName { get; init; }

    public override string ToString() => $"{base.ToString()}, ServiceName:'{AdminServiceName}'";
}

public class AanAdminUser : DfeAdminUser
{
    public AanAdminUser() : base("aanadmin") { }
}

public class SupportConsoleTier2User : DfeAdminUser
{
    public SupportConsoleTier2User() : base("supportconsoletier2") { }
}

public class SupportToolScpUser : DfeAdminUser
{
    public SupportToolScpUser() : base("supporttoolscpuser") { }
}
