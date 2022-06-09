namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_AddEmployerAddress : EPAO_BasePage
{
    protected override string PageTitle => "Add the address that you’d like us to send the certificate to";

    #region Locators
    private static By EmployerNameTextBox => By.Id("Employer");
    private static By AddressLine1TextBox => By.Id("AddressLine1");
    private static By AddressLine2TextBox => By.Id("AddressLine2");
    private static By AddressLine3TextBox => By.Id("AddressLine3");
    private static By TownOrCityTextBox => By.Id("City");
    private static By PostCodeTextBox => By.Id("Postcode");
    private static By SaveContinueButton => By.XPath("(//button[@type='submit'])[3]");
    #endregion

    public AS_AddEmployerAddress(ScenarioContext context) : base(context) => VerifyPage();

    public AS_ConfirmAddressPage EnterEmployerAddressAndContinue()
    {
        EnterAddressAndContinue();
        return new AS_ConfirmAddressPage(context);
    }

    public AS_AddRecipientsDetailsPage EnterEmployerNameAndAddressAndContinue()
    {
        EnterText(EmployerNameTextBox, "Nasdaq");
        EnterAddressAndContinue();
        return new AS_AddRecipientsDetailsPage(context);
    }

    private void EnterAddressAndContinue()
    {
        EnterText(AddressLine1TextBox, EPAODataHelper.AddressLine1);
        EnterText(AddressLine2TextBox, EPAODataHelper.AddressLine2);
        EnterText(AddressLine3TextBox, EPAODataHelper.AddressLine3);
        EnterText(TownOrCityTextBox, EPAODataHelper.TownName);
        EnterText(PostCodeTextBox, EPAODataHelper.PostCode);
        formCompletionHelper.Click(SaveContinueButton);
    }

    private void EnterText(By locator, string text) => formCompletionHelper.EnterText(locator, text);
}