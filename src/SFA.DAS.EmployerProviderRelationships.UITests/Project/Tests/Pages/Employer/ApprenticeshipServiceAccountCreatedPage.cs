namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Employer;

public class ApprenticeshipServiceAccountCreatedPage(ScenarioContext context) : EmpAccountCreationBase(context)
{
    protected override string PageTitle => "Apprenticeship service account created and training provider permissions set";

    private static By GoToHomeLink => By.LinkText("Go to Home");

    public new HomePage GoToHomePage()
    {
        formCompletionHelper.Click(GoToHomeLink);

        return new HomePage(context);
    }
}