namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;

public class AP_OD5_UkprnPage : EPAO_BasePage
{
    protected override string PageTitle => "Do you have a UK provider registration number (UKPRN)?";

    #region Locators
    private static By UkprnTextbox => By.Id("CD-12.1");
    #endregion

    public AP_OD5_UkprnPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_OD6_OverallExecutiveMgtPage EnterUkprnAndContinueInDoYouHaveAUkprnPage()
    {
        SelectRadioOptionByForAttribute("CD-12");
        formCompletionHelper.EnterText(UkprnTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomNumber(8));
        Continue();
        return new(context);
    }
}
