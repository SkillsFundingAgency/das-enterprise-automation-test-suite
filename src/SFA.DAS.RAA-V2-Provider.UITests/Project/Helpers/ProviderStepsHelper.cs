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

        internal void ViewReferVacancy() => GoToRecruitmentHomePage(true).SearchReferVacancy();

        internal void ApplicantSucessful() => _stepsHelper.ApplicantSucessful(SearchVacancyByVacancyReference());

        internal void ApplicantUnsucessful() => _stepsHelper.ApplicantUnsucessful(SearchVacancyByVacancyReference());

        internal void VerifyWageType(string wageType) => _stepsHelper.VerifyWageType(SearchVacancyByVacancyReference(), wageType);

        internal void CreateANewVacancy(string wageType)
        {
            var employernamePage = SelectOrganisation();

            var locationPage = _stepsHelper.ChooseEmployerName(employernamePage, string.Empty);

            var previewPage = _stepsHelper.PreviewVacancy(locationPage, wageType);

            _stepsHelper.SubmitVacancy(previewPage, true, false);
        }

        internal void CreateANewVacancy(string employername, bool isEmployerAddress, bool disabilityConfidence, bool isApplicationMethodFAA, bool optionalFields = false)
        {
            var employernamePage = SelectOrganisation();

            var previewVacancy = _stepsHelper.PreviewVacancy(employernamePage, employername, isEmployerAddress, disabilityConfidence);

            _stepsHelper.SubmitVacancy(previewVacancy, isApplicationMethodFAA, optionalFields);
        }

        private EmployerNamePage SelectOrganisation()
        {
            return GoToRecruitmentHomePage(false)
                .CreateVacancy()
                .SelectEmployer()
                .EnterVacancyTitle()
                .EnterTrainingTitle()
                .ConfirmAndNavigateToNoOfPositionsPage()
                .SubmitNoOfPositionsAndNavigateToEmployerNamePage();
        }

        private ManageVacancyPage SearchVacancyByVacancyReference() => GoToRecruitmentHomePage(true).SearchVacancyByVacancyReference();

        private RecruitmentHomePage GoToRecruitmentHomePage(bool newTab)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(newTab);

            return new RecruitmentHomePage(_context, true);
        }
    }
}
