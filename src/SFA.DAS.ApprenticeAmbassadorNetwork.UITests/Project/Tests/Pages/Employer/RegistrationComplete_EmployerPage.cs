namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Employer;

public class RegistrationComplete_EmployerPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "You have joined the Apprenticeship Ambassador Network";
    private static By GoToOnlinePortal => By.CssSelector("#main-content > div > div > p:nth-child(9) > a");

    public Employer_NetworkHubPage ContinueToAmbassadorHub()
    {
        formCompletionHelper.ClickElement(GoToOnlinePortal);

        return new Employer_NetworkHubPage(context);
    }
}