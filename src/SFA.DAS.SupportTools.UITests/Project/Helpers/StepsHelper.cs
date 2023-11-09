
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

namespace SFA.DAS.SupportTools.UITests.Project.Helpers;

public class StepsHelper
{
    private readonly ScenarioContext _context;

    public StepsHelper(ScenarioContext context) => _context = context;

    public ToolSupportHomePage ValidUserLogsinToSupportSCPTools(bool reLogin) => LoginToSupportTools(_context.GetUser<SupportToolScpUser>(), reLogin);

    public ToolSupportHomePage ValidUserLogsinToSupportSCSTools() => LoginToSupportTools(_context.GetUser<SupportToolScsUser>(), false);

    private ToolSupportHomePage LoginToSupportTools(DfeAdminUser loginUser, bool reLogin)
    {
        if (reLogin) ReLoginToDfeSignIn(loginUser);

        else new DfeAdminLoginStepsHelper(_context).LoginToSupportTool(loginUser);

        return new ToolSupportHomePage(_context);
    }

    public void ReLoginToDfeSignIn(DfeAdminUser loginUser)
    {
        _context.Get<TabHelper>().OpenInNewTab(UrlConfig.SupportTools_BaseUrl);

        if (new CheckASEmpSupportToolLandingPage(_context).IsPageDisplayed()) new ASEmpSupportToolLandingPage(_context).ClickStartNowButton();

        if (new CheckDfeSignInPage(_context).IsPageDisplayed()) new DfeSignInPage(_context).SubmitValidLoginDetails(loginUser);
    }
}
