namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;

public class AP_PR5_DeclarationPage : EPAO_BasePage
{
    protected override string PageTitle => "Declaration";

    public AP_PR5_DeclarationPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_ApplicationOverviewPage ClickAcceptAndContinueInDeclarationPage()
    {
        Continue();
        return new AP_ApplicationOverviewPage(context);
    }
}
