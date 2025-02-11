namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Helpers;

public enum RequestType
{
    [ToString("CreateAccount")]
    CreateAccount,
    [ToString("AddAccount")]
    AddAccount,
    [ToString("Permission")]
    Permission
}


public record EprDataHelper
{
    public string EmployerEmail { get; set; }

    public string EmployerOrganisationName { get; set; }

    public string AgreementId { get; set; }

    public List<string> RequestIds { get; init; } = [];

    public string LatestRequestId { get; set; }

    public string RequestStatus { get; set; }

    public string ProviderName { get; set; }

    public string EmployerAorn { get; set; }

    public string EmployerPaye { get; set; }

    public string EmployerFirstName { get; set; }

    public string EmployerLastName { get; set; }
}
