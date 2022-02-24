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

        public VacancyReferencePage CreateANewVacancy(string employername, bool isEmployerAddress, bool disabilityConfidence, bool isApplicationMethodFAA, bool optionalFields = false, bool newTab = false)
        {
            var employernamePage = SelectOrganisation(newTab, employername);

            return PreviewVacancy(employernamePage, employername, isEmployerAddress, disabilityConfidence, isApplicationMethodFAA, optionalFields);
        }

        public ProviderVacancySearchResultPage SearchVacancy() => GoToRecruitmentHomePage(true).SearchVacancy();

        internal void ViewReferVacancy() => GoToRecruitmentHomePage(true).SearchReferVacancy();

        internal void ApplicantSucessful() => _stepsHelper.ApplicantSucessful(SearchVacancyByVacancyReference());

        internal void ApplicantUnsucessful() => _stepsHelper.ApplicantUnsucessful(SearchVacancyByVacancyReference());

        internal void VerifyWageType(string wageType) => _stepsHelper.VerifyWageType(SearchVacancyByVacancyReference(), wageType);

        internal void CreateANewVacancy(string wageType)
        {
            var employernamePage = SelectOrganisation(false, string.Empty);

            var locationPage = _stepsHelper.ChooseEmployerName(employernamePage, string.Empty);

            var previewPage = _stepsHelper.PreviewVacancy(locationPage, wageType);

            _stepsHelper.SubmitVacancy(previewPage, true, false);
        }

        internal VacancyReferencePage CreateVacancyViaViewAllVacancy(string employername, bool isEmployerAddress, bool disabilityConfidence, bool isApplicationMethodFAA, bool optionalFields = false)
        {
            var employernamePage = SelectOrganisation(CreateVacancyViaViewAllVacancy(), employername);

            return PreviewVacancy(employernamePage, employername, isEmployerAddress, disabilityConfidence, isApplicationMethodFAA, optionalFields);
        }

        private VacancyReferencePage PreviewVacancy(EmployerNamePage employernamePage, string employername, bool isEmployerAddress, bool disabilityConfidence, bool isApplicationMethodFAA, bool optionalFields = false)
        {
            var previewVacancy = _stepsHelper.PreviewVacancy(employernamePage, employername, isEmployerAddress, disabilityConfidence);

            return _stepsHelper.SubmitVacancy(previewVacancy, isApplicationMethodFAA, optionalFields);
        }

        private SelectEmployersPage CreateVacancy(bool newTab) => GoToRecruitmentHomePage(newTab).CreateVacancy();

        private SelectEmployersPage CreateVacancyViaViewAllVacancy() => GoToRecruitmentHomePage(false).GoToViewAllVacancyPage().CreateVacancy();
        public APIListPage NavigateToAPIListPage() => GoToRecruitmentHomePage(false).NavigateToRecruitmentAPIs().ClickAPIKeysHereLink();
        public KeyforAPIPage RenewRecruitmentAPIKey() => NavigateToAPIListPage().ClickViewRecruitmentAPILink().ClickDoYouNeedANewKeyDropDown().ClickRenewKeyLink().SelectYesToRenewAPIKey().ClickContinueToRenewKey();
        public KeyforAPIPage RenewRecruitmentAPISandboxKey() => NavigateToAPIListPage().ClickViewRecruitmentAPISandBoxLink().ClickDoYouNeedANewKeyDropDown().ClickRenewKeyLink().SelectYesToRenewAPIKey().ClickContinueToRenewKey();
        public KeyforAPIPage RenewDisplayAPIKey() => NavigateToAPIListPage().ClickViewDisplayAPILink().ClickDoYouNeedANewKeyDropDown().ClickRenewKeyLink().SelectYesToRenewAPIKey().ClickContinueToRenewKey();

        private EmployerNamePage SelectOrganisation(bool newTab, string empName) => SelectOrganisation(CreateVacancy(newTab), empName);

        private EmployerNamePage SelectOrganisation(SelectEmployersPage selectEmployers, string empName)
        {
            selectEmployers
                .SelectEmployer(empName)
                .EnterVacancyTitle()
                .EnterTrainingTitle()
                .ConfirmAndNavigateToNoOfPositionsPage()
                .EnterNumberOfPositionsAndContinue();

            return new EmployerNamePage(_context);
        }

        private ManageRecruitPage SearchVacancyByVacancyReference() => GoToRecruitmentHomePage(true).SearchVacancyByVacancyReference();

        private RecruitmentHomePage GoToRecruitmentHomePage(bool newTab)
        {
            _providerHomePageStepsHelper.GoToProviderHomePage(newTab);

            return new RecruitmentHomePage(_context, true);
        }
    }
}
