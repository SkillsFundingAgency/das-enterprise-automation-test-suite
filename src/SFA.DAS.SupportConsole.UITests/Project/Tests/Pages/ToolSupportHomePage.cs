namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class ToolSupportHomePage : ToolSupportBasePage
{
    protected override string PageTitle => "DAS Tools Support";

    #region Locators
    private static By PauseApprenticeshipsLink => By.Id("pauseApprenticeship");
    private static By ResumeApprenticeshipsLink => By.Id("resumeApprenticeship");
    private static By StopApprenticeshipsLink => By.Id("stopApprenticeship");
    private static By SuspendUserAccountsLink => By.Id("suspendUser");
    private static By ReinstateUserAccountsLink => By.Id("reinstateUser");
    #endregion

    public ToolSupportHomePage(ScenarioContext context) : base(context) { }

    public SearchForApprenticeshipPage ClickPauseApprenticeshipsLink()
    {
        formCompletionHelper.Click(PauseApprenticeshipsLink);
        return new (context);
    }

    public SearchForApprenticeshipPage ClickResumeApprenticeshipsLink()
    {
        formCompletionHelper.Click(ResumeApprenticeshipsLink);
        return new (context);
    }

    public SearchForApprenticeshipPage ClickStopApprenticeshipsLink()
    {
        formCompletionHelper.Click(StopApprenticeshipsLink);
        return new (context);
    }

    public SearchForAnEmployerPage ClickSuspendUserAccountsLink()
    {
        formCompletionHelper.Click(SuspendUserAccountsLink);
        return new(context);
    }

    public SearchForAnEmployerPage ClickReinstateUserAccountsLink()
    {
        formCompletionHelper.Click(ReinstateUserAccountsLink);
        return new(context);
    }
}
