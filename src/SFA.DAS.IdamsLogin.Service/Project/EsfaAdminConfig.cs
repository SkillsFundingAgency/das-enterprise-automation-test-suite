namespace SFA.DAS.IdamsLogin.Service.Project;

public class EsfaAdminConfig
{
    public string AdminUserName { get; set; }
    public string AdminPassword { get; set; }
}

public class AanEsfaSuperAdminConfig : EsfaAdminConfig { }


public abstract class DfeAdminConfig
{
    public DfeAdminConfig(string adminServiceName)
    {
        AdminServiceName = adminServiceName;
    }

    public string AdminUserName { get; set; }
    public string AdminPassword { get; set; }
    public string AdminServiceName { get; init; }
}

public class AanAdminConfig : DfeAdminConfig
{
    public AanAdminConfig() : base("aanadmin") { }
}