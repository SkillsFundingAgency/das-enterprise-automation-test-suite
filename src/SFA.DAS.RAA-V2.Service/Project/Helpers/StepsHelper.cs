using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Helpers
{
    public class StepsHelper
    {
        private readonly ScenarioContext _context;

        public StepsHelper(ScenarioContext context) => _context = context;

        public void VerifyWageType(ManageRecruitPage manageVacancyPage, string wageType)
            => manageVacancyPage.NavigateToViewAdvertPage().VerifyWageType(wageType);

        public void ApplicantSucessful(ManageRecruitPage manageVacancyPage)
            => manageVacancyPage.NavigateToManageApplicant().MakeApplicantSucessful().NotifyApplicant();

        public void ApplicantUnsucessful(ManageRecruitPage manageVacancyPage)
            => manageVacancyPage.NavigateToManageApplicant().MakeApplicantUnsucessful().NotifyApplicant();

        public VacancyPreviewPart2Page PreviewVacancy(EmployerNamePage employernamePage, string employername, bool isEmployerAddress, bool disabilityConfidence)
        {
            var locationPage = ChooseEmployerName(employernamePage, employername);
            return FillApprenticeshipDetails(locationPage, isEmployerAddress, disabilityConfidence);
        }

        public VacancyPreviewPart2Page PreviewVacancyForEmployerJourney(WhichEmployerNameDoYouWantOnYourAdvertPage whichEmployerNameDoYouWantOnYourAdvertPage, string employername, bool isEmployerAddress, bool disabilityConfidence)
        {
            var locationPage = ChooseEmployerNameForEmployerJourney(whichEmployerNameDoYouWantOnYourAdvertPage, employername);
            return FillApprenticeshipDetails(locationPage, isEmployerAddress, disabilityConfidence);
        }

        public VacancyPreviewPart2Page PreviewVacancy(ChooseApprenticeshipLocationPage locationPage, string wageType)
        {
            var wageTypePage = locationPage.ChooseAddress(true)
                .EnterImportantDates(false)
                .EnterDuration();

            return ChooseWage(wageTypePage, wageType).PreviewVacancy();
        }

        private PreviewYourVacancyPage ChooseWage(WageTypePage wageTypePage, string wageType)
        {
            return wageType switch
            {
                "National Minimum Wage" => wageTypePage.SelectNationalMinimumWage(),
                "Fixed Wage Type" => wageTypePage.SelectFixedWageType(),
                _ => wageTypePage.SelectNationalMinimumWageForApprentices(),
            };
            ;
        }

        public ChooseApprenticeshipLocationPage ChooseEmployerName(EmployerNamePage employernamePage, string employername)
        {
            return employername switch
            {
                "existing-trading-name" => employernamePage.ChooseExistingTradingName(),
                "anonymous" => employernamePage.ChooseAnonymous(),
                _ => employernamePage.ChooseRegisteredName(),
            };
            ;
        }

        public ChooseApprenticeshipLocationPage ChooseEmployerNameForEmployerJourney(WhichEmployerNameDoYouWantOnYourAdvertPage whichEmployerNameDoYouWantOnYourAdvertPage, string employername)
        {
            return employername switch
            {
                "existing-trading-name" => whichEmployerNameDoYouWantOnYourAdvertPage.ChooseExistingTradingName(),
                "anonymous" => whichEmployerNameDoYouWantOnYourAdvertPage.ChooseAnonymous(),
                _ => whichEmployerNameDoYouWantOnYourAdvertPage.ChooseRegisteredName(),
            };
            ;
        }

        public void SubmitVacancy(VacancyPreviewPart2Page previewPage, bool isApplicationMethodFAA, bool optionalFields)
        {
            previewPage = EnterMandatoryFields(previewPage, isApplicationMethodFAA);

            previewPage = optionalFields ? EnterOptionalFields(previewPage) : previewPage;

            SubmitVacancy(previewPage);
        }

        public void SubmitVacancy(VacancyPreviewPart2Page previewPage) => previewPage.SubmitVacancy().SetVacancyReference();

        private VacancyPreviewPart2Page EnterMandatoryFields(VacancyPreviewPart2Page previewPage, bool isApplicationMethodFAA)
        {
            previewPage
                .AddBriefOverview()
                .EnterBriefOverview()
                .AddDescription()
                .EnterDescription()
                .AddSkills()
                .SelectSkill()
                .AddQualifications()
                .EnterQualifications()
                .ConfirmQualifications()
                .AddApplicationProcess()
                .ApplicationMethod(isApplicationMethodFAA)
                .AddEmployerDescription()
                .EnterEmployerDescription();

            return new VacancyCompletedAllSectionsPage(_context);
        }

        private VacancyPreviewPart2Page EnterOptionalFields(VacancyPreviewPart2Page previewPage)
        {
            previewPage
                .AddThingsToConsider()
                .EnterThingsToConsider()
                .AddContactDetails()
                .EnterContactDetails();

            return new VacancyCompletedAllSectionsPage(_context);
        }

        private VacancyPreviewPart2Page FillApprenticeshipDetails(ChooseApprenticeshipLocationPage locationPage, bool isEmployerAddress, bool disabilityConfidence) =>
            locationPage.ChooseAddress(isEmployerAddress).EnterImportantDates(disabilityConfidence).EnterDuration()
                .SelectNationalMinimumWage().PreviewVacancy();
    }
}
