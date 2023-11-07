using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign;

namespace SFA.DAS.EsfaAdmin.Service.Project.Helpers;

public abstract class EsfaAdminStepsHelper
{
    private readonly ScenarioContext _context;
    
    public EsfaAdminStepsHelper(ScenarioContext context) => _context = context;

    public SearchPage InitatesAnApplication(string providerType)
    {
        return GoToRoatpAdminHomePage()
            .AddANewTrainingProvider()
            .EnterUkprn()
            .ConfirmOrganisationsDetails()
            .SubmitProviderType(providerType)
            .SubmitOrganisationType()
            .EnterDob()
            .ConfirmOrganisationsDetails();
    }

    public RoatpAdminHomePage GoToRoatpAdminHomePage()
    {
        new DfeAdminLoginStepsHelper(_context).NavigateAndLoginToASAdmin();
        return new RoatpAdminHomePage(_context);
    }
}
