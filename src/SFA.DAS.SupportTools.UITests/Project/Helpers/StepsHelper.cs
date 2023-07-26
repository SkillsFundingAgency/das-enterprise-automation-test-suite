namespace SFA.DAS.SupportTools.UITests.Project.Helpers;

public class StepsHelper
{
    private readonly ScenarioContext _context;

    public StepsHelper(ScenarioContext context) => _context = context;

    public ToolSupportHomePage ValidUserLogsinToSupportSCPTools(bool reLogin) => LoginToSupportTools(_context.GetUser<SupportToolsSCPUser>(), reLogin);

    public ToolSupportHomePage ValidUserLogsinToSupportSCSTools(bool reLogin) => LoginToSupportTools(_context.GetUser<SupportToolsSCSUser>(), reLogin);

    private ToolSupportHomePage LoginToSupportTools(NonEasAccountUser loginUser, bool reLogin)
    {
        if (new LoginToAccess1StaffHelper(_context).LoginToAccess1Staff(UrlConfig.SupportTools_BaseUrl, reLogin)) new ToolsSignInPage(_context).SignIntoToolSupportWithValidDetails(loginUser);

        return new ToolSupportHomePage(_context);
    }
}
