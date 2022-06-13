namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_LandingPage : EPAO_BasePage
{
    protected override string PageTitle => "Apprenticeship assessment service";

    #region Locators
    private static By StartNowButton => By.LinkText("Start now");
    private static By CreateAnAccountLink => By.XPath("//a[@href='/Account/CreateAnAccount']");
    #endregion

    public AS_LandingPage(ScenarioContext context) : base(context)
    {
        VerifyPage();
        AcceptCookies();
    }

    public AS_LoginPage GoToLoginPage()
    {
        formCompletionHelper.Click(StartNowButton);
        return new(context);
    }

    public AS_ApplyForAStandardPage AlreadyLoginGoToApplyForAStandardPage()
    {
        formCompletionHelper.Click(StartNowButton);
        return new(context);
    }

    public AS_CreateAnAccountPage GoToCreateAccountPage()
    {
        formCompletionHelper.Click(CreateAnAccountLink);
        return new(context);
    }

    public AS_LoggedInHomePage AlreadyLoginGoToLoggedInHomePage()
    {
        formCompletionHelper.Click(StartNowButton);
        return new(context);
    }
}
