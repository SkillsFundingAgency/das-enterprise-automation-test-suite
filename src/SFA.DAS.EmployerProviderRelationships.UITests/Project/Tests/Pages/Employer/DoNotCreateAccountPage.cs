

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages.Employer;

public class DoNotCreateAccountPage : RegistrationBasePage
{
    protected override string PageTitle => "Are you sure you do not want to create an account?";

    private static By Decline => By.CssSelector(".govuk-button.govuk-button--warning");

    public DoNotCreateAccountPage(ScenarioContext context) : base(context) => VerifyPage();

    public ApprenticeshipServiceAccountNotCreatedPage ConfirmDoNotCreateAccount()
    {
        formCompletionHelper.Click(Decline);

        return new ApprenticeshipServiceAccountNotCreatedPage(context);
    }
}
