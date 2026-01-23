namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeProviderTypePage(ScenarioContext context) : ChangeBasePage(context)
{
    protected override string PageTitle => "What provider route are they using?";

    protected override string AccessibilityPageTitle => "update provider route";

    public ResultsFoundPage ConfirmNewProviderTypeAsEmloyer()
    {
        SelectRadioOptionByText("Employer provider");
        Continue();
        return new ResultsFoundPage(context);
    }

    public ResultsFoundPage ConfirmNewProviderTypeAsMain()
    {
        SelectRadioOptionByText("Main provider");
        Continue();
        return new ResultsFoundPage(context);
    }
}
