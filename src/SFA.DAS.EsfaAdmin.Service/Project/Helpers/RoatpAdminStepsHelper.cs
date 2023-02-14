using SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;
using TechTalk.SpecFlow;

namespace SFA.DAS.EsfaAdmin.Service.Project.Helpers
{
    public abstract class RoatpAdminStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RoatpAdminLoginStepsHelper _loginStepsHelper;

        public RoatpAdminStepsHelper(ScenarioContext context)
        {
            _context = context;
            _loginStepsHelper = new RoatpAdminLoginStepsHelper(context);
        }

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
            _loginStepsHelper.SubmitValidLoginDetails();
            return new RoatpAdminHomePage(_context);
        }
    }
}
