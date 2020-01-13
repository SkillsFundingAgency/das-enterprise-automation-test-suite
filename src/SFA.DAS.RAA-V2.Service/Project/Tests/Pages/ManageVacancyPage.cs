using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageVacancyPage : BasePage
    {
        protected override string PageTitle => "Manage vacancy";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly TabHelper _tabHelper;
        #endregion

        private By Applicant => By.CssSelector(".responsive a");

        public ManageVacancyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _tabHelper = context.Get<TabHelper>();
            VerifyPage();
        }

        public CloneVacancyDatesPage CloneVacancy()
        {
            _formCompletionHelper.ClickLinkByText("Clone vacancy");
            return new CloneVacancyDatesPage(_context);
        }

        public EditVacancyPage EditVacancy()
        {
            _formCompletionHelper.ClickLinkByText("Edit vacancy");
            return new EditVacancyPage(_context);
        }

        public CloseVacancyPage CloseVacancy()
        {
            _formCompletionHelper.ClickLinkByText("Close vacancy");
            return new CloseVacancyPage(_context);
        }

        public ViewVacancyPage NavigateToViewVacancyPage()
        {
            _tabHelper.OpenInNewTab(() => _formCompletionHelper.ClickLinkByText("View vacancy"));

            return new ViewVacancyPage(_context);
        }

        public ManageApplicantPage NavigateToManageApplicant()
        {
            _formCompletionHelper.Click(Applicant);
            return new ManageApplicantPage(_context);
        }
    }
}
