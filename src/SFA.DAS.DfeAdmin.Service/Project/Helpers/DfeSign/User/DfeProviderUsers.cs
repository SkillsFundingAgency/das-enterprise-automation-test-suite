namespace SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;

public record ProviderDetails(string Ukprn, string Name)
{
    public override string ToString() => $"Name:'{Name}', Ukprn : {Ukprn}";
}

public class DfeProviderUsers : DfeSignUser
{
    public FrameworkList<int> Listofukprn { get; set; }

    public FrameworkList<ProviderDetails> ProviderDetails { get; set; }

    public override string ToString() => $"{base.ToString()}, Listofukprn:'{Listofukprn}'";
}
