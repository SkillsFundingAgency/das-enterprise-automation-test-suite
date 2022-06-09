namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;

public class AP_OD2_UseTradingNameOnRegisterPage : EPAO_BasePage
{
    protected override string PageTitle => "Do you want to use your trading name on the register?";

    public AP_OD2_UseTradingNameOnRegisterPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_OD3_ContactDetailsPage SelectYesAndContinueInUseYourTradingNameOnTheRegisterPage()
    {
        SelectRadioOptionByForAttribute("CD-01");
        Continue();
        return new(context);
    }
}
