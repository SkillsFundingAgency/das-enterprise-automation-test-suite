namespace SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;

public class DfeProviderUser : DfeSignUser
{
    public string Ukprn { get; set; }

    public string Name { get; set; }

    public override string ToString() => $"{base.ToString()}, Name:'{Name}', Ukprn : {Ukprn}";
}

public class DfeProviderUsers : DfeSignUser
{
    public string Domain { get; set; }

    public string UsernamePrefix { get; set; }

    public string PasswordPrefix { get; set; }

    public FrameworkList<int> Listofukprn { get; set; }

    public override string ToString() => $"{base.ToString()}, Listofukprn:'{Listofukprn}'";
}
