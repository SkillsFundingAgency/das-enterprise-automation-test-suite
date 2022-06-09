namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;

public class AP_OD6_OverallExecutiveMgtPage : EPAO_BasePage
{
    protected override string PageTitle => "Who has responsibility for the overall executive management of your organisation?";

    #region Locators
    private static By FullNameTextbox => By.Id("CD-13");
    private static By PostitionDetailsTextbox => By.Id("CD-14.1");
    #endregion

    public AP_OD6_OverallExecutiveMgtPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_OD7_OfqualRecognitionNumberPage EnterDetailsAndContinueInOEMPage()
    {
        formCompletionHelper.EnterText(FullNameTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomAlphabeticString(20));
        SelectRadioOptionByForAttribute("CD-14");
        formCompletionHelper.EnterText(PostitionDetailsTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomAlphabeticString(50));
        Continue();
        return new AP_OD7_OfqualRecognitionNumberPage(context);
    }
}
