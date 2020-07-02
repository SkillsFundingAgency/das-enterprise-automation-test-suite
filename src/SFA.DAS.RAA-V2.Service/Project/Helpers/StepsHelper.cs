using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Helpers
{
    public class StepsHelper
    {
        private readonly ScenarioContext _context;

        public StepsHelper(ScenarioContext context) => _context = context;

        public void VerifyWageType(ManageVacancyPage manageVacancyPage, string wageType)
            => manageVacancyPage.NavigateToViewVacancyPage().VerifyWageType(wageType);

        public void ApplicantSucessful(ManageVacancyPage manageVacancyPage)
            => manageVacancyPage.NavigateToManageApplicant().MakeApplicantSucessful().NotifyApplicant();

        public void ApplicantUnsucessful(ManageVacancyPage manageVacancyPage)
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
            switch (wageType)
            {
                case "National Minimum Wage":
                    return wageTypePage.SelectNationalMinimumWage();
                case "Fixed Wage Type":
                    return wageTypePage.SelectFixedWageType();
                default:
                    return wageTypePage.SelectNationalMinimumWageForApprentices();
            };
        }

        public ChooseApprenticeshipLocationPage ChooseEmployerName(EmployerNamePage employernamePage, string employername)
        {
            switch (employername)
            {
                case "existing-trading-name":
                    return employernamePage.ChooseExistingTradingName();
                case "anonymous":
                    return employernamePage.ChooseAnonymous();
                default:
                    return employernamePage.ChooseRegisteredName();
            };
        }

        public ChooseApprenticeshipLocationPage ChooseEmployerNameForEmployerJourney(WhichEmployerNameDoYouWantOnYourAdvertPage whichEmployerNameDoYouWantOnYourAdvertPage, string employername)
        {
            switch (employername)
            {
                case "existing-trading-name":
                    return whichEmployerNameDoYouWantOnYourAdvertPage.ChooseExistingTradingName();
                case "anonymous":
                    return whichEmployerNameDoYouWantOnYourAdvertPage.ChooseAnonymous();
                default:
                    return whichEmployerNameDoYouWantOnYourAdvertPage.ChooseRegisteredName();
            };
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
