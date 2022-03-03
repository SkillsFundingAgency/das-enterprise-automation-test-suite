using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers
{
    public class EmployerCreateVacancyStepsHelper
    {
        private readonly RAAV2EmployerLoginStepsHelper _rAAV2EmployerLoginHelper;

        private static string NotStarted => "NOT STARTED";

        private static string Completed => "COMPLETED";

        private static string InProgress => "IN PROGRESS";

        public EmployerCreateVacancyStepsHelper(ScenarioContext context)
        {
            _rAAV2EmployerLoginHelper = new RAAV2EmployerLoginStepsHelper(context);
        }

        internal void CreateANewVacancy()
        {
            var createAdvertPage = _rAAV2EmployerLoginHelper.GoToRecruitmentHomePage().CreateAnApprenticeshiAdvert();

            createAdvertPage.VerifyAdvertSummarySectionStatus(NotStarted);

            createAdvertPage = AdvertSummary(createAdvertPage);

            createAdvertPage.VerifyAdvertSummarySectionStatus(Completed);

            createAdvertPage.VerifyEmploymentDetailsSectionStatus(NotStarted); 

            createAdvertPage = EmploymentDetails(createAdvertPage);

            createAdvertPage.VerifyEmploymentDetailsSectionStatus(Completed);

            createAdvertPage.VerifySkillsandqualificationsSectionStatus(NotStarted);

            createAdvertPage = SkillsAndQualifications(createAdvertPage);

            createAdvertPage.VerifySkillsandqualificationsSectionStatus(Completed);

            createAdvertPage.VerifyAbouttheemployerSectionStatus(NotStarted);

            createAdvertPage = Abouttheemployer(createAdvertPage);

            createAdvertPage.VerifyAbouttheemployerSectionStatus(Completed);

            createAdvertPage.VerifyCheckandsubmityouradvertSectionStatus(InProgress);

            Checkandsubmityouradvert(createAdvertPage).SetVacancyReference();

        }

        private VacancyReferencePage Checkandsubmityouradvert(CreateAnApprenticeshipAdvertPage createAdvertPage)
        {
            return createAdvertPage
                .CheckYourAnswers()
                .SubmitAdvert();
        }


        private CreateAnApprenticeshipAdvertPage Abouttheemployer(CreateAnApprenticeshipAdvertPage createAdvertPage)
        {
            return createAdvertPage
                .EmployerName()
                .ChooseRegisteredNameAndGotoEmployerDescriptionPage()
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

        private CreateAnApprenticeshipAdvertPage EmploymentDetails(CreateAnApprenticeshipAdvertPage createAdvertPage)
        {
            return createAdvertPage
                .ImportantDates()
                .EnterImportantDates(false)
                .EnterDuration()
                .SelectNationalMinimumWageAndGoToNoOfPositions()
                .SubmitNoOfPositionsAndNavigateToChooseLocationPage()
                .ChooseAddress();
        }

        private CreateAnApprenticeshipAdvertPage AdvertSummary(CreateAnApprenticeshipAdvertPage createAdvertPage)
        {
            return createAdvertPage
                .AdvertTitle()
                .EnterAdvertTitleMultiOrg()
                .SelectOrganisationMultiOrg()
                .EnterTrainingTitle()
                .ConfirmTrainingproviderAndContinue()
                .SelectTrainingProvider()
                .ConfirmProviderAndContinueToSummaryPage()
                .EnterShortDescription()
                .EnterAllDescription();
        }
    }
}
