using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;
using DoYouNeedToCreateAnAdvertPage = SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.DynamicHomePageEmployer.DoYouNeedToCreateAnAdvertPage;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers
{
    public class EmployerCreateAdvertStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RAAV2EmployerLoginStepsHelper _rAAV2EmployerLoginHelper;
        public bool optionalFields;

        private static string NotStarted => "NOT STARTED";

        private static string Completed => "COMPLETED";

        private static string InProgress => "IN PROGRESS";

        public EmployerCreateAdvertStepsHelper(ScenarioContext context)
        {
            _context = context;
            optionalFields = false;
            _rAAV2EmployerLoginHelper = new RAAV2EmployerLoginStepsHelper(context);
        }

        internal void CreateSubmittedVacancy(CreateAnApprenticeshipAdvertPage createAdvertPage)
        {
            createAdvertPage = AdvertSummary(createAdvertPage);

            createAdvertPage = EmploymentDetails(createAdvertPage, true, false, RAAV2Const.NationalMinWages);

            createAdvertPage = SkillsAndQualifications(createAdvertPage);

            createAdvertPage = Abouttheemployer(createAdvertPage, string.Empty, true);

            CheckAndSubmitAdvert(createAdvertPage);
        }

        internal CreateAnApprenticeshipAdvertPage CreateDraftVacancy(CreateAnApprenticeshipAdvertPage createAdvertPage)
        {
            createAdvertPage = AdvertSummary(createAdvertPage);

            return EmploymentDetails(createAdvertPage, true, false, RAAV2Const.NationalMinWages);
        }

        internal CreateAnApprenticeshipAdvertPage AddAnAdvert()
        {
            new RecruitmentDynamicHomePage(_context, true).ContinueToCreateAdvert();

            return new DoYouNeedToCreateAnAdvertPage(_context).ClickYesRadioButtonTakesToRecruitment().GoToCreateAnApprenticeshipAdvertPage();
        }

        internal void CreateOfflineVacancy()
        {
            CreateANewAdvert(true, false);

            SearchVacancyByVacancyReference().NavigateToViewAdvertPage().VerifyDisabilityConfident();
        }

        internal YourApprenticeshipAdvertsHomePage CancelAdvert() { EnterAdvertTitle(CreateAnApprenticeshiAdvert()).EmployerCancelAdvert(); return new YourApprenticeshipAdvertsHomePage(_context); }

        internal VacancyReferencePage CloneAnAdvert() => SubmitAndSetVacancyReference(_rAAV2EmployerLoginHelper.GoToRecruitmentHomePage().SelectLiveAdvert().CloneAdvert().SelectYes().UpdateTitle().UpdateVacancyTitleAndGoToCheckYourAnswersPage());

        internal void CreateANewAdvert_WageType(string wageType) => CreateANewAdvert(string.Empty, true, false, wageType);

        internal void CreateANewAdvert(string employername) => CreateANewAdvert(employername, true);

        internal void CreateANewAdvert(string employername, bool isEmployerAddress) => CreateANewAdvert(employername, isEmployerAddress, false, RAAV2Const.NationalMinWages);

        internal void CreateANewAdvert(bool disabilityConfidence, bool isApplicationMethodFAA) => CreateANewAdvert(string.Empty, true, disabilityConfidence, RAAV2Const.NationalMinWages, isApplicationMethodFAA);

        internal void CreateANewAdvert(string employername, bool isEmployerAddress, bool disabilityConfidence, string wageType) => CreateANewAdvert(employername, isEmployerAddress, disabilityConfidence, wageType, true);

        internal void CreateANewAdvert(string employername, bool isEmployerAddress, bool disabilityConfidence, string wageType, bool isApplicationMethodFAA)
        {
            var createAdvertPage = CreateAnApprenticeshiAdvert();

            createAdvertPage.VerifyAdvertSummarySectionStatus(NotStarted);

            createAdvertPage = AdvertSummary(createAdvertPage);

            createAdvertPage.VerifyAdvertSummarySectionStatus(Completed);

            createAdvertPage.VerifyEmploymentDetailsSectionStatus(NotStarted); 

            createAdvertPage = EmploymentDetails(createAdvertPage, isEmployerAddress, disabilityConfidence, wageType);

            createAdvertPage.VerifyEmploymentDetailsSectionStatus(Completed);

            createAdvertPage.VerifySkillsandqualificationsSectionStatus(NotStarted);

            createAdvertPage = SkillsAndQualifications(createAdvertPage);

            createAdvertPage.VerifySkillsandqualificationsSectionStatus(Completed);

            createAdvertPage.VerifyAbouttheemployerSectionStatus(NotStarted);

            createAdvertPage = Abouttheemployer(createAdvertPage, employername, isApplicationMethodFAA);

            createAdvertPage.VerifyAbouttheemployerSectionStatus(Completed);

            createAdvertPage.VerifyCheckandsubmityouradvertSectionStatus(InProgress);

            CheckAndSubmitAdvert(createAdvertPage);
        }

        private ManageRecruitPage SearchVacancyByVacancyReference() => _rAAV2EmployerLoginHelper.NavigateToRecruitmentHomePage().SearchAdvertByReferenceNumber();

        private CreateAnApprenticeshipAdvertPage CreateAnApprenticeshiAdvert() => _rAAV2EmployerLoginHelper.GoToRecruitmentHomePage().CreateAnApprenticeshipAdvert().GoToCreateAnApprenticeshipAdvertPage();

        private VacancyReferencePage CheckAndSubmitAdvert(CreateAnApprenticeshipAdvertPage createAdvertPage) => SubmitAndSetVacancyReference(createAdvertPage.CheckYourAnswers());

        private VacancyReferencePage SubmitAndSetVacancyReference(CheckYourAnswersPage checkYourAnswersPage)
        {
            return checkYourAnswersPage
                .SubmitAdvert()
                .SetVacancyReference();
        }

        private CreateAnApprenticeshipAdvertPage Abouttheemployer(CreateAnApprenticeshipAdvertPage createAdvertPage, string employername, bool isApplicationMethodFAA)
        {
            return createAdvertPage
                .EmployerName()
                .ChooseEmployerNameForEmployerJourney(employername)
                .EnterEmployerDescriptionAndGoToContactDetailsPage(optionalFields)
                .EnterContactDetailsAndGoToApplicationProcessPage(optionalFields)
                .SelectApplicationMethod(isApplicationMethodFAA);
        }

        private CreateAnApprenticeshipAdvertPage SkillsAndQualifications(CreateAnApprenticeshipAdvertPage createAdvertPage)
        {
            return createAdvertPage
                .Skills()
                .SelectSkillAndGoToQualificationsPage()
                .EnterQualifications()
                .ConfirmQualificationsAndContinue()
                .EnterThingsToConsiderAndReturnToCreateAdvert(optionalFields);
        }

        private CreateAnApprenticeshipAdvertPage EmploymentDetails(CreateAnApprenticeshipAdvertPage createAdvertPage, bool isEmployerAddress, bool disabilityConfidence, string wageType)
        {
            return createAdvertPage
                .ImportantDates()
                .EnterImportantDates(disabilityConfidence)
                .EnterDuration()
                .ChooseWage(wageType)
                .SubmitNoOfPositionsAndNavigateToChooseLocationPage()
                .ChooseAddressAndGoToCreateApprenticeshipPage(isEmployerAddress);
        }

        private CreateAnApprenticeshipAdvertPage AdvertSummary(CreateAnApprenticeshipAdvertPage createAdvertPage)
        {
            return EnterAdvertTitle(createAdvertPage)
                .SelectOrganisationMultiOrg()
                .EnterTrainingTitle()
                .ConfirmTrainingproviderAndContinue()
                .SelectTrainingProvider()
                .ConfirmProviderAndContinueToSummaryPage()
                .EnterShortDescription()
                .EnterAllDescription();
        }

        private SelectOrganisationPage EnterAdvertTitle(CreateAnApprenticeshipAdvertPage createAdvertPage) => createAdvertPage
                .AdvertTitle()
                .EnterAdvertTitleMultiOrg();
    }
}
