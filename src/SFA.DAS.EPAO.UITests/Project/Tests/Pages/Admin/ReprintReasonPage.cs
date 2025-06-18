namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class ReprintReasonPage(ScenarioContext context) : ConfirmReasonBasePage(context)
{
    protected override string PageTitle => "Are you sure this certificate needs reprinting?";
}