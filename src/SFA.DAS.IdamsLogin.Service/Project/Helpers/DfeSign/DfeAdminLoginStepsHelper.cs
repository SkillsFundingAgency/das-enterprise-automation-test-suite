using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages.LandingPage;
using SFA.DAS.Login.Service;
using SFA.DAS.UI.Framework;

namespace SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign;

public class DfeAdminLoginStepsHelper
{
    private readonly ScenarioContext _context;

    public DfeAdminLoginStepsHelper(ScenarioContext context)
    {
        _context = context;
    }

    public void NavigateAndLoginToASAdmin()
    {
        _context.Get<TabHelper>().GoToUrl(UrlConfig.Admin_BaseUrl);

        LoginToASAdmin();
    }

    public void LoginToASAdmin() => SubmitValidLoginDetails(new ApprenticeshipServiceAdminLandingPage(_context), _context.GetUser<EsfaAdminUser>());

    public void LoginToASVacancyQa() => SubmitValidLoginDetails(new ApprenticeshipServiceVacancyQaLandingPage(_context), _context.GetUser<VacancyQaUser>());

    private void SubmitValidLoginDetails(IdamsLoginBasePage landingPage, DfeAdminUser dfeAdminUser)
    {
        landingPage.StartNowAndGoToDfeSignPage();

        new DfeSignInPage(_context).SubmitValidLoginDetails(dfeAdminUser);
    }
}