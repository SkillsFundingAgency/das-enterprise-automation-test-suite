namespace SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;

public abstract class DfeSignUser
{
    public string Username { get; set; }

    public string Password { get; set; }

    public override string ToString() => $"UserId:'{Username}', Password:'{Password}'";
}
