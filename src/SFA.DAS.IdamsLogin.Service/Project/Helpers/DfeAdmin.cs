using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.IdamsLogin.Service.Project.Helpers;

public class DfeAdmin
{
    public string UserId { get; set; }

    public string Password { get; set; }

    public FrameworkList<string> Listofservices { get; set; }

    public override string ToString() => $"UserId:'{UserId}', Password:'{Password}', Listofservices:'{Listofservices}'";
}