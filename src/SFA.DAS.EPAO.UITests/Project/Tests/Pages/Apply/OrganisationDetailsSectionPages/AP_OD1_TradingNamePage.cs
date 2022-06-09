namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;

public class AP_OD1_TradingNamePage : EPAO_BasePage
{
    protected override string PageTitle => "Does your organisation have a trading name?";

    #region Locators
    private static By TradingNameTextbox => By.Id("CD-30.1");
    #endregion

    public AP_OD1_TradingNamePage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_OD2_UseTradingNameOnRegisterPage GiveATradingNameAndContinueInTradingNamePage()
    {
        SelectRadioOptionByForAttribute("CD-30");
        formCompletionHelper.EnterText(TradingNameTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomAlphabeticString(10));
        Continue();
        return new AP_OD2_UseTradingNameOnRegisterPage(context);
    }
}
