namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;

public class AP_PR4_ConfirmOrganisationPage : EPAO_BasePage
{
    protected override string PageTitle => "Confirm organisation";

    public AP_PR4_ConfirmOrganisationPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_PR5_DeclarationPage ClickConfirmAndApplyButtonInConfirmOrgPage()
    {
        Continue();
        return new AP_PR5_DeclarationPage(context);
    }
}
