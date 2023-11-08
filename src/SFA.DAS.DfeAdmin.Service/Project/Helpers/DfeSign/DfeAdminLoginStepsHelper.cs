using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.LandingPage;
using SFA.DAS.Login.Service;
using SFA.DAS.UI.Framework;

namespace SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;

public class DfeAdminLoginStepsHelper
{
    private readonly ScenarioContext _context;

    private readonly AsAdminUser _asAdminUser;

    public DfeAdminLoginStepsHelper(ScenarioContext context)
    {
        _context = context;

        _asAdminUser = context.GetUser<AsAdminUser>();
    }

    public void NavigateAndLoginToASAdmin()
    {
        _context.Get<TabHelper>().GoToUrl(UrlConfig.Admin_BaseUrl);

        LoginToAsAdmin();
    }

    public void LoginToAsAssessor1() => SubmitValidAsLoginDetails(_context.GetUser<AsAssessor1User>());

    public void LoginToAsAssessor2() => SubmitValidAsLoginDetails(_context.GetUser<AsAssessor2User>());

    public void LoginToAsAdmin() => SubmitValidAsLoginDetails(_asAdminUser);

    public void SubmitValidAsLoginDetails(ASLandingBasePage landingPage) => SubmitValidLoginDetails(landingPage, _asAdminUser);

    public void LoginToASVacancyQa() => SubmitValidLoginDetails(new ASVacancyQaLandingPage(_context), _context.GetUser<VacancyQaUser>());

    private void SubmitValidAsLoginDetails(DfeAdminUser dfeAdminUser) => SubmitValidLoginDetails(new ASAdminLandingPage(_context), dfeAdminUser);

    private void SubmitValidLoginDetails(ASLandingBasePage landingPage, DfeAdminUser dfeAdminUser)
    {
        landingPage.StartNowAndGoToDfeSignPage();

        new DfeSignInPage(_context).SubmitValidLoginDetails(dfeAdminUser);
    }
}