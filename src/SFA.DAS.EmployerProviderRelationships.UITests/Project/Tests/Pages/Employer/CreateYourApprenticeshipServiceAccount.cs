

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Employer;

public class CreateYourApprenticeshipServiceAccount : RegistrationBasePage
{
    protected override string PageTitle => "Create your apprenticeship service account";

    private static By ChangeNameSelector => By.LinkText("Change name");

    private static By Decline => By.CssSelector("a[href*='createaccount/decline']");

    public CreateYourApprenticeshipServiceAccount(ScenarioContext context) : base(context) => VerifyPage();

    public ChangeEmployerName ChangeName()
    {
        formCompletionHelper.Click(ChangeNameSelector);

        return new ChangeEmployerName(context);
    }

    public DoNotCreateAccountPage DoNotCreateAccount()
    {
        formCompletionHelper.Click(Decline);

        return new DoNotCreateAccountPage(context);
    }
}
