using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;

namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;

public class DfeSignInPage(ScenarioContext context) : SignInBasePage(context)
{
    public static string DfePageTitle => "Department for Education Sign-in";

    public static By DfePageheader => By.CssSelector(".govuk-heading-xl");

    protected override By PageHeader => DfePageheader;

    protected override string PageTitle => DfePageTitle;

    private static By SignInButton => By.CssSelector("button.govuk-button[type='submit']");

    protected override void ClickSignInButton() => formCompletionHelper.ClickButtonByText(SignInButton, "Sign in");

    public void SubmitValidLoginDetails(DfeAdminUser dfeAdminUser)
    {
        SubmitValidLoginDetails(dfeAdminUser.Username, dfeAdminUser.Password);
    }
}

public class CheckDfeSignInPage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
{
    protected override string PageTitle => DfeSignInPage.DfePageTitle;

    protected override By Identifier => DfeSignInPage.DfePageheader;
}