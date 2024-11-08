namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Employer;

public class ApprenticeshipServiceAccountNotCreatedPage : RegistrationBasePage
{
    protected override string PageTitle => "Apprenticeship service account not created";

    public ApprenticeshipServiceAccountNotCreatedPage(ScenarioContext context) : base(context) => VerifyPage();
}
