using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign;

namespace SFA.DAS.RoatpAdmin.Service.Project.Helpers;

public abstract class RoatpAdminStepsHelper(ScenarioContext context)
{
    protected readonly ScenarioContext context = context;

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
        new DfeAdminLoginStepsHelper(context).NavigateAndLoginToASAdmin();

        return new RoatpAdminHomePage(context);
    }
}
