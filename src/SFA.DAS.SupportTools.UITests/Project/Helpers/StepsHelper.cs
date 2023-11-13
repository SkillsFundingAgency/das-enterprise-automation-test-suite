
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;

namespace SFA.DAS.SupportTools.UITests.Project.Helpers;

public class StepsHelper
{
    private readonly ScenarioContext _context;

    public StepsHelper(ScenarioContext context) => _context = context;

    public ToolSupportHomePage ValidUserLogsinToSupportSCPTools(bool reLogin) => LoginToSupportTools(_context.GetUser<SupportToolScpUser>(), reLogin);

    public ToolSupportHomePage ValidUserLogsinToSupportSCSTools() => LoginToSupportTools(_context.GetUser<SupportToolScsUser>(), false);

    private ToolSupportHomePage LoginToSupportTools(DfeAdminUser loginUser, bool reLogin)
    {
        LoginToDfeSignIn(loginUser, reLogin);

        return new ToolSupportHomePage(_context);
    }

    public void LoginToDfeSignIn(DfeAdminUser loginUser, bool reLogin)
    {
        var helper = new DfeAdminLoginStepsHelper(_context);

        if (reLogin)
        {
            _context.Get<TabHelper>().OpenInNewTab(UrlConfig.SupportTools_BaseUrl);

            helper.CheckAndLoginToSupportTool(loginUser);
        }
        else
        {
            helper.LoginToSupportTool(loginUser);
        }
    }
}
