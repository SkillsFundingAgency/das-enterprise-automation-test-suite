using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;

namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;

public class DfeSignInPage(ScenarioContext context) : SignInBasePage(context)
{
    public static string DfePageTitle => "Department for Education Sign-in";

    public static By DfePageIdentifier => By.CssSelector(DfePageIdentifierCss);

    public static string DfePageIdentifierCss => ".govuk-heading-xl";

    protected override By PageHeader => DfePageIdentifier;

    protected override string PageTitle => DfePageTitle;

    private static By SignInButton => By.CssSelector("button.govuk-button[type='submit']");

    protected override void ClickSignInButton() => formCompletionHelper.ClickButtonByText(SignInButton, "Sign in");

    public void SubmitValidLoginDetails(DfeAdminUser dfeAdminUser)
    {
        SubmitValidLoginDetails(dfeAdminUser.Username, dfeAdminUser.Password);
    }

    public new void SubmitValidLoginDetails(string username, string password)
    {
        base.SubmitValidLoginDetails(username, password);

        new NotADfeSignPage(context).IsPageDisplayed();
    }
}

public class CheckDfeSignInPage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
{
    protected override string PageTitle => DfeSignInPage.DfePageTitle;

    protected override By Identifier => DfeSignInPage.DfePageIdentifier;
}

public class NotADfeSignPage(ScenarioContext context) : CheckPageTitleLongerTimeOut(context)
{
    protected override string PageTitle => DfeSignInPage.DfePageTitle;

    protected override By Identifier => DfeSignInPage.DfePageIdentifier;

    public override bool IsPageDisplayed() 
    {
        SetDebugInformation($"Check page title is NOT : '{PageTitle}'");

        return checkPageInteractionHelper.Verify(() =>
        {
            var result = IsPageCurrent;

            return result.Item1 ? throw new Exception(ExceptionMessageHelper.GetExceptionMessage("'Dfe Sign'", $"Should have navigated from '{PageTitle}'", result.Item2)) : true;

        }, null);
    }
}