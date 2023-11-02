using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers;

public class DfeProvider
{
    public string UserId { get; set; }

    public string Password { get; set; }

    public FrameworkList<int> Listofukprn { get; set; }

    public override string ToString() => $"UserId:'{UserId}', Password:'{Password}', Listofukprn:'{Listofukprn}'";
}
