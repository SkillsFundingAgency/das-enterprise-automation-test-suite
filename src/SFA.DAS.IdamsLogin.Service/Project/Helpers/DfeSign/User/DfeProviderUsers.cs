namespace SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;

public class DfeProviderUsers : DfeSignUser
{
    public FrameworkList<int> Listofukprn { get; set; }

    public override string ToString() => $"{base.ToString()}, Listofukprn:'{Listofukprn}'";
}
