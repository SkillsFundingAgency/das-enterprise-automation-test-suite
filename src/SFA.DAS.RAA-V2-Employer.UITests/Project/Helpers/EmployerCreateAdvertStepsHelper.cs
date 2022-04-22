using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;
using DoYouNeedToCreateAnAdvertPage = SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.DynamicHomePageEmployer.DoYouNeedToCreateAnAdvertPage;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers
{
    public class EmployerCreateAdvertStepsHelper : CreateAdvertVacancyBaseStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RAAV2EmployerLoginStepsHelper _rAAV2EmployerLoginHelper;

        public EmployerCreateAdvertStepsHelper(ScenarioContext context) : base()
        {
            _context = context;
            _rAAV2EmployerLoginHelper = new RAAV2EmployerLoginStepsHelper(context);
        }

        internal void SubmitDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage)
        {
            createAdvertPage = SkillsAndQualifications(createAdvertPage);

            createAdvertPage = AboutTheEmployer(createAdvertPage, string.Empty, true);

            CheckAndSubmitAdvert(createAdvertPage);
        }

        internal void CompleteDraftAdvert(CreateAnApprenticeshipAdvertPage createAdvertPage)
        {
            createAdvertPage = SkillsAndQualifications(createAdvertPage);

            createAdvertPage = Abouttheemployer(createAdvertPage, string.Empty, true);

            CompleteDraftAdvertBeforeReturningToApplications(createAdvertPage);
        }

        private VacancyPreviewPart2Page CompleteDraftAdvertBeforeReturningToApplications(CreateAnApprenticeshipAdvertPage createAdvertPage) => AttemptDeletingDraftAdvertBeforeReturningToCreateAdvertPage(createAdvertPage.CheckYourAnswers());

        private VacancyPreviewPart2Page AttemptDeletingDraftAdvertBeforeReturningToCreateAdvertPage(CheckYourAnswersPage checkYourAnswersPage) =>
            checkYourAnswersPage.PreviewAdvert().DeleteVacancy().NoDeleteVacancy();

        internal CreateAnApprenticeshipAdvertPage CreateDraftAdvert() => CreateDraftAdvert(CreateAnApprenticeshiAdvert(), false);
        internal CreateAnApprenticeshipAdvertPage CreateCompleteDraftAdvert() => CreateDraftAdvert(CreateAnApprenticeshiAdvert(), false);

        internal CreateAnApprenticeshipAdvertOrVacancyPage CreateDraftAdvert(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool createFirstDraftAdvert)
        {
            return EmploymentDetails(createFirstDraftAdvert ? FirstAdvertSummary(createAdvertPage) : AdvertOrVacancySummary(createAdvertPage), true, false, RAAV2Const.NationalMinWages);
        }

        internal void CreateFirstAdvertAndSubmit(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage)
        {
            createAdvertPage = CreateDraftAdvert(createAdvertPage, true);

            createAdvertPage = SkillsAndQualifications(createAdvertPage);

            createAdvertPage = Abouttheemployer(createAdvertPage, string.Empty, true);


            CheckAndSubmitAdvert(createAdvertPage);
        }
    
        internal CreateAnApprenticeshipAdvertOrVacancyPage AddAnAdvert()
        {
            new RecruitmentDynamicHomePage(_context, true).ContinueToCreateAdvert();

            return new DoYouNeedToCreateAnAdvertPage(_context).ClickYesRadioButtonTakesToRecruitment().GoToCreateAnApprenticeshipAdvertPage();
        }

        internal void CreateOfflineVacancy()
        {
            CreateANewAdvert(true, false);

            SearchVacancyByVacancyReference().NavigateToViewAdvertPage().VerifyDisabilityConfident();
        }

        internal YourApprenticeshipAdvertsHomePage CancelAdvert() { EnterAdvertTitle(CreateAnApprenticeshipAdvertOrVacancy()).EmployerCancelAdvert(); return new YourApprenticeshipAdvertsHomePage(_context); }

        internal VacancyReferencePage CloneAnAdvert() => SubmitAndSetVacancyReference(_rAAV2EmployerLoginHelper.GoToRecruitmentHomePage().SelectLiveAdvert().CloneAdvert().SelectYes().UpdateTitle().UpdateVacancyTitleAndGoToCheckYourAnswersPage());

        internal VacancyReferencePage CreateANewAdvert_WageType(string wageType) => CreateANewAdvert(string.Empty, true, false, wageType);

        internal VacancyReferencePage CreateANewAdvert(string employername) => CreateANewAdvert(employername, true);

        internal VacancyReferencePage CreateANewAdvert(string employername, bool isEmployerAddress) => CreateANewAdvert(employername, isEmployerAddress, false, RAAV2Const.NationalMinWages);

        internal VacancyReferencePage CreateANewAdvert(bool disabilityConfidence, bool isApplicationMethodFAA) => CreateANewAdvertOrVacancy(string.Empty, true, disabilityConfidence, RAAV2Const.NationalMinWages, isApplicationMethodFAA);

        internal VacancyReferencePage CreateANewAdvert(string employername, bool isEmployerAddress, bool disabilityConfidence, string wageType) => CreateANewAdvertOrVacancy(employername, isEmployerAddress, disabilityConfidence, wageType, true);

        protected override CreateAnApprenticeshipAdvertOrVacancyPage CreateAnApprenticeshipAdvertOrVacancy() => _rAAV2EmployerLoginHelper.GoToRecruitmentHomePage().CreateAnApprenticeshipAdvert().GoToCreateAnApprenticeshipAdvertPage();
        
        protected override CreateAnApprenticeshipAdvertOrVacancyPage AdvertOrVacancySummary(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) =>
                    AdvertSummary(EnterAdvertTitle(createAdvertPage).SelectOrganisationMultiOrg());

        private ManageRecruitPage SearchVacancyByVacancyReference() => _rAAV2EmployerLoginHelper.NavigateToRecruitmentHomePage().SearchAdvertByReferenceNumber();

        protected override CreateAnApprenticeshipAdvertOrVacancyPage AboutTheEmployer(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, string employername, bool isApplicationMethodFAA) =>
            createAdvertPage
                .EmployerName()
                .ChooseEmployerNameForEmployerJourney(employername)
                .EnterEmployerDescriptionAndGoToContactDetailsPage(optionalFields)
                .EnterContactDetailsAndGoToApplicationProcessPage(optionalFields)
                .SelectApplicationMethod_Employer(isApplicationMethodFAA);

        protected override CreateAnApprenticeshipAdvertOrVacancyPage SkillsAndQualifications(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) => 
            createAdvertPage
                .Skills()
                .SelectSkillAndGoToQualificationsPage()
                .EnterQualifications()
                .ConfirmQualificationsAndContinue()
                .EnterThingsToConsiderAndReturnToCreateAdvert(optionalFields);

        protected override CreateAnApprenticeshipAdvertOrVacancyPage EmploymentDetails(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage, bool isEmployerAddress, bool disabilityConfidence, string wageType) => 
            createAdvertPage
                .ImportantDates()
                .EnterImportantDates(disabilityConfidence)
                .EnterDuration()
                .ChooseWage(wageType)
                .SubmitNoOfPositionsAndNavigateToChooseLocationPage()
                .ChooseAddressAndGoToCreateApprenticeshipPage(isEmployerAddress);

        private CreateAnApprenticeshipAdvertOrVacancyPage FirstAdvertSummary(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) => 
            AdvertSummary(createAdvertPage.AdvertTitle().EnterVacancyTitleForTheFirstAdvert().SelectYes());

        private CreateAnApprenticeshipAdvertOrVacancyPage AdvertSummary(ApprenticeshipTrainingPage page) => 
            page.EnterTrainingTitle()
                .ConfirmTrainingproviderAndContinue()
                .SelectTrainingProvider()
                .ConfirmProviderAndContinueToSummaryPage()
                .EnterShortDescription()
                .EnterAllDescription();

        private SelectOrganisationPage EnterAdvertTitle(CreateAnApprenticeshipAdvertOrVacancyPage createAdvertPage) => createAdvertPage
                .AdvertTitle()
                .EnterAdvertTitleMultiOrg();
    }
}