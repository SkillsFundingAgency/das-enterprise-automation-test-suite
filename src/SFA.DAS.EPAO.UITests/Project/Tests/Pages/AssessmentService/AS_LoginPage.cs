namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;

public class AS_LoginPage : EPAO_BasePage
{
    protected override string PageTitle => "Sign in to Apprenticeship assessment service";

    #region Locators
    private static By EmailAddressTextBox => By.Id("Username");
    private static By PasswordTextBox => By.Id("Password");
    #endregion

    public AS_LoginPage(ScenarioContext context) : base(context) => VerifyPage();

    public AS_LoggedInHomePage SignInWithValidDetails(LoginUser loginUser)
    {
        EnterLoginDetails(loginUser);
        return new(context);
    }

    public AP_PR1_SearchForYourOrganisationPage SignInAsApplyUser(LoginUser loginUser)
    {
        EnterLoginDetails(loginUser);
        return new(context);
    }

    private void EnterLoginDetails(LoginUser loginUser)
    {
        var username = loginUser.Username;
        formCompletionHelper.EnterText(EmailAddressTextBox, username);
        formCompletionHelper.EnterText(PasswordTextBox, loginUser.Password);
        Continue();
        ePAOAdminDataHelper.LoginEmailAddress = username;
        objectContext.SetLoggedInUser(username);
    }
}
