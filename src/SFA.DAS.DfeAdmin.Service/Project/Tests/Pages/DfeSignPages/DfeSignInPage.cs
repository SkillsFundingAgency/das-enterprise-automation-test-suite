using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;

namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;

public class DfeSignInPage(ScenarioContext context) : SignInBasePage(context)
{
    public static string DfePageTitle => "Department for Education Sign-in";

    public static By DfePageIdentifier => By.CssSelector(DfePageIdentifierCss);

    protected override By PageHeader => DfePageIdentifier;

    protected override string PageTitle => DfePageTitle;

    public static string DfePageIdentifierCss => ".govuk-heading-xl";

    private static By SignInButton => By.CssSelector("button.govuk-button[type='submit']");

    protected override void ClickSignInButton() => formCompletionHelper.ClickButtonByText(SignInButton, "Sign in");

    public void SubmitValidLoginDetails(DfeAdminUser dfeAdminUser)
    {
        SubmitValidLoginDetails(dfeAdminUser.Username, dfeAdminUser.Password);

        new NotADfeAdminSignPage(context).IsPageDisplayed();
    }
}
