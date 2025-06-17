namespace SFA.DAS.Registration.UITests.Project.Tests.Pages;

public class EmployerAccountCreatedPage(ScenarioContext context) : EmpAccountCreationBase(context)
{
    protected override string PageTitle => "Employer account created";
    private static By GoToYourEmployerAccountHomepage => By.LinkText("Go to your employer account homepage");

    public HomePage SelectGoToYourEmployerAccountHomepage()
    {
        formCompletionHelper.Click(GoToYourEmployerAccountHomepage);

        return new HomePage(context);
    }
}
