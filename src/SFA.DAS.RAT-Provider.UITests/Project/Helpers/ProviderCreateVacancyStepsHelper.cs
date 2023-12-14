using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAT_Provider.UITests.Project.Helpers
{
    public class ProviderTraineeshipCreateVacancyStepsHelper(ScenarioContext context, bool newTab) : CreateAdvertVacancyBaseStepsHelper()
    {
        private bool _isMultiOrg;

        private readonly string _hashedid = string.Empty;

        public ProviderTraineeshipCreateVacancyStepsHelper(ScenarioContext context) : this(context, false) { }

        public VacancyReferencePage CreateANewTraineeshipVacancy() => CreateANewTraineeshipVacancy(string.Empty, false);

        public VacancyReferencePage CreateOfflineVacancy() => CreateANewVacancy(false);

        private VacancyReferencePage CreateANewVacancy(bool isApplicationMethodFAA) => CreateANewVacancy(string.Empty, isApplicationMethodFAA);

        private VacancyReferencePage CreateANewVacancy(string employername, bool isApplicationMethodFAA) => CreateANewAdvertOrVacancy(employername, true, RAAV2Const.NationalMinWages, isApplicationMethodFAA);

        private VacancyReferencePage CreateANewAdvertOrVacancy(string employername, bool isEmployerAddress, string wageType, bool isApplicationMethodFAA)
        {
            return CreateANewAdvertOrVacancy(employername, isEmployerAddress, false, wageType, isApplicationMethodFAA, true);
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage Application(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            createAdvertPage;
        private VacancyReferencePage CreateANewTraineeshipVacancy(string employername, bool isEmployerAddress)
        {
            CreateANewTraineeshipVacancy(employername, isEmployerAddress, false);

            return new VacancyReferencePage(context);
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage AboutTheEmployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, string employername, bool disabilityConfidence, bool isApplicationMethodFAA)
        {
            return createAdvertPage
                .EmployerName()
                .ChooseEmployerNameForEmployerJourney(employername)
                .EnterEmployerDescriptionAndGoToContactDetailsPage(disabilityConfidence, optionalFields)
                .EnterProviderContactDetailsTraineeship(optionalFields)
                .BackToTaskList();
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage AboutTheEmployerTraineeship(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, string employername)
        {
            return createAdvertPage
                .EmployerName()
                .ChooseEmployerNameForEmployerJourney(employername)
                .EnterEmployerDescriptionAndGoToContactDetailsPage(optionalFields)
                .EnterProviderContactDetailsTraineeship(optionalFields)
                .BackToTaskList();
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage CreateNewTraineeshipVacancy()
        {
            (CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool isMultiOrg) =
                new RecruitmentTraineeshipsProviderHomePageStepsHelper(context)
                    .GoToTraineeshipRecruitmentProviderHomePage(newTab)
                    .GoToViewAllVacancyPage()
                    .CreateVacancy()
                    .StartNow()
                    .SelectEmployer(_hashedid);

            _isMultiOrg = isMultiOrg;

            return createAdvertPage;
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage SkillsAndQualifications(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            createAdvertPage
            .Skills()
            .SelectSkillsAndGoToFutureProspectsPage()
            .EnterFutureProspect()
            .EnterThingsToConsiderAndReturnToCreateAdvert(optionalFields);

        protected override CreateAnApprenticeshipAdvertOrVacancyPage EmploymentDetails(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool isEmployerAddress, string wageType)
        {
            return createAdvertPage
                .ImportantDates()
                .EnterTraineeshipDates()
                .EnterWorkExperience()
                .EnterTraineeshipDuration()
                .SubmitNoOfPositionsAndNavigateToChooseLocationPage()
                .ChooseAddressAndGoToCreateApprenticeshipPage(isEmployerAddress);
        }


        protected override CreateAnApprenticeshipAdvertOrVacancyPage AdvertOrVacancySummary(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage)
        {
            return EnterVacancyTitle(NavigateToAdvertTitle(createAdvertPage))
                .EnterTrainingTitle()
                .EnterShortDescription()
                .EnterTraineeshipTrainingDetails();
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage CreateAnApprenticeshipAdvertOrVacancy()
        {
            (CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool isMultiOrg) =
                new RecruitmentTraineeshipsProviderHomePageStepsHelper(context)
                .GoToTraineeshipRecruitmentProviderHomePage(newTab)
                .GoToViewAllVacancyPage()
                .CreateVacancy()
                .StartNow()
                .SelectEmployer(_hashedid);

            _isMultiOrg = isMultiOrg;

            return createAdvertPage;
        }

        private TraineeshipSectorPage EnterVacancyTitle(WhatDoYouWantToCallThisAdvertPage advertTitlePage) =>
            _isMultiOrg ? advertTitlePage.EnterAdvertTitleMultiOrg().SelectOrganisationMultiOrgTraineeship() : advertTitlePage.EnterTraineeshipVacancyTitle();
    }
}
