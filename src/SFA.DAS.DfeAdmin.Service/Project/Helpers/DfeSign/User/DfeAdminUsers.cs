namespace SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;

public class DfeAdminUsers : DfeSignUser
{
    public FrameworkList<string> Listofservices { get; set; }

    public override string ToString() => $"{base.ToString()}, Listofservices:'{Listofservices}'";
}