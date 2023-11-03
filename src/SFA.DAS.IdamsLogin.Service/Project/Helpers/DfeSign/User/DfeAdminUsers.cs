namespace SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;

public class DfeAdminUsers : DfeSignUser
{
    public FrameworkList<string> Listofservices { get; set; }

    public override string ToString() => $"{base.ToString()}, Listofservices:'{Listofservices}'";
}