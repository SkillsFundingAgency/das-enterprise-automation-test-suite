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

        internal VacanciesPage CancelVacancy() => EnterVacancyTitle().CancelVacancy();

        internal void CreateOfflineVacancy(bool disabilityConfidence)
        {
            var employernamePage = SelectOrganisation();

            var locationPage = ChooseEmployerName(employernamePage, string.Empty);

            var previewPage = locationPage.ChooseAddress(true)
                .EnterImportantDates(disabilityConfidence)
                .EnterDuration("52", "40")
                .SelectNationalMinimumWage()
                .PreviewVacancy();

            previewPage = EnterVacancyPreviewFields(previewPage, false, false);

            SubmitVacancy(previewPage);

            SearchAnyVacancy().NavigateToViewVacancyPage().VerifyDisabilityConfident();
        }


        internal void CloneAVacancy()
        {
          var previewPage = GoToRecruitmentHomePage()
                .SelectVacancy()
                .CloneVacancy()
                .SelectYes()
                .UpdateTitle()
                .UpdateVacancyTitle();

            SubmitVacancy(previewPage);
        }

        internal void EditVacancyDates() 
        {
            SearchVacancy()
                .EditVacancy()
                .EditVacancyCloseDate()
                .EnterVacancyDates()
                .EditVacancyStartDate()
                .EnterPossibleStartDate()
                .PublishVacancy();
        }

        internal void CloseVacancy() => SearchVacancy().CloseVacancy().YesCloseThisVacancy();

        internal void ApplicantUnSucessful() => NavigateToManageApplicant().MakeApplicantUnsucessful().NotifyApplicant();

        internal void ApplicantSucessful() => NavigateToManageApplicant().MakeApplicantSucessful().NotifyApplicant();

        internal void CreateANewVacancy(string employername, bool isEmployerAddress, bool optionalFields = false)
        {
            var employernamePage = SelectOrganisation();

            var locationPage = ChooseEmployerName(employernamePage, employername);

            var previewPage = locationPage.ChooseAddress(isEmployerAddress)
                .EnterImportantDates(false)
                .EnterDuration("52", "40")
                .SelectNationalMinimumWage()
                .PreviewVacancy();

            previewPage = EnterVacancyPreviewFields(previewPage, true, optionalFields);

            SubmitVacancy(previewPage);

            SearchAnyVacancy().NavigateToViewVacancyPage().VerifyEmployerName();
        }

        private void SubmitVacancy(VacancyPreviewPart2Page previewPage)
        {
            previewPage.SubmitVacancy().SetVacancyReference();
        }

        private ManageVacancyPage SearchVacancy()
        {
            _homePageStepsHelper.GotoEmployerHomePage();

            return SearchAnyVacancy();
        }

        private ManageVacancyPage SearchAnyVacancy() => new RecruitmentHomePage(_context, true).SearchAnyVacancy();

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

        private VacancyPreviewPart2Page EnterVacancyPreviewFields(VacancyPreviewPart2Page previewPage, bool isApplicationMethodFAA, bool optionalFields)
        {
            previewPage = EnterMandatoryFields(previewPage, isApplicationMethodFAA);
            
            return optionalFields ? EnterOptionalFields(previewPage) : previewPage;
        }

        private RecruitmentHomePage GoToRecruitmentHomePage()
        {
            _loginhelper.Login(_context.GetUser<RAAV2EmployerUser>(), true);

            return new RecruitmentHomePage(_context, true);
        }

        private ApprenticeshipTrainingPage EnterVacancyTitle()
        {
            return GoToRecruitmentHomePage()
                .CreateANewVacancy()
                .CreateNewVacancy()
                .EnterVacancyTitle();
        }

        private EmployerNamePage SelectOrganisation()
        {
            return EnterVacancyTitle()
                .EnterTrainingTitle()
                .ConfirmTrainingAndContinue()
                .ChooseTrainingProvider()
                .ConfirmTrainingProviderAndContinue()
                .ChooseNoOfPositions()
                .SelectOrganisation();
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
            return SearchVacancy().NavigateToManageApplicant();
        }
    }
}
