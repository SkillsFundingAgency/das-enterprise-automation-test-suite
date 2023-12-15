using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;

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

public class CheckDfeSignInPage(ScenarioContext context) : CheckPageUsingShorterTimeOut(context)
{
    protected override string PageTitle => DfeSignInPage.DfePageTitle;

    protected override By Identifier => DfeSignInPage.DfePageheader;

    public override bool IsPageDisplayed() => checkPageInteractionHelper.WithoutImplicitWaits(() => pageInteractionHelper.VerifyPage(Identifier, PageTitle));
}