namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeProviderTypePage : ChangeBasePage
{
    protected override string PageTitle => $"Change provider type for {objectContext.GetProviderName()}";

    protected override string AccessibilityPageTitle => "Change provider type for provider";

    private static By OrganisationTypeIdEmployer => By.Id("OrganisationTypeIdEmployer");

    public ChangeProviderTypePage(ScenarioContext context) : base(context) { }

    public ResultsFoundPage ConfirmNewProviderTypeAsEmloyer()
    {
        SelectRadioOptionByText("Employer provider");
        formCompletionHelper.SelectFromDropDownByValue(OrganisationTypeIdEmployer, "20");
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
