namespace SFA.DAS.SupportConsole.UITests.Project.Models;

internal sealed class Filters
{
    public string EmployerName { get; set; }
    public string ProviderName { get; set; }
    public string Ukprn { get; set; }
    public string EndDate { get; set; }
    public string Uln { get; set; }
    public string Status { get; set; }
    public int? TotalRecords { get; set; }

    public override string ToString()
    {
        return $"{Environment.NewLine}EmployerName: '{EmployerName}', ProviderName: '{ProviderName}', Ukprn: '{Ukprn}', EndDate: {EndDate}, Status: '{Status}', TotalRecords: '{TotalRecords}'";
    }
}
