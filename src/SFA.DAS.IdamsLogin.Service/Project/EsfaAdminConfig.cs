namespace SFA.DAS.IdamsLogin.Service.Project;

public class EsfaAdminConfig
{
    public string AdminUserName { get; set; }
    public string AdminPassword { get; set; }
}

public class AanEsfaSuperAdminConfig : EsfaAdminConfig { }
