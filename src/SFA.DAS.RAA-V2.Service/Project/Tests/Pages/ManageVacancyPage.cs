using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageVacancyPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Manage vacancy";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Applicant => By.CssSelector(".responsive a");

        public ManageVacancyPage(ScenarioContext context) : base(context) => _context = context;

        public CloneVacancyDatesPage CloneVacancy()
        {
            formCompletionHelper.ClickLinkByText("Clone vacancy");
            return new CloneVacancyDatesPage(_context);
        }

        public EditVacancyPage EditVacancy()
        {
            formCompletionHelper.ClickLinkByText("Edit vacancy");
            return new EditVacancyPage(_context);
        }

        public CloseVacancyPage CloseVacancy()
        {
            formCompletionHelper.ClickLinkByText("Close vacancy");
            return new CloseVacancyPage(_context);
        }

        public ViewVacancyPage NavigateToViewVacancyPage()
        {
            tabHelper.OpenInNewTab(() => formCompletionHelper.ClickLinkByText("View vacancy"));

            return new ViewVacancyPage(_context);
        }

        public ManageApplicantPage NavigateToManageApplicant()
        {
            formCompletionHelper.Click(Applicant);
            return new ManageApplicantPage(_context);
        }
    }
}
