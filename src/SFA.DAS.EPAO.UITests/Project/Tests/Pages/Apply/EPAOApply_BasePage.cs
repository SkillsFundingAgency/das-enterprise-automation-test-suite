namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply;

public abstract class EPAOApply_BasePage(ScenarioContext context) : EPAO_BasePage(context)
{
    public AP_ApplicationOverviewPage ClickReturnToApplicationOverviewButton()
    {
        Continue();
        return new(context);
    }
}
