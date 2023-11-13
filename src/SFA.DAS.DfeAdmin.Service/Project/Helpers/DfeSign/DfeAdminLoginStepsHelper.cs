using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;
using SFA.DAS.Login.Service;
using SFA.DAS.UI.Framework;

namespace SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;

public class DfeAdminLoginStepsHelper
{
    private readonly ScenarioContext _context;

    public DfeAdminLoginStepsHelper(ScenarioContext context) => _context = context;

    #region Login
    public void NavigateAndLoginToASAdmin()
    {
        _context.Get<TabHelper>().GoToUrl(UrlConfig.Admin_BaseUrl);

        LoginToAsAdmin();
    }

    public void LoginToAsAssessor1() => SubmitValidAsLoginDetails(_context.GetUser<AsAssessor1User>());

    public void LoginToAsAssessor2() => SubmitValidAsLoginDetails(_context.GetUser<AsAssessor2User>());

    public void LoginToAsAdmin() => SubmitValidAsLoginDetails(GetAsAdminUser());

    public void LoginToSupportConsole(DfeAdminUser dfeAdminUser) => SubmitValidLoginDetails(new ASEmpSupportConsoleLandingPage(_context), dfeAdminUser);

    public void LoginToSupportTool(DfeAdminUser dfeAdminUser) => SubmitValidLoginDetails(new ASEmpSupportToolLandingPage(_context), dfeAdminUser);

    public void SubmitValidAsLoginDetails(ASLandingBasePage landingPage) => SubmitValidLoginDetails(landingPage, GetAsAdminUser());

    #endregion

    #region CheckAndLogin
    public void CheckAndLoginToAsAdmin() => CheckAndLoginTo(new CheckASAdminLandingPage(_context), new ASAdminLandingPage(_context), GetAsAdminUser());

    public void CheckAndLoginToSupportTool(DfeAdminUser dfeAdminUser) => CheckAndLoginTo(new CheckASEmpSupportToolLandingPage(_context), new ASEmpSupportToolLandingPage(_context), dfeAdminUser);

    public void CheckAndLoginToASVacancyQa() => CheckAndLoginTo(new CheckASVacancyQaLandingPage(_context), new ASVacancyQaLandingPage(_context), _context.GetUser<VacancyQaUser>());

    #endregion

    private void SubmitValidAsLoginDetails(DfeAdminUser dfeAdminUser) => SubmitValidLoginDetails(new ASAdminLandingPage(_context), dfeAdminUser);

    private void CheckAndLoginTo(CheckASLandingBasePage checkPage, ASLandingBasePage landingPage, DfeAdminUser dfeAdminUser)
    {
        if (checkPage.IsPageDisplayed()) landingPage.ClickStartNowButton();

        if (new CheckDfeSignInPage(_context).IsPageDisplayed()) SubmitValidLoginDetails(dfeAdminUser);
    }

    private void SubmitValidLoginDetails(ASLandingBasePage landingPage, DfeAdminUser dfeAdminUser)
    {
        landingPage.ClickStartNowButton();

        SubmitValidLoginDetails(dfeAdminUser);
    }

    private void SubmitValidLoginDetails(DfeAdminUser dfeAdminUser) => new DfeSignInPage(_context).SubmitValidLoginDetails(dfeAdminUser);

    private AsAdminUser GetAsAdminUser() => _context.GetUser<AsAdminUser>();
}