using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages.LandingPage;
using SFA.DAS.Login.Service;
using SFA.DAS.UI.Framework;

namespace SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign;

public class DfeAdminLoginStepsHelper
{
    private readonly ScenarioContext _context;

    public DfeAdminLoginStepsHelper(ScenarioContext context) => _context = context;

    public void NavigateAndLoginToASAdmin()
    {
        _context.Get<TabHelper>().GoToUrl(UrlConfig.Admin_BaseUrl);

        LoginToAsAdmin();
    }

    public void LoginToAsAssessor1() => SubmitValidAsLoginDetails(_context.GetUser<AsAssessor1User>());

    public void LoginToAsAssessor2() => SubmitValidAsLoginDetails(_context.GetUser<AsAssessor2User>());

    public void LoginToAsAdmin() => SubmitValidAsLoginDetails(_context.GetUser<AsAdminUser>());

    public void LoginToASVacancyQa() => SubmitValidLoginDetails(new ASVacancyQaLandingPage(_context), _context.GetUser<VacancyQaUser>());

    private void SubmitValidAsLoginDetails(DfeAdminUser dfeAdminUser) => SubmitValidLoginDetails(new ASAdminLandingPage(_context), dfeAdminUser);

    private void SubmitValidLoginDetails(IdamsLoginBasePage landingPage, DfeAdminUser dfeAdminUser)
    {
        landingPage.StartNowAndGoToDfeSignPage();

        new DfeSignInPage(_context).SubmitValidLoginDetails(dfeAdminUser);
    }
}