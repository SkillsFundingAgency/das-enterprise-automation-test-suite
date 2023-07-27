namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public class ResumeApprenticeshipsPage : ToolSupportBasePage
{
    protected override string PageTitle => "Resume apprenticeships";

    #region Locators
    private static By ResumeApprenticeshipsbtn => By.Id("okButton");
    private static By StatusColumn => By.CssSelector("#apprenticeshipsTable tr td:nth-child(11)");
    #endregion

    public ResumeApprenticeshipsPage(ScenarioContext context) : base(context) { }

    public ResumeApprenticeshipsPage ClickResumeBtn()
    {
        formCompletionHelper.Click(ResumeApprenticeshipsbtn);
        return this;
    }

    public List<IWebElement> GetStatusColumn() => pageInteractionHelper.FindElements(StatusColumn);
}
