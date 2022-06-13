namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;

public class AP_OrganisationDetailsBasePage : EPAOApply_BasePage
{
    protected override string PageTitle => "Organisation details";

    #region Locators
    private static By TradingNameLink => By.LinkText("Trading name");
    #endregion

    public AP_OrganisationDetailsBasePage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_OD1_TradingNamePage ClickTradingNameLinkInOrganisationDetailsBasePage()
    {
        formCompletionHelper.Click(TradingNameLink);
        return new(context);
    }
}
