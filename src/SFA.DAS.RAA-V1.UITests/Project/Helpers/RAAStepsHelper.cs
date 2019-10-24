using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages;
using SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class RAAStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly RAAV1Config _config;
        private readonly TabHelper _tabHelper;

        public RAAStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _config = context.GetRAAV1Config<RAAV1Config>();
            _tabHelper = context.Get<TabHelper>();
        }

        internal RAA_EmployerSelection CreateANewVacancy()
        {
            var url = _config.RecruitBaseUrl;
            _tabHelper.GoToUrl(url);

            return new RAA_IndexPage(_context)
                .ClickOnSignInButton()
                .ClickRecruitStaffIdams()
                .SubmitRecruitmentLoginDetails()
                .CreateANewVacancy();
        }

        internal RAA_EnterTrainingDetails EnterBasicVacancyDetails(string disabilityConfident, string applicationMethod)
        {
            return new RAA_BasicVacancyDetails(_context)
                       .EnterVacancyTitle()
                       .EnterVacancyShortDescription()
                       .ClickOnVacancyType(VacancyType.Apprenticeship)
                       .CickDisabilityConfident(disabilityConfident)
                       .ApplicationMethod(applicationMethod)
                       .ClickSaveAndContinueButton();
        }

        internal RAA_EnterFurtherDetails EnterTrainingDetails(RAA_EnterTrainingDetails enterTrainingDetails, string apprenticeShip)
        {
            return enterTrainingDetails
                   .SelectApprenticeshipType(apprenticeShip)
                   .EnterTrainingToBeProvided()
                   .EnterContactName()
                   .ContactTelephone()
                   .EnterEmailDetails()
                   .ClickOnSaveAndContinue();
        }

        internal RAA_RequirementsAndProspects EnterFurtherDetails(RAA_EnterFurtherDetails enterFurtherDetails, string hoursPerWeek, string vacancyDuration)
        {
            return enterFurtherDetails
                   .EnterWorkingInformation()
                   .EnterHoursPerWeek(hoursPerWeek)
                   .ClickApprenticeshipMinimumWage()
                   .EnterVacancyDuration(vacancyDuration)
                   .EnterVacancyClosingDate()
                   .EnterPossibleStartDate()
                   .EnterVacancyDescription()
                   .ClickSaveAndContinueButton();
        }

        internal void EnterRequirementsAndProspects(RAA_RequirementsAndProspects requirementsAndProspects)
        {
            requirementsAndProspects
                .EnterDesiredQualificationsText()
                .EnterPersonalQualitiesText()
                .EnterDesiredSkillsText()
                .EnterFutureProspectsText()
                .EnterThingsToConsiderText()
                .ClickSaveAndContinue();
        }

        internal void EnterExtraQuestions()
        {
            new RAA_ExtraQuestions(_context)
                .EnterFirstQuestion()
                .EnterSecondQuestion()
                .ClickPreviewVacancyButton();
        }

        internal void AddMultipleVacancy()
        {
            new RAA_MultipleVacancyLocationPage(_context)
                       .EnterPostCode("CV1 2WT")
                       .ClickOnTheFirstAddress()
                       .EnterNumberOfVacancy()
                       .ClickAddAnotherLocationLink()
                       .EnterPostCode("BS16 4EA")
                       .ClickOnTheFirstAddress()
                       .EnterNumberOfVacancy2()
                       .EnterAdditionalLocationInformation()
                       .ClickSaveAndContinue();
        }
        internal void ApproveVacenacy()
        {
            var vacancyReference = new RAA_VacancyPreview(_context)
           .ClickSubmitForApprovalButton();

            var referenceNumber1 = vacancyReference.GetVacancyReference();

            var referenceNumber = (referenceNumber1.Remove(0, 2)).TrimStart('0');

            _objectContext.SetVacancyReference(referenceNumber);
        }
    }
}
