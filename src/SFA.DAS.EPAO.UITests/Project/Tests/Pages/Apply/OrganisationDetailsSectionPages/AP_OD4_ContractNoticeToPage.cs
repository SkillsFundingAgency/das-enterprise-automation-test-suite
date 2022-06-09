namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Apply.OrganisationDetailsSectionPages;

public class AP_OD4_ContractNoticeToPage : EPAO_BasePage
{
    protected override string PageTitle => "Who should we send the contract notice to?";

    #region Locators
    private static By GivenNameTextbox => By.Id("CD-07");
    private static By FamilyNameTextbox => By.Id("CD-07_1");
    private static By EnterTheAddressManuallyLink => By.Id("enterAddressManually");
    private static By AddressLine1Textbox => By.Id("CD-08_Key_AddressLine1");
    private static By TownOrCityTextbox => By.Id("CD-08_Key_AddressLine3");
    private static By CountyTextbox => By.Id("CD-08_Key_AddressLine4");
    private static By PostCodeTextbox => By.Id("CD-08_Key_Postcode");
    private static By EmailAddressTextbox => By.Id("CD-10");
    private static By TelephoneTextbox => By.Id("CD-11");
    #endregion

    public AP_OD4_ContractNoticeToPage(ScenarioContext context) : base(context) => VerifyPage();

    public AP_OD5_UkprnPage EnterContactDetailsAndContinueInContractNoticeToPage()
    {
        formCompletionHelper.EnterText(GivenNameTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomAlphabeticString(10));
        formCompletionHelper.EnterText(FamilyNameTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomAlphabeticString(10));
        formCompletionHelper.Click(EnterTheAddressManuallyLink);
        formCompletionHelper.EnterText(AddressLine1Textbox, Helpers.DataHelpers.EPAODataHelper.GetRandomNumber(3));
        formCompletionHelper.EnterText(TownOrCityTextbox, Helpers.DataHelpers.EPAODataHelper.TownName);
        formCompletionHelper.EnterText(CountyTextbox, Helpers.DataHelpers.EPAODataHelper.CountyName);
        formCompletionHelper.EnterText(PostCodeTextbox, Helpers.DataHelpers.EPAODataHelper.PostCode);
        formCompletionHelper.EnterText(EmailAddressTextbox, ePAOApplyDataHelper.RandomEmail);
        formCompletionHelper.EnterText(TelephoneTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomNumber(10));
        Continue();
        return new AP_OD5_UkprnPage(context);
    }
}
