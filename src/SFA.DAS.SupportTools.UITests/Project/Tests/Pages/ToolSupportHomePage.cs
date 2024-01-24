namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public class ToolSupportHomePage(ScenarioContext context) : ToolSupportBasePage(context)
{
    protected override string PageTitle => "DAS Tools Support";

    #region Locators
    private static By PauseApprenticeshipsLink => By.Id("pauseApprenticeship");
    private static By ResumeApprenticeshipsLink => By.Id("resumeApprenticeship");
    private static By StopApprenticeshipsLink => By.Id("stopApprenticeship");
    private static By SuspendUserAccountsLink => By.Id("suspendUser");
    private static By ReinstateUserAccountsLink => By.Id("reinstateUser");

    #endregion

    public SearchForApprenticeshipPage ClickPauseApprenticeshipsLink()
    {
        formCompletionHelper.Click(PauseApprenticeshipsLink);
        return new(context);
    }

    public SearchForApprenticeshipPage ClickResumeApprenticeshipsLink()
    {
        formCompletionHelper.Click(ResumeApprenticeshipsLink);
        return new(context);
    }

    public SearchForApprenticeshipPage ClickStopApprenticeshipsLink()
    {
        formCompletionHelper.Click(StopApprenticeshipsLink);
        return new(context);
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
    public bool IsPauseApprenticeshipLinkVisible() => pageInteractionHelper.IsElementDisplayed(PauseApprenticeshipsLink);

    public bool IsResumeApprenticeshipLinkVisible() => pageInteractionHelper.IsElementDisplayed(ResumeApprenticeshipsLink);

    public bool IsStopApprenticeshipLinkVisible() => pageInteractionHelper.IsElementDisplayed(StopApprenticeshipsLink);

    public bool IsReinstateApprenticeshipLinkVisible() => pageInteractionHelper.IsElementDisplayed(ReinstateUserAccountsLink);

    public bool IsSuspendApprenticeshipLinkVisible() => pageInteractionHelper.IsElementDisplayed(SuspendUserAccountsLink);
}
