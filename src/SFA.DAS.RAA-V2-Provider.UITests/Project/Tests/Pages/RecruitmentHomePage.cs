using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA_V2.Service.Project.Helpers;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Provider.UITests.Project.Tests.Pages
{
    public class RecruitmentHomePage : InterimProviderBasePage
    {
        protected override string PageTitle => "Recruitment";

        protected override string Linktext => "Recruit apprentices";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly SearchVacancyProviderPageHelper _searchVacancyPageHelper;
        #endregion

        private By CreateVacancyLink => By.CssSelector("a[data-automation='create-vacancy']");

        private By ReportsLink => By.LinkText("Reports");
        private By ManageYourRecruitmentEmailsLink => By.LinkText("Manage your recruitment emails");

        private By ViewAllVacancy => By.CssSelector($"a[href='/{ukprn}/vacancies/?filter=All']");

        public RecruitmentHomePage(ScenarioContext context, bool navigate = false) : base(context, navigate)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _searchVacancyPageHelper = new SearchVacancyProviderPageHelper(context);
        }

        public ViewAllVacancyPage GoToViewAllVacancyPage()
        {
            _formCompletionHelper.Click(ViewAllVacancy);
            return new ViewAllVacancyPage(_context);
        }

        public RAAV2CSSBasePage CreateVacancy(bool permissionDenied = false)
        {
            _formCompletionHelper.Click(CreateVacancyLink);

            return permissionDenied
                ? new DoNotHavePermissionPage(_context)
                : new SelectEmployersPage(_context) as RAAV2CSSBasePage;
        }

        public ReportsPage CreateAReport()
        {
            _formCompletionHelper.Click(ReportsLink);
            return new ReportsPage(_context)
                .CreateNewReport()
                .GenerateReport()
                .BackToReportDashboard();
        }

        public ManageRecruitmentEmailsSuccessfulPage ManageRecruitmentEmails()
        {
            _formCompletionHelper.Click(ManageYourRecruitmentEmailsLink);
            return new ManageRecruitmentEmailsPage(_context)
                .SaveAndContinue();
        }

        public RAAV2CSSBasePage ViewVacancyViaEditAndSubmitLink(string vacancyState, bool previewReady, bool permissionDenied)
        {
            var vacancyTitle = _searchVacancyPageHelper
                .ClickEditAndSubmit(vacancyState, previewReady);

            return permissionDenied
                ? new DoNotHavePermissionPage(_context)
                : previewReady
                    ? new VacancyPreviewPart2Page(_context, vacancyTitle) as RAAV2CSSBasePage
                    : new SelectOrganisationPage(_context);
        }

        public VacancyPreviewPart2Page EditVacancyViaEditAndSubmitLink(string vacancyState, out string vacancyTitle)
        {
            vacancyTitle = _searchVacancyPageHelper
                .ClickEditAndSubmit(vacancyState, true);

            return new VacancyPreviewPart2Page(_context, vacancyTitle);
        }
       
        public ViewVacancyPage ViewVacancyViaManageLink(string vacancyState)
        {
            var vacancyTitle = _searchVacancyPageHelper
                .ClickManageVacancy(vacancyState);

            return new ManageRecruitPage(_context)
                .NavigateToViewAdvertPage(vacancyTitle);
        }

        public EditVacancyPage EditVacancyViaManageLink(string vacancyState)
        {
            _searchVacancyPageHelper
                .ClickManageVacancy(vacancyState);

            return new ManageRecruitPage(_context)
                .NavigateToEditAdvertPage();
        }

        public ManageApplicantPage ViewApplicationsViaManageLink(string vacancyState)
        {
            _searchVacancyPageHelper.ClickManageVacancy(vacancyState, 1);
            
            return new ManageRecruitPage(_context)
                .NavigateToManageApplicant();
        }

        public void CloneVacancyViaManageLink(string vacancyState, bool permissionDenied)
        {
            _searchVacancyPageHelper.ClickManageVacancy(vacancyState);
            new ManageRecruitPage(_context)
                .CloneAdvert(permissionDenied);
        }

        public void CloseVacancyViaManageLink(string vacancyState, bool permissionDenied)
        {
            _searchVacancyPageHelper.ClickManageVacancy(vacancyState);
            new ManageRecruitPage(_context)
                .CloseAdvert(permissionDenied);
        }

        public ManageRecruitPage SearchVacancyByVacancyReference() => _searchVacancyPageHelper.SearchVacancyByVacancyReference();

        public ReferVacancyPage SearchReferVacancy() => _searchVacancyPageHelper.SearchReferVacancy();
    }
}
