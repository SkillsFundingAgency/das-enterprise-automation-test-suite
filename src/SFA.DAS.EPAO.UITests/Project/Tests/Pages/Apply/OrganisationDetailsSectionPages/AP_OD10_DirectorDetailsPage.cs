namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;

public class AP_OD10_DirectorDetailsPage : EPAO_BasePage
{
    protected override string PageTitle => "Director details";

    #region Locators
    private static By FullNameTextbox => By.Id("CD-19");
    private static By MonthTextbox => By.Id("CD-20_Month");
    private static By YearTextbox => By.Id("CD-20_Year");
    private static By NumberOfSharesTextbox => By.Id("CD-21");
    private static By SaveAndAddAnotherLink => By.XPath("//button[text()='Save and add another']");
    private static By SaveAndContinueButton => By.XPath("//button[text()='Save and continue']");
    #endregion

    public AP_OD10_DirectorDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_OD11_DirectorsDataPage EnterNumberAndContinueInDirectoDetailsPage()
    {
        formCompletionHelper.EnterText(FullNameTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomAlphabeticString(20));
        formCompletionHelper.EnterText(MonthTextbox, ePAOApplyDataHelper.CurrentMonth);
        formCompletionHelper.EnterText(YearTextbox, ePAOApplyDataHelper.CurrentYear - 30);
        formCompletionHelper.EnterText(NumberOfSharesTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomNumber(3));
        formCompletionHelper.Click(SaveAndAddAnotherLink);
        formCompletionHelper.Click(SaveAndContinueButton);
        return new(context);
    }
}
