using SFA.DAS.FAAV2.UITests.Project.Tests.Pages.StubPages;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;

namespace SFA.DAS.FAAV2.UITests.Project.Tests.Pages;

public class FAASignedOutLandingpage(ScenarioContext context) : FAABasePage(context)
{
    protected override By PageHeader => FAASignedOutPageHeader;

    protected override string PageTitle => FAASignedOutPageTitle;

    public static string FAASignedOutPageTitle => "Sign in";

    public static By FAASignedOutPageHeader => By.CssSelector(".govuk-header");

    private static By SignIn => By.CssSelector("a[href*='signin?']");

    public StubSignInFAAPage GoToSignInPage()
    {
        formCompletionHelper.Click(SignIn);

        return new StubSignInFAAPage(context);
    }
}

public class CheckFAASignedOutLandingPage(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
{
    protected override string PageTitle => FAASignedOutLandingpage.FAASignedOutPageTitle;

    protected override By Identifier => FAASignedOutLandingpage.FAASignedOutPageHeader;
}
