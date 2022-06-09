namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.PreamblePages;

public class AP_PR3_SelectOrganisationTypePage : EPAO_BasePage
{
    protected override string PageTitle => "Select organisation type";

    #region Locators
    private static By AwardingOrg => By.CssSelector("#Awarding_Organisations");
    #endregion

    public AP_PR3_SelectOrganisationTypePage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_PR4_ConfirmOrganisationPage SelectTrainingProviderRadioButtonAndContinueInSelectOrgTypePage()
    {
        formCompletionHelper.ClickElement(pageInteractionHelper.FindElement(AwardingOrg));
        Continue();
        return new AP_PR4_ConfirmOrganisationPage(context);
    }
}
