using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers
{
    public class EmployerCreateAdvertStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly RAAV2EmployerLoginStepsHelper _rAAV2EmployerLoginHelper;

        private static string NotStarted => "NOT STARTED";

        private static string Completed => "COMPLETED";

        private static string InProgress => "IN PROGRESS";

        public EmployerCreateAdvertStepsHelper(ScenarioContext context)
        {
            _context = context;
            _rAAV2EmployerLoginHelper = new RAAV2EmployerLoginStepsHelper(context);
        }

        internal void CreateOfflineVacancy()
        {
            CreateANewAdvert(true, false);

            SearchVacancyByVacancyReference().NavigateToViewAdvertPage().VerifyDisabilityConfident();
        }

        internal YourApprenticeshipAdvertsHomePage CancelAdvert() { EnterAdvertTitle(CreateAnApprenticeshiAdvert()).EmployerCancelAdvert(); return new YourApprenticeshipAdvertsHomePage(_context); }

        internal VacancyReferencePage CloneAnAdvert() => CheckYourAnswers(_rAAV2EmployerLoginHelper.GoToRecruitmentHomePage().SelectLiveAdvert().CloneAdvert().SelectYes().UpdateTitle().UpdateVacancyTitleAndGoToCheckYourAnswersPage());

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

            Checkandsubmityouradvert(createAdvertPage);

        }

        private ManageRecruitPage SearchVacancyByVacancyReference() => _rAAV2EmployerLoginHelper.NavigateToRecruitmentHomePage().SearchAdvertByReferenceNumber();

        private CreateAnApprenticeshipAdvertPage CreateAnApprenticeshiAdvert() => _rAAV2EmployerLoginHelper.GoToRecruitmentHomePage().CreateAnApprenticeshiAdvert();

        private VacancyReferencePage Checkandsubmityouradvert(CreateAnApprenticeshipAdvertPage createAdvertPage) => CheckYourAnswers(createAdvertPage.CheckYourAnswers());

        private VacancyReferencePage CheckYourAnswers(CheckYourAnswersPage checkYourAnswersPage)
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
                .EnterEmployerDescriptionAndGoToContactDetailsPage()
                .EnterContactDetailsAndGoToApplicationProcessPage()
                .SelectApplicationMethod(isApplicationMethodFAA);
        }

        private CreateAnApprenticeshipAdvertPage SkillsAndQualifications(CreateAnApprenticeshipAdvertPage createAdvertPage)
        {
            return createAdvertPage
                .Skills()
                .SelectSkillAndGoToQualificationsPage()
                .EnterQualifications()
                .ConfirmQualificationsAndContinue()
                .EnterThingsToConsiderAndReturnToCreateAdvert();
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
