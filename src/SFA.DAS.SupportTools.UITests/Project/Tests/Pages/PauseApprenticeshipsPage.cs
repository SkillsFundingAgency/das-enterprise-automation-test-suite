namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public class PauseApprenticeshipsPage : ToolSupportBasePage
{
    protected override string PageTitle => "Pause apprenticeships";

    #region Locators
    private static By PauseApprenticeshipsbtn => By.Id("okButton");
    private static By StatusColumn => By.CssSelector("#apprenticeshipsTable tr td:nth-child(11)");
    #endregion

    public PauseApprenticeshipsPage(ScenarioContext context) : base(context) { }

    public PauseApprenticeshipsPage ClickPauseBtn()
    {
        formCompletionHelper.Click(PauseApprenticeshipsbtn);
        return this;
    }

    public List<IWebElement> GetStatusColumn() => pageInteractionHelper.FindElements(StatusColumn);

}
