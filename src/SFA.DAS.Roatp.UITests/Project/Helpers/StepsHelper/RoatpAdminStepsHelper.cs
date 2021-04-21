using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Helpers.StepsHelper
{
    public abstract class RoatpAdminStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RoatpAdminLoginStepsHelper _loginStepsHelper;

        public RoatpAdminStepsHelper(ScenarioContext context)
        {
            _context = context;
            _loginStepsHelper = new RoatpAdminLoginStepsHelper(_context);
        }

        public RoatpAdminHomePage InitatesAnApplication(string providerType)
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

        public abstract RoatpAdminHomePage GoToRoatpAdminHomePage();

        public RoatpAdminHomePage GoToRoatpAdminHomePage(ResultsFoundPage resultsFoundPage) => resultsFoundPage.GetRoatpAdminHomePage();

        protected void SubmitValidLoginDetails() => _loginStepsHelper.SubmitValidLoginDetails();

    }
}
