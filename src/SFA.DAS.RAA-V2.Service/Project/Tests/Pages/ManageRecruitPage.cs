using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ManageRecruitPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "Manage advert";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Applicant => By.CssSelector(".responsive a");

        public ManageRecruitPage(ScenarioContext context) : base(context) => _context = context;

        public CloneVacancyDatesPage CloneAdvert()
        {
            formCompletionHelper.ClickLinkByText("Clone advert");
            return new CloneVacancyDatesPage(_context);
        }

        public EditVacancyPage EditAdvert()
        {
            formCompletionHelper.ClickLinkByText("Edit advert");
            return new EditVacancyPage(_context);
        }

        public CloseVacancyPage CloseAdvert()
        {
            formCompletionHelper.ClickLinkByText("Close advert");
            return new CloseVacancyPage(_context);
        }

        public ViewVacancyPage NavigateToViewAdvertPage()
        {
            tabHelper.OpenInNewTab(() => formCompletionHelper.ClickLinkByText("View advert"));

            return new ViewVacancyPage(_context);
        }

        public ManageApplicantPage NavigateToManageApplicant()
        {
            formCompletionHelper.Click(Applicant);
            return new ManageApplicantPage(_context);
        }
    }
}
