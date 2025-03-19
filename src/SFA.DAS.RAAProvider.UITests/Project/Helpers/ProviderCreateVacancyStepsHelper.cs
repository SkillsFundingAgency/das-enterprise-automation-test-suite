using SFA.DAS.RAA.Service.Project.Helpers;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Helpers
{
    public class ProviderCreateVacancyStepsHelper(ScenarioContext context, bool newTab) : CreateAdvertVacancyBaseStepsHelper()
    {
        private bool _isMultiOrg;

        private string _hashedid = string.Empty;

        public ProviderCreateVacancyStepsHelper(ScenarioContext context) : this(context, false) { }

        public VacancyReferencePage CreateANewVacancyForSpecificEmployer(string employername, string hashedid)
        {
            _hashedid = hashedid;

            return CreateANewVacancy(employername);
        }

        public VacancyReferencePage CreateANewVacancyForRandomEmployer() => CreateANewVacancy(true);

        public VacancyReferencePage CreateAnonymousVacancy() => CreateANewVacancy(RAAConst.Anonymous);

        public VacancyReferencePage CreateOfflineVacancy() => CreateANewVacancy(false);

        public VacancyReferencePage CreateVacancyForWageType(string wageType) => CreateANewAdvertOrVacancy(string.Empty, "employer", wageType, true);

        private VacancyReferencePage CreateANewVacancy(string employername) => CreateANewVacancy(employername, true);

        private VacancyReferencePage CreateANewVacancy(bool isApplicationMethodFAA) => CreateANewVacancy(string.Empty, isApplicationMethodFAA);

        private VacancyReferencePage CreateANewVacancy(string employername, bool isApplicationMethodFAA) => CreateANewAdvertOrVacancy(employername, "employer", RAAConst.NationalMinWages, isApplicationMethodFAA);

        private VacancyReferencePage CreateANewAdvertOrVacancy(string employername, string locationType, string wageType, bool isApplicationMethodFAA)
        {
            return CreateANewAdvertOrVacancy(employername, locationType, false, wageType, isApplicationMethodFAA, true);
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage AboutTheEmployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, string employername, bool disabilityConfidence, bool isApplicationMethodFAA)
        {
            return createAdvertPage
                .EmployerName()
                .ChooseEmployerNameForEmployerJourney(employername)
                .EnterEmployerDescriptionAndGoToContactDetailsPage(disabilityConfidence, optionalFields)
                .EnterProviderContactDetails(optionalFields)
                .SelectApplicationMethod_Provider(isApplicationMethodFAA);
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage Application(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage)
        {
            return createAdvertPage
            .EnterAdditionalQuestionsForApplicants()
            .CompleteAllAdditionalQuestionsForApplicants();
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage SkillsAndQualifications(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            createAdvertPage
            .Skills()
            .SelectSkillAndGoToQualificationsPage()
            .SelectYesToAddQualification()
            .EnterQualifications()
            .ConfirmQualificationsAndGoToFutureProspectsPage()
            .EnterFutureProspect()
            .EnterThingsToConsiderAndReturnToCreateAdvert(optionalFields);

        protected override CreateAnApprenticeshipAdvertOrVacancyPage EmploymentDetails(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, string locationType, string wageType)
        {
            return createAdvertPage
                .ImportantDates()
                .EnterImportantDates()
                .EnterDuration()
                .ChooseWage_Provider(wageType)
                .SubmitExtraInformationAboutPay()
                .SubmitNoOfPositionsAndNavigateToChooseLocationPage()
                .ChooseAddressAndGoToCreateApprenticeshipPage(locationType);
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage AdvertOrVacancySummary(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage)
        {
            return EnterVacancyTitle(NavigateToAdvertTitle(createAdvertPage))
                .EnterTrainingTitle()
                .ConfirmTrainingAndContinueToSummaryPage()
                .EnterShortDescription()
                .EnterShortDescriptionOfWhatApprenticeWillDo()
                .EnterAllDescription();
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage CreateAnApprenticeshipAdvertOrVacancy()
        {
            (CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool isMultiOrg) =
                new RecruitmentProviderHomePageStepsHelper(context)
                .GoToRecruitmentProviderHomePage(newTab)
                .GoToViewAllVacancyPage()
                .CreateVacancy()
                .StartNow()
                .SelectEmployer(_hashedid);

            _isMultiOrg = isMultiOrg;

            return createAdvertPage;
        }

        private ApprenticeshipTrainingPage EnterVacancyTitle(WhatDoYouWantToCallThisAdvertPage advertTitlePage) =>
             advertTitlePage.EnterVacancyTitle();
    }
}