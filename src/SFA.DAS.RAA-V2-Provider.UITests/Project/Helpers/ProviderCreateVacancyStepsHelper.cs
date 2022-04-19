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

        public ProviderCreateVacancyStepsHelper(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        internal void CreateVacancyViaViewAllVacancy(string employername, bool isEmployerAddress, bool disabilityConfidence, bool isApplicationMethodFAA)
        {
            CreateANewAdvertOrVacancy(employername, isEmployerAddress, disabilityConfidence, RAAV2Const.NationalMinWages, isApplicationMethodFAA);
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage Abouttheemployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, string employername, bool isApplicationMethodFAA)
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
            return EnterVacancyTitle(createAdvertPage.AdvertTitle())
                .EnterTrainingTitle()
                .ConfirmTrainingAndContinueToSummaryPage()
                .EnterShortDescription()
                .EnterTasksAndTrainingDetails();
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage CreateAnApprenticeshipAdvertOrVacancy()
        {
            (CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool isMultiOrg) = GoToRecruitmentHomePage(false).GoToViewAllVacancyPage().CreateVacancy().StartNow().SelectEmployer_Provider();

            _isMultiOrg = isMultiOrg;

            return createAdvertPage;
        }

        private ApprenticeshipTrainingPage EnterVacancyTitle(WhatDoYouWantToCallThisAdvertPage advertTitlePage) =>
            _isMultiOrg ? advertTitlePage.EnterAdvertTitleMultiOrg().SelectOrganisationMultiOrg() : advertTitlePage.EnterVacancyTitle();

        private RecruitmentHomePage GoToRecruitmentHomePage(bool newTab)
        {
            new ProviderHomePageStepsHelper(_context).GoToProviderHomePage(newTab);

            return new RecruitmentHomePage(_context, true);
        }
    }
}