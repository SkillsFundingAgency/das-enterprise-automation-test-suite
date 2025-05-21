using SFA.DAS.RAA.Service.Project.Helpers;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.RAAProvider.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Helpers
{
    public class ProviderCreateVacancyStepsHelper(ScenarioContext context, bool newTab) : CreateAdvertVacancyBaseStepsHelper()
    {
        private bool _isMultiOrg;

        private string _hashedid = string.Empty;
        private readonly RecruitmentProviderHomePageStepsHelper _recruitmentProviderHomePageStepsHelper = new(context);

        public ProviderCreateVacancyStepsHelper(ScenarioContext context) : this(context, false) { }

        public VacancyReferencePage CreateANewVacancyForSpecificEmployer(string employername, string hashedid)
        {
            _hashedid = hashedid;

            return CreateANewVacancy(employername);
        }

        public VacancyReferencePage CreateANewVacancyForRandomEmployer() => CreateANewVacancy(true);

        public VacancyReferencePage CreateAnonymousVacancy() => CreateANewVacancy(RAAConst.Anonymous);

        public VacancyReferencePage CreateOfflineVacancy() => CreateANewVacancy(false);

        public VacancyReferencePage CreateVacancyForWageType(string wageType) => CreateANewAdvertOrVacancy(string.Empty, "employer", wageType, true, true, true);

        public VacancyReferencePage CreateVacancyForLocationTypes(string locationType, bool enterQuestion1, bool enterQuestion2) => 
            CreateANewAdvertOrVacancy(string.Empty, locationType, RAAConst.NationalMinWages, true, enterQuestion1, enterQuestion2);

        public VacancyReferencePage CreateVacancyForLocationAndWageTypes(string locationType, string wageType) => CreateANewAdvertOrVacancy(string.Empty, locationType, wageType, true, true, true);

        private VacancyReferencePage CreateANewVacancy(string employername) => CreateANewVacancy(employername, true);

        private VacancyReferencePage CreateANewVacancy(bool isApplicationMethodFAA) => CreateANewVacancy(string.Empty, isApplicationMethodFAA);

        private VacancyReferencePage CreateANewVacancy(string employername, bool isApplicationMethodFAA) => CreateANewAdvertOrVacancy(employername, "employer", RAAConst.NationalMinWages, isApplicationMethodFAA, true, true);

        private VacancyReferencePage CreateANewAdvertOrVacancy(string employername, string locationType, string wageType, bool isApplicationMethodFAA, bool enterQuestion1, bool enterQuestion2)
        {
            return CreateANewAdvertOrVacancy(employername, locationType, false, wageType, isApplicationMethodFAA, true, enterQuestion1, enterQuestion2);
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

        protected override CreateAnApprenticeshipAdvertOrVacancyPage Application(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool enterQuestion1, bool enterQuestion2)
        {
            return createAdvertPage
            .EnterAdditionalQuestionsForApplicants()
            .CompleteAllAdditionalQuestionsForApplicants(enterQuestion1, enterQuestion2);
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

        internal RecruitmentHomePage CancelAdvert()
        {
            (CreateAnApprenticeshipAdvertOrVacancy()).AdvertTitle().EnterVacancyTitle().EmployerCancelAdvert();
            return new RecruitmentHomePage(context);
        }

        internal CreateAnApprenticeshipAdvertOrVacancyPage CreateDraftAdvert() => CreateDraftAdvert(CreateAnApprenticeshipAdvertOrVacancy(), false);

        internal CreateAnApprenticeshipAdvertOrVacancyPage CreateDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool createFirstDraftAdvert)
        {

            return EmploymentDetails(createFirstDraftAdvert ? FirstAdvertSummary(createAdvertPage) : AdvertOrVacancySummary(createAdvertPage), "employer", RAAConst.NationalMinWages);
        }

        private static CreateAnApprenticeshipAdvertOrVacancyPage FirstAdvertSummary(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            AdvertSummary(NavigateToAdvertTitle(createAdvertPage).EnterVacancyTitleForTheFirstAdvert().SelectYes());

        private static CreateAnApprenticeshipAdvertOrVacancyPage AdvertSummary(ApprenticeshipTrainingPage page) =>
        page.EnterTrainingTitle()
            .ConfirmTrainingproviderAndContinue()
            .SelectTrainingProvider()
            .ConfirmProviderAndContinueToSummaryPage()
            .EnterShortDescription()
            .EnterShortDescriptionOfWhatApprenticeWillDo()
            .EnterAllDescription();

        internal VacancyReferencePage CloneAnAdvert() => SubmitAndSetVacancyReference(GoToRecruitmentHomePage().SelectLiveVacancy().CloneVacancy()
            .SelectYes().UpdateTitle().UpdateVacancyTitleAndGoToCheckYourAnswersPage().UpdateAdditionalQuestion().UpdateAllAdditionalQuestionsAndGoToCheckYourAnswersPage(true, true));

        protected virtual RecruitmentHomePage GoToRecruitmentHomePage() => _recruitmentProviderHomePageStepsHelper.GoToRecruitmentProviderHomePage(true);
    }
}