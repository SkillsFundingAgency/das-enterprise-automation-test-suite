namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public class ToolsSignInPage : EsfaSignInPage
{
    public ToolsSignInPage(ScenarioContext context) : base(context) { }

    public ToolSupportHomePage SignIntoToolSupportWithValidDetails(NonEasAccountUser usercreds)
    {
        SubmitValidLoginDetails(usercreds.Username, usercreds.Password);

        return new(context);
    }
}
