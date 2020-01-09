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

        internal void ApplicantSucessful() => _stepsHelper.ApplicantSucessful(SearchVacancy());

        internal void ApplicantUnSucessful() => _stepsHelper.ApplicantUnSucessful(SearchVacancy());

        internal void CreateANewVacancy(string employername, bool isEmployerAddress, bool disabilityConfidence, bool isApplicationMethodFAA, bool optionalFields = false)
        {
            var employernamePage = SelectOrganisation();

            var previewVacancy = _stepsHelper.PreviewVacancy(employernamePage, employername, isEmployerAddress, disabilityConfidence);

            _stepsHelper.SubmitVacancy(previewVacancy, isApplicationMethodFAA, optionalFields);
        }

        private EmployerNamePage SelectOrganisation()
        {
            _providerHomePageStepsHelper.GoToProviderHomePage();

            return new RecruitmentHomePage(_context, true)
                .CreateVacancy()
                .SelectEmployer()
                .EnterVacancyTitle()
                .EnterTrainingTitle()
                .ConfirmAndNavigateToNoOfPositionsPage()
                .ChooseNoOfPositionsAndNavigateToEmployerNamePage();
        }

        private ManageVacancyPage SearchVacancy()
        {
            _providerHomePageStepsHelper.GoToProviderHomePageInNewTab();

            return new RecruitmentHomePage(_context, true)
                .SearchAnyVacancy();
        }

    }
}
