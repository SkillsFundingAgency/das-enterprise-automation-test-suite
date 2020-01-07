using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers
{
    public class ProviderStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;
        private readonly StepsHelper _stepsHelper;

        public ProviderStepsHelper(ScenarioContext context)
        {
            _context = context;
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
            _stepsHelper = new StepsHelper(_context);
        }

        internal void CreateANewVacancy()
        {
            var employernamePage = SelectOrganisation();

            var previewVacancy = _stepsHelper.PreviewVacancy(employernamePage, string.Empty, true, false);

            _stepsHelper.SubmitVacancy(previewVacancy, true, false);
        }

        private EmployerNamePage SelectOrganisation()
        {
            _providerHomePageStepsHelper.GoToProviderHomePage();

            return new RecruitmentProviderHomePage(_context)
                .RecruitApprentices()
                .CreateVacancy()
                .SelectEmployer()
                .EnterVacancyTitle()
                .EnterTrainingTitle()
                .ConfirmAndNavigateToNoOfPositionsPage()
                .ChooseNoOfPositions()
                .SelectOrganisation();
        }
    }
}
