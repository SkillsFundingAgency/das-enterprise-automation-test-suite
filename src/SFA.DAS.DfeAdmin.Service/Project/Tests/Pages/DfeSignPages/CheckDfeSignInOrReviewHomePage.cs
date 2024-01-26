namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;

public class CheckDfeSignInOrReviewHomePage(ScenarioContext context) : CheckMultipleHomePage(context)
{
    public override string[] PageIdentifierCss => [DfeSignInPage.DfePageIdentifierCss, DfeAfterSignIdentifiers.Reviewer_HomePageIdentifierCss];

    public override string[] PageTitles => [DfeSignInPage.DfePageTitle, DfeAfterSignIdentifiers.Reviewer_HomePageTitle];

    public bool IsDfeSignPageDisplayed() => ActualDisplayedPage(DfeSignInPage.DfePageTitle);
}