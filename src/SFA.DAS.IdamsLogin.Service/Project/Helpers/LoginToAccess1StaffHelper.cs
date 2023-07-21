using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.IdamsLogin.Service.Project.Helpers;

public class LoginToAccess1StaffHelper
{
    private readonly ScenarioContext _context;

    public LoginToAccess1StaffHelper(ScenarioContext context) => _context = context;

    public bool LoginToAccess1Staff(string url, bool reLogin)
    {
        if (reLogin) _context.Get<TabHelper>().OpenInNewTab(url);

        return LoginToAccess1Staff();
    }

    public bool LoginToAccess1Staff()
    {
        var startNowPage = new CheckStartNowButtonPage(_context);

        if (startNowPage.IsPageDisplayed()) startNowPage.ClickStartNowButton();

        if (new CheckPreProdDIGBEADFSPage(_context).IsPageDisplayed()) { new PreProdDIGBEADFSPage(_context).LoginToAccess1Staff(); return true; }

        return false;
    }

}
