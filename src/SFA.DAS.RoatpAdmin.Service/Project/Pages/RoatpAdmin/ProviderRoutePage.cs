namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ProviderRoutePage(ScenarioContext context) : RoatpAdminBasePage(context)
{
    protected override string PageTitle => "What provider route are they using?";

    protected override string AccessibilityPageTitle => "What provider route are they using?";


    protected override By ContinueButton => By.Id("continue");

    public void SubmitProviderType(string providerType)
    {
        SelectRadioOptionByText(providerType);
        Continue();
    }
}
