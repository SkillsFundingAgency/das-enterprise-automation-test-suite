namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_CreateAnAccountPage : EPAO_BasePage
{
    protected override string PageTitle => "Create an account";

    #region Locators
    private static By GivenNameTextbox => By.Id("GivenName");
    private static By FamilyNameTextbox => By.Id("FamilyName");
    private static By EmailAddressTextbox => By.Id("Email");
    #endregion

    public AS_CreateAnAccountPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_ConfirmYourIdentityPage EnterAccountDetailsAndClickCreateAccount()
    {
        formCompletionHelper.EnterText(GivenNameTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomAlphabeticString(5));
        formCompletionHelper.EnterText(FamilyNameTextbox, Helpers.DataHelpers.EPAODataHelper.GetRandomAlphabeticString(10));
        formCompletionHelper.EnterText(EmailAddressTextbox, ePAOAssesmentServiceDataHelper.RandomEmail);
        Continue();
        return new(context);
    }
}
