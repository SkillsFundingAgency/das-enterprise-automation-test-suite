namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public abstract class ToolSupportBasePage : VerifyBasePage
{
    #region Helpers and Context
    #endregion

    public ToolSupportBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
    {
        if (verifyPage) VerifyPage();
    }
}
