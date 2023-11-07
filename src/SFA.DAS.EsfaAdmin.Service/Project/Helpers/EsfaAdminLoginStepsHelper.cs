using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages.LandingPage;

namespace SFA.DAS.EsfaAdmin.Service.Project.Helpers;

public class EsfaAdminLoginStepsHelper
{
    private readonly ScenarioContext _context;

    public EsfaAdminLoginStepsHelper(ScenarioContext context) => _context = context;

    public void SubmitValidLoginDetails(string username, string password)
    {
        new ApprenticeshipServiceAdminLandingPage(_context).StartNow().LoginToAccess1Staff();

        new EsfaSignInPage(_context).SubmitValidLoginDetails(username, password);

        _context.Get<ObjectContext>().SetEsfaAdminLoginCreds((username, password));
    }
}
