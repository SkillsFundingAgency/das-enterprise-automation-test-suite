using SFA.DAS.ProviderLogin.Service.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Helpers
{
    public class ProviderCreateVacancyStepsHelper : CreateAdvertVacancyBaseStepsHelper
    {
        private readonly ScenarioContext _context;

        private bool _isMultiOrg;

        private string _hashedid;

        private readonly bool _newTab;

        public ProviderCreateVacancyStepsHelper(ScenarioContext context) : this(context, false) { }

        public ProviderCreateVacancyStepsHelper(ScenarioContext context, bool newTab) : base()
        {
            _context = context;
            _newTab = newTab;
            _hashedid = string.Empty;
        }

        public VacancyReferencePage CreateANewVacancyForSpecificEmployer(string employername, string hashedid)
        {
            _hashedid = hashedid; 

            return CreateANewVacancy(employername);
        }

        public VacancyReferencePage CreateANewVacancyForRandomEmployer() => CreateANewVacancy(true);

        public VacancyReferencePage CreateAnonymousVacancy() => CreateANewVacancy(RAAV2Const.Anonymous);

        public VacancyReferencePage CreateOfflineVacancy() => CreateANewVacancy(false);

        public VacancyReferencePage CreateVacancyForWageType(string wageType) => CreateANewAdvertOrVacancy(string.Empty, true, wageType, true);

        private VacancyReferencePage CreateANewVacancy(string employername) => CreateANewVacancy(employername, true);

        private VacancyReferencePage CreateANewVacancy(bool isApplicationMethodFAA) => CreateANewVacancy(string.Empty, isApplicationMethodFAA);

        private VacancyReferencePage CreateANewVacancy(string employername, bool isApplicationMethodFAA) => CreateANewAdvertOrVacancy(employername, true, RAAV2Const.NationalMinWages, isApplicationMethodFAA);

        private VacancyReferencePage CreateANewAdvertOrVacancy(string employername, bool isEmployerAddress, string wageType, bool isApplicationMethodFAA)
        {
            return CreateANewAdvertOrVacancy(employername, isEmployerAddress, false, wageType, isApplicationMethodFAA);
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage AboutTheEmployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, string employername, bool isApplicationMethodFAA)
        {
            return createAdvertPage
                .EmployerName()
                .ChooseEmployerNameForEmployerJourney(employername)
                .EnterEmployerDescriptionAndGoToContactDetailsPage(optionalFields)
                .EnterProviderContactDetails(optionalFields)
                .SelectApplicationMethod_Provider(isApplicationMethodFAA)
                .BackToTaskList();
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage SkillsAndQualifications(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) => 
            createAdvertPage
            .Skills()
            .SelectSkillAndGoToQualificationsPage()
            .EnterQualifications()
            .ConfirmQualificationsAndGoToFutureProspectsPage()
            .EnterFutureProspect()
            .EnterThingsToConsiderAndReturnToCreateAdvert(optionalFields);

        protected override CreateAnApprenticeshipAdvertOrVacancyPage EmploymentDetails(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool isEmployerAddress, bool disabilityConfidence, string wageType)
        {
            return createAdvertPage
                .ImportantDates()
                .EnterImportantDates(false)
                .EnterDuration()
                .ChooseWage(wageType)
                .SubmitNoOfPositionsAndNavigateToChooseLocationPage()
                .ChooseAddressAndGoToCreateApprenticeshipPage(isEmployerAddress);
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage AdvertOrVacancySummary(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage)
        {
            return EnterVacancyTitle(NavigateToAdvertTitle(createAdvertPage))
                .EnterTrainingTitle()
                .ConfirmTrainingAndContinueToSummaryPage()
                .EnterShortDescription()
                .EnterTasksAndTrainingDetails();
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage CreateAnApprenticeshipAdvertOrVacancy()
        {
            (CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool isMultiOrg) = 
                new RecruitmentProviderHomePageStepsHelper(_context)
                .GoToRecruitmentProviderHomePage(_newTab)
                .GoToViewAllVacancyPage()
                .CreateVacancy()
                .StartNow()
                .SelectEmployer(_hashedid);

            _isMultiOrg = isMultiOrg;

            return createAdvertPage;
        }

        private ApprenticeshipTrainingPage EnterVacancyTitle(WhatDoYouWantToCallThisAdvertPage advertTitlePage) =>
            _isMultiOrg ? advertTitlePage.EnterAdvertTitleMultiOrg().SelectOrganisationMultiOrg() : advertTitlePage.EnterVacancyTitle();
    }
}