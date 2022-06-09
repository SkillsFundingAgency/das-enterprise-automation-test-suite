namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;

public class AP_OD7_OfqualRecognitionNumberPage : EPAO_BasePage
{
    protected override string PageTitle => "Do you have an Ofqual recognition number?";

    #region Locators
    private static By OfqualRecognitionNumberTextbox => By.Id("CD-15.1");
    #endregion

    public AP_OD7_OfqualRecognitionNumberPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_OD8_TradingStatusPage EnterDetailsAndContinueInOfqualRecognitionNumberPage()
    {
        SelectRadioOptionByForAttribute("CD-15");
        formCompletionHelper.EnterText(OfqualRecognitionNumberTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomNumber(6));
        Continue();
        return new(context);
    }
}
