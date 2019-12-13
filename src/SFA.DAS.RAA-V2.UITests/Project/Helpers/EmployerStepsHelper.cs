using SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Helpers
{
    public class EmployerStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _loginhelper;
        private readonly HomePageStepsHelper _homePageStepsHelper;

        public EmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _loginhelper = new EmployerPortalLoginHelper(context);
            _homePageStepsHelper = new HomePageStepsHelper(context);
        }

        internal void ApplicantUnSucessful()
        {
            NavigateToManageApplicant().MakeApplicantUnsucessful().NotifyApplicant();
        }

        internal void ApplicantSucessful()
        {
            NavigateToManageApplicant().MakeApplicantSucessful().NotifyApplicant();
        }

        internal void CreateANewVacancy(string employername, bool optionalFields = false)
        {
            _loginhelper.Login(_context.GetUser<RAAV2EmployerUser>(), true);

            var employernamePage = new RecruitmentHomePage(_context, true)
                .CreateANewVacancy()
                .CreateNewVacancy()
                .EnterVacancyTitle()
                .EnterTrainingTitle()
                .ConfirmTrainingAndContinue()
                .ChooseTrainingProvider()
                .ConfirmTrainingProviderAndContinue()
                .ChooseNoOfPositions()
                .SelectOrganisation();

            var locationPage = ChooseEmployerName(employernamePage, employername);

            var previewPage = locationPage.ChooseAddress()
                .EnterImportantDates()
                .EnterDuration("52", "40")
                .SelectNationalMinimumWage()
                .PreviewVacancy()
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
                .ApplicationMethodFAA()
                .AddEmployerDescription()
                .EnterEmployerDescription();

            if (optionalFields)
            {
                previewPage = EnterOptionalFields(previewPage);
            }
            
            previewPage.SubmitVacancy()
                .SetVacancyReference();
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

        private ChooseApprenticeshipLocationPage ChooseEmployerName(EmployerNamePage employernamePage, string employername)
        {
            switch (employername)
            {
                default:
                    return employernamePage.ChooseRegisteredName();
                case "existing-trading-name":
                    return  employernamePage.ChooseExistingTradingName();
                case "anonymous":
                    return employernamePage.ChooseAnonymous();
            };
        }

        private ManageApplicantPage NavigateToManageApplicant()
        {
            _homePageStepsHelper.GotoEmployerHomePage();

            return new RecruitmentHomePage(_context, true)
                .SearchLiveVacancy()
                .NavigateToManageApplicant();
        }
    }
}
