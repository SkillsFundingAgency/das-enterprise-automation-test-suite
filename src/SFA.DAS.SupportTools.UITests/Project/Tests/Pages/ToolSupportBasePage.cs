namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public abstract class ToolSupportBasePage : VerifyBasePage
{
    #region Helpers and Context
    #endregion

    private static By SelectAllInput => By.CssSelector("input[name='btSelectAll'][type='checkbox']");

    public ToolSupportBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
    {
        if (verifyPage) VerifyPage();
    }

    protected void ClickSelectAllCheckBox() => formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(SelectAllInput));

}
