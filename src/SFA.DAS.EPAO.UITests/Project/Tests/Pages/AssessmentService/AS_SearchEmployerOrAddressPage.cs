namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_SearchEmployerOrAddressPage : EPAOAssesment_BasePage
{
    protected override string PageTitle => "Search for an employer or address";
    protected override By PageHeader => By.CssSelector(".js-search-address-heading");

    #region Locators
    private static By EnterAddressManuallyLink => By.Id("enterAddressManually");
    #endregion

    public AS_SearchEmployerOrAddressPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_AddEmployerAddress ClickEnterAddressManuallyLinkInSearchEmployerPage()
    {
        formCompletionHelper.Click(EnterAddressManuallyLink);
        return new(context);
    }
}
