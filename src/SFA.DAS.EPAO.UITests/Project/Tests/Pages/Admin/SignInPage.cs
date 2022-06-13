namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class SignInPage : EsfaSignInPage
{
    #region Helpers and Context

    private readonly EPAOAdminUser _user;
    #endregion

    public SignInPage(ScenarioContext context) : base(context) => _user = context.GetUser<EPAOAdminUser>();

    public StaffDashboardPage SignInWithValidDetails()
    {
        SubmitValidLoginDetails(_user.Username, _user.Password);
        return new(context);
    }
}
