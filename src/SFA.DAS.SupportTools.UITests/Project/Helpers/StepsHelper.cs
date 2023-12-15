
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;

namespace SFA.DAS.SupportTools.UITests.Project.Helpers;

public class StepsHelper(ScenarioContext context)
{
    public ToolSupportHomePage ValidUserLogsinToSupportSCPTools(bool reLogin) => LoginToSupportTools(context.GetUser<SupportToolScpUser>(), reLogin);

    public ToolSupportHomePage ValidUserLogsinToSupportSCSTools() => LoginToSupportTools(context.GetUser<SupportToolScsUser>(), false);

    private ToolSupportHomePage LoginToSupportTools(DfeAdminUser loginUser, bool reLogin)
    {
        LoginToDfeSignIn(loginUser, reLogin);

        return new ToolSupportHomePage(context);
    }

    public void LoginToDfeSignIn(DfeAdminUser loginUser, bool reLogin)
    {
        var helper = new DfeAdminLoginStepsHelper(context);

        if (reLogin)
        {
            context.Get<TabHelper>().OpenInNewTab(UrlConfig.SupportTools_BaseUrl);

            helper.CheckAndLoginToSupportTool(loginUser);
        }
        else
        {
            helper.LoginToSupportTool(loginUser);
        }
    }
}
