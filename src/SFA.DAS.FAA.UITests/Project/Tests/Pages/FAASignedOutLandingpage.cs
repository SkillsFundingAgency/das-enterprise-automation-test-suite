using SFA.DAS.FAA.UITests.Project.Tests.Pages.StubPages;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAASignedOutLandingpage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => FAASignedOutPageHeader;

    protected override string PageTitle => FAASignedOutPageTitle;

    public static string FAASignedOutPageTitle => "Sign in or create an account";

    public static By FAASignedOutPageHeader => By.CssSelector(".one-login-header__nav__link");

    private static By SignIn => By.CssSelector("a[href*='signin?']");

    private static By AcceptAdditionalCookies => By.CssSelector("button[onclick='acceptCookies(true);']");

    private static By HideAdditionalCookies => By.CssSelector("button[onclick='hideAcceptBanner();']");

    private static By DeleteConfirmatioBanner => By.CssSelector(".govuk-notification-banner__heading");


    public StubSignInFAAPage GoToSignInPage()
    {
        formCompletionHelper.Click(AcceptAdditionalCookies);
        formCompletionHelper.Click(HideAdditionalCookies);
        formCompletionHelper.Click(SignIn);

        return new StubSignInFAAPage(context);
    }

    public void VerifyNotification()
    {
        VerifyPage(DeleteConfirmatioBanner, "Find an apprenticeship account deleted.");
    }
}

public class CheckFAASignedOutLandingPage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
{
    protected override string PageTitle => FAASignedOutLandingpage.FAASignedOutPageTitle;

    protected override By Identifier => FAASignedOutLandingpage.FAASignedOutPageHeader;
}
