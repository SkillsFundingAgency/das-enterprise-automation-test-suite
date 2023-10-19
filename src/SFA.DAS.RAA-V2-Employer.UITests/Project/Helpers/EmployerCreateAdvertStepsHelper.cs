using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;
using DoYouNeedToCreateAnAdvertPage = SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.DynamicHomePageEmployer.DoYouNeedToCreateAnAdvertPage;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers
{
    public class EmployerCreateDraftAdvertStepsHelper : EmployerCreateAdvertStepsHelper
    {
        public EmployerCreateDraftAdvertStepsHelper(ScenarioContext context) : base(context)
        {

        }

        internal VacancyReferencePage SubmitDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) => 
            CheckAndSubmitAdvert(CompleteAboutTheEmployer(createAdvertPage).EnterAdditionalQuestionsForApplicants().CompleteAllAdditionalQuestionsForApplicants());

        internal CreateAnApprenticeshipAdvertOrVacancyPage CompleteDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) => 
            CompleteAboutTheEmployer(createAdvertPage).EnterAdditionalQuestionsForApplicants().CompleteAllAdditionalQuestionsForApplicants().CheckYourAnswers().PreviewAdvert().DeleteVacancy().NoDeleteVacancy();

        internal EmployerVacancySearchResultPage CompleteDeleteOfDraftVacancy() => new CreateAnApprenticeshipAdvertOrVacancyPage(context).CheckYourAnswers().PreviewAdvert().DeleteVacancy().YesDeleteVacancy();

        internal CreateAnApprenticeshipAdvertOrVacancyPage CreateDraftAdvert() => CreateDraftAdvert(CreateAnApprenticeshipAdvertOrVacancy(), false);

        internal YourApprenticeshipAdvertsHomePage CancelAdvert() { EnterAdvertTitleMultiOrg(CreateAnApprenticeshipAdvertOrVacancy()).EmployerCancelAdvert(); return new YourApprenticeshipAdvertsHomePage(context); }
    }

    public class EmployerCreateAdvertPrefStepsHelper : EmployerCreateAdvertStepsHelper
    {
        private readonly RAAV2EmployerUser rAAV2Employer;

        public EmployerCreateAdvertPrefStepsHelper(ScenarioContext context, RAAV2EmployerUser rAAV2EmployerUser) : base(context)
        {
            rAAV2Employer = rAAV2EmployerUser;
        }

        protected override YourApprenticeshipAdvertsHomePage GoToRecruitmentHomePage() => rAAV2EmployerLoginHelper.GoToRecruitmentHomePage(rAAV2Employer);

        public CreateAnApprenticeshipAdvertOrVacancyPage GoToCreateAnApprenticeshipAdvertPage()
        {
            return rAAV2EmployerLoginHelper.GoToCreateAnAdvertHomePage(rAAV2Employer).GoToCreateAnApprenticeshipAdvertPage();
        }

        protected override ApprenticeshipTrainingPage EnterAdvertTitle(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            NavigateToAdvertTitle(createAdvertPage).EnterVacancyTitle();
    }

    public class EmployerCreateAdvertStepsHelper : CreateAdvertVacancyBaseStepsHelper
    {
        protected readonly ScenarioContext context;

        protected readonly RAAV2EmployerLoginStepsHelper rAAV2EmployerLoginHelper;

        public EmployerCreateAdvertStepsHelper(ScenarioContext context) : base()
        {
            this.context = context;

            rAAV2EmployerLoginHelper = new RAAV2EmployerLoginStepsHelper(context);
        }

        internal CreateAnApprenticeshipAdvertOrVacancyPage CreateFirstDraftAdvert_PrefTest(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage)
        {
            return FirstAdvertSummary(createAdvertPage);
        }

        internal CreateAnApprenticeshipAdvertOrVacancyPage CreateFirstDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage)
        {
            return CreateDraftAdvert(createAdvertPage, true);
        }

        internal CreateAnApprenticeshipAdvertOrVacancyPage CreateDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool createFirstDraftAdvert)
        {
            
            return EmploymentDetails(createFirstDraftAdvert ? FirstAdvertSummary(createAdvertPage) : AdvertOrVacancySummary(createAdvertPage), true, RAAV2Const.NationalMinWages);
        }

        internal void CreateFirstAdvertAndSubmit(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage)
        {
            createAdvertPage = CreateFirstDraftAdvert(createAdvertPage);

            createAdvertPage = CompleteAboutTheEmployer(createAdvertPage);
            
            createAdvertPage = Application(createAdvertPage);

            CheckAndSubmitAdvert(createAdvertPage);
        }
    
        internal CreateAnApprenticeshipAdvertOrVacancyPage AddAnAdvert()
        {
            new RecruitmentDynamicHomePage(context, true).ContinueToCreateAdvert();

            return new DoYouNeedToCreateAnAdvertPage(context).ClickYesRadioButtonTakesToRecruitment().GoToCreateAnApprenticeshipAdvertPage();
        }

        internal void CreateOfflineVacancy()
        {
            CreateANewAdvert(true, true);

            SearchVacancyByVacancyReference().NavigateToViewAdvertPage().VerifyDisabilityConfident();
        }

        internal VacancyReferencePage CloneAnAdvert() => SubmitAndSetVacancyReference(GoToRecruitmentHomePage().SelectLiveAdvert().CloneAdvert().SelectYes().UpdateTitle().UpdateVacancyTitleAndGoToCheckYourAnswersPage());

        internal VacancyReferencePage CreateANewAdvert_WageType(string wageType) => CreateANewAdvert(string.Empty, true, false, wageType);

        internal VacancyReferencePage CreateANewAdvert() => CreateANewAdvert(RAAV2Const.LegalEntityName);

        internal VacancyReferencePage CreateANewAdvert(string employername) => CreateANewAdvert(employername, true);

        internal VacancyReferencePage CreateANewAdvert(string employername, bool isEmployerAddress) => CreateANewAdvert(employername, isEmployerAddress, false, RAAV2Const.NationalMinWages);

        internal VacancyReferencePage CreateANewAdvert(bool disabilityConfidence, bool isApplicationMethodFAA) => CreateANewAdvertOrVacancy(string.Empty, true, true, RAAV2Const.NationalMinWages, isApplicationMethodFAA, false);

        internal VacancyReferencePage CreateANewAdvert(string employername, bool isEmployerAddress, bool disabilityConfidence, string wageType) => CreateANewAdvertOrVacancy(employername, isEmployerAddress, disabilityConfidence, wageType, true, false);

        protected override CreateAnApprenticeshipAdvertOrVacancyPage CreateAnApprenticeshipAdvertOrVacancy() => GoToRecruitmentHomePage().CreateAnApprenticeshipAdvert().GoToCreateAnApprenticeshipAdvertPage();
        protected override CreateAnApprenticeshipAdvertOrVacancyPage CreateNewTraineeshipVacancy()
        {
            return new CreateAnApprenticeshipAdvertOrVacancyPage(context);
        }

        protected override CreateAnApprenticeshipAdvertOrVacancyPage AdvertOrVacancySummary(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
                    AdvertSummary(EnterAdvertTitle(createAdvertPage));

        private EmployerVacancySearchResultPage SearchVacancyByVacancyReference() => rAAV2EmployerLoginHelper.NavigateToRecruitmentHomePage().SearchAdvertByReferenceNumber();

        protected override CreateAnApprenticeshipAdvertOrVacancyPage AboutTheEmployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, string employername, bool disabilityConfidence, bool isApplicationMethodFAA) =>
            createAdvertPage
                .EmployerName()
                .ChooseEmployerNameForEmployerJourney(employername)
                .EnterEmployerDescriptionAndGoToContactDetailsPage(disabilityConfidence, optionalFields)
                .EnterContactDetailsAndGoToApplicationProcessPage(optionalFields)
                .SelectApplicationMethod_Employer(isApplicationMethodFAA);


        protected override CreateAnApprenticeshipAdvertOrVacancyPage AboutTheEmployerTraineeship(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage,
            string employername)
        {
            return createAdvertPage
                .EmployerName()
                .ChooseEmployerNameForEmployerJourney(employername)
                .EnterEmployerDescriptionAndGoToContactDetailsPage(optionalFields)
                .EnterProviderContactDetailsTraineeship(optionalFields)
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

        protected override CreateAnApprenticeshipAdvertOrVacancyPage EmploymentDetails(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool isEmployerAddress, string wageType) => 
            createAdvertPage
                .ImportantDates()
                .EnterImportantDates()
                .EnterDuration()
                .ChooseWage_Employer(wageType)
                .SubmitExtraInformationAboutPay()
                .SubmitNoOfPositionsAndNavigateToChooseLocationPage()
                .ChooseAddressAndGoToCreateApprenticeshipPage(isEmployerAddress);


        protected override CreateAnApprenticeshipAdvertOrVacancyPage Application(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            createAdvertPage
            .EnterAdditionalQuestionsForApplicants()
            .CompleteAllAdditionalQuestionsForApplicants();

        protected CreateAnApprenticeshipAdvertOrVacancyPage CompleteAboutTheEmployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) => 
            AboutTheEmployer(SkillsAndQualifications(createAdvertPage), string.Empty, true, true);

        private CreateAnApprenticeshipAdvertOrVacancyPage FirstAdvertSummary(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) => 
            AdvertSummary(NavigateToAdvertTitle(createAdvertPage).EnterVacancyTitleForTheFirstAdvert().SelectYes());

        protected virtual ApprenticeshipTrainingPage EnterAdvertTitle(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
            EnterAdvertTitleMultiOrg(createAdvertPage).SelectOrganisationMultiOrg();

        protected SelectOrganisationPage EnterAdvertTitleMultiOrg(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) => 
            NavigateToAdvertTitle(createAdvertPage).EnterAdvertTitleMultiOrg();

        private CreateAnApprenticeshipAdvertOrVacancyPage AdvertSummary(ApprenticeshipTrainingPage page) =>
        page.EnterTrainingTitle()
            .ConfirmTrainingproviderAndContinue()
            .SelectTrainingProvider()
            .ConfirmProviderAndContinueToSummaryPage()
            .EnterShortDescription()
            .EnterAllDescription();

        protected virtual YourApprenticeshipAdvertsHomePage GoToRecruitmentHomePage() => rAAV2EmployerLoginHelper.GoToRecruitmentHomePage();
    }
}