using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Helpers
{
    public class StepsHelper
    {
        private readonly ScenarioContext _context;

        public StepsHelper(ScenarioContext context)
        {
            _context = context;
        }

        public void ApplicantSucessful(ManageVacancyPage manageVacancyPage) => manageVacancyPage.NavigateToManageApplicant().MakeApplicantSucessful().NotifyApplicant();

        public void ApplicantUnSucessful(ManageVacancyPage manageVacancyPage) => manageVacancyPage.NavigateToManageApplicant().MakeApplicantUnsucessful().NotifyApplicant();
        
        public VacancyPreviewPart2Page PreviewVacancy(EmployerNamePage employernamePage, string employername, bool isEmployerAddress, bool disabilityConfidence)
        {
            var locationPage = ChooseEmployerName(employernamePage, employername);

            return locationPage.ChooseAddress(isEmployerAddress)
                .EnterImportantDates(disabilityConfidence)
                .EnterDuration()
                .SelectNationalMinimumWage()
                .PreviewVacancy();
        }

        public ChooseApprenticeshipLocationPage ChooseEmployerName(EmployerNamePage employernamePage, string employername)
        {
            switch (employername)
            {
                default:
                    return employernamePage.ChooseRegisteredName();
                case "existing-trading-name":
                    return employernamePage.ChooseExistingTradingName();
                case "anonymous":
                    return employernamePage.ChooseAnonymous();
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

    }
}
