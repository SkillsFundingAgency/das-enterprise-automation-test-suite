using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;

namespace SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign;

public class DfeEsfaAdminLoginStepsHelper
{
    private readonly ScenarioContext _context;

    public DfeEsfaAdminLoginStepsHelper(ScenarioContext context)
    {
        _context = context;
    }

    public void SubmitValidLoginDetails(DfeAdminUser dfeAdminUser)
    {
        new EsfaAdminServiceStartPage(_context).StartNowAndGoToDfeSignPage();

        new DfeSignInPage(_context).SubmitValidLoginDetails(dfeAdminUser);
    }
}