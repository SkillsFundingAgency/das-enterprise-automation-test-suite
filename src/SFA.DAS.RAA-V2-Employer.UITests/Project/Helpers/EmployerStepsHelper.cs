using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Helpers
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

        internal VacanciesPage DeleteDraftVacancy(VacancyPreviewPart2Page previewPage) => previewPage.DeleteVacancy().YesDeleteVacancy();

        internal VacanciesPage CancelVacancy() => EnterVacancyTitle().CancelVacancy();

        internal void CreateOfflineVacancy(bool disabilityConfidence)
        {
            var previewPage = PreviewVacancy(string.Empty, true, disabilityConfidence);

            SubmitVacancy(previewPage, false, false);

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
            var previewPage = PreviewVacancy(employername, isEmployerAddress, false);

            SubmitVacancy(previewPage, true, optionalFields);

            SearchAnyVacancy().NavigateToViewVacancyPage().VerifyEmployerName();
        }

        internal void CreateANewVacancy(string wageType)
        {
            var employernamePage = SelectOrganisation();

            var locationPage = ChooseEmployerName(employernamePage, string.Empty);

            var wageTypePage = locationPage.ChooseAddress(true)
                .EnterImportantDates(false)
                .EnterDuration();

            var previewPage = ChooseWage(wageTypePage, wageType).PreviewVacancy();

            SubmitVacancy(previewPage, true, false);
        }

        internal void VerifyWageType(string wageType)
        {
            SearchAnyVacancy().NavigateToViewVacancyPage().VerifyWageType(wageType);
        }

        internal VacancyPreviewPart2Page PreviewVacancy(string employername, bool isEmployerAddress, bool disabilityConfidence)
        {
            var employernamePage = SelectOrganisation();

            var locationPage = ChooseEmployerName(employernamePage, employername);

            return locationPage.ChooseAddress(isEmployerAddress)
                .EnterImportantDates(disabilityConfidence)
                .EnterDuration()
                .SelectNationalMinimumWage()
                .PreviewVacancy();
        }

        internal void SubmitVacancy(VacancyPreviewPart2Page previewPage, bool isApplicationMethodFAA, bool optionalFields)
        {
            previewPage = EnterMandatoryFields(previewPage, isApplicationMethodFAA);

            previewPage = optionalFields ? EnterOptionalFields(previewPage) : previewPage;

            SubmitVacancy(previewPage);
        }

        private void SubmitVacancy(VacancyPreviewPart2Page previewPage) => previewPage.SubmitVacancy().SetVacancyReference();

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

        private ManageApplicantPage NavigateToManageApplicant() => SearchVacancy().NavigateToManageApplicant();
    }
}
