
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;

namespace SFA.DAS.SupportTools.UITests.Project.Helpers;

public class StepsHelper
{
    private readonly ScenarioContext _context;

    public StepsHelper(ScenarioContext context) => _context = context;

    public ToolSupportHomePage ValidUserLogsinToSupportSCPTools(bool reLogin) => LoginToSupportTools(_context.GetUser<SupportToolScpUser>(), reLogin);

    public ToolSupportHomePage ValidUserLogsinToSupportSCSTools(bool reLogin) => LoginToSupportTools(_context.GetUser<SupportToolScsUser>(), reLogin);

    private ToolSupportHomePage LoginToSupportTools(DfeAdminUser loginUser, bool reLogin)
    {
        if (LoginToDfeSignIn(reLogin)) new DfeSignInPage(_context).SubmitValidLoginDetails(loginUser);

        return new ToolSupportHomePage(_context);
    }

    public bool LoginToDfeSignIn(bool reLogin)
    {
        if (reLogin) _context.Get<TabHelper>().OpenInNewTab(UrlConfig.SupportTools_BaseUrl);

        if (new CheckASEmpSupportToolLandingPage(_context).IsPageDisplayed()) new ASEmpSupportToolLandingPage(_context).ClickStartNowButton();

        return new CheckDfeSignInPage(_context).IsPageDisplayed();
    }
}
