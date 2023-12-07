namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

// This page can be removed later after we know what sign out should do in PP.
public class SignedOutPage : EPAOAdmin_BasePage
{
    protected override By PageHeader => By.CssSelector("#mainContent");

    protected override string PageTitle => "You have been logged out from the application successfully";

    public SignedOutPage(ScenarioContext context) : base(context) => VerifyPage();
}
