namespace SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;

public record ProviderDetails(string Ukprn, string Name)
{
    public override string ToString() => $"Name:'{Name}', Ukprn : {Ukprn}";
}
