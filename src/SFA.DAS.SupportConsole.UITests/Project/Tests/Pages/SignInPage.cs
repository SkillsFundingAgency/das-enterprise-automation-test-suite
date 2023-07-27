namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class SignInPage : EsfaSignInPage
{
    public SignInPage(ScenarioContext context) : base(context) { }

    public SearchHomePage SignInWithValidDetails(NonEasAccountUser usercreds)
    {
        SubmitValidLoginDetails(usercreds.Username, usercreds.Password);

        return new (context);
    }

}
