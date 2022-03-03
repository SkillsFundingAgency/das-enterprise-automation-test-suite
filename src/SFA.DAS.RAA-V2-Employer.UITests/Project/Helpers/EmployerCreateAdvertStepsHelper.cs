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

        internal YourApprenticeshipAdvertsHomePage CancelAdvert() { EnterAdvertTitle(CreateAnApprenticeshiAdvert()).EmployerCancelAdvert(); return new YourApprenticeshipAdvertsHomePage(_context); }

        internal VacancyReferencePage CloneAnAdvert() => Checkandsubmityouradvert(_rAAV2EmployerLoginHelper.GoToRecruitmentHomePage().SelectLiveAdvert().CloneAdvert().SelectYes().UpdateTitle().UpdateVacancyTitleAndGoToCreateAnApprenticeshipAdvertPage());

        internal void CreateANewAdvert(string employername, bool isEmployerAddress)
        {
            var createAdvertPage = CreateAnApprenticeshiAdvert();

            createAdvertPage.VerifyAdvertSummarySectionStatus(NotStarted);

            createAdvertPage = AdvertSummary(createAdvertPage);

            createAdvertPage.VerifyAdvertSummarySectionStatus(Completed);

            createAdvertPage.VerifyEmploymentDetailsSectionStatus(NotStarted); 

            createAdvertPage = EmploymentDetails(createAdvertPage, isEmployerAddress);

            createAdvertPage.VerifyEmploymentDetailsSectionStatus(Completed);

            createAdvertPage.VerifySkillsandqualificationsSectionStatus(NotStarted);

            createAdvertPage = SkillsAndQualifications(createAdvertPage);

            createAdvertPage.VerifySkillsandqualificationsSectionStatus(Completed);

            createAdvertPage.VerifyAbouttheemployerSectionStatus(NotStarted);

            createAdvertPage = Abouttheemployer(createAdvertPage, employername);

            createAdvertPage.VerifyAbouttheemployerSectionStatus(Completed);

            createAdvertPage.VerifyCheckandsubmityouradvertSectionStatus(InProgress);

            Checkandsubmityouradvert(createAdvertPage);

        }

        private CreateAnApprenticeshipAdvertPage CreateAnApprenticeshiAdvert() => _rAAV2EmployerLoginHelper.GoToRecruitmentHomePage().CreateAnApprenticeshiAdvert();

        private VacancyReferencePage Checkandsubmityouradvert(CreateAnApprenticeshipAdvertPage createAdvertPage)
        {
            return createAdvertPage
                .CheckYourAnswers()
                .SubmitAdvert()
                .SetVacancyReference();
        }

        private CreateAnApprenticeshipAdvertPage Abouttheemployer(CreateAnApprenticeshipAdvertPage createAdvertPage, string employername)
        {
            return createAdvertPage
                .EmployerName()
                .ChooseEmployerNameForEmployerJourney(employername)
                .EnterEmployerDescriptionAndGoToContactDetailsPage()
                .EnterContactDetailsAndGoToApplicationProcessPage()
                .SelectApplicationMethod(true);
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

        private CreateAnApprenticeshipAdvertPage EmploymentDetails(CreateAnApprenticeshipAdvertPage createAdvertPage, bool isEmployerAddress)
        {
            return createAdvertPage
                .ImportantDates()
                .EnterImportantDates(false)
                .EnterDuration()
                .SelectNationalMinimumWageAndGoToNoOfPositions()
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
