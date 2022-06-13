namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;

public class AS_ChangeEmailPage : EPAO_BasePage
{
    protected override string PageTitle => "Change email address";

    #region Locators
    private static By EmailTextBox => By.Id("Email");
    #endregion

    public AS_ChangeEmailPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_ConfirmEmailAddressPage EnterRandomEmailAndClickChange()
    {
        formCompletionHelper.EnterText(EmailTextBox, ePAOAssesmentServiceDataHelper.RandomEmail);
        Continue();
        return new(context);
    }
}

public class AS_ConfirmEmailAddressPage : EPAO_BasePage
{
    protected override string PageTitle => "Confirm email address";

    public AS_ConfirmEmailAddressPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_EmailAddressUpdatedPage ClickConfirmButtonInConfirmEmailAddressPage()
    {
        Continue();
        return new(context);
    }
}

public class AS_EmailAddressUpdatedPage : AS_ChangeOrgDetailsBasePage
{
    protected override string PageTitle => "Email address updated";

    public AS_EmailAddressUpdatedPage(ScenarioContext context) : base(context) => VerifyPage();
}