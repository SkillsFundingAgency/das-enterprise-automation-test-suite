using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.Manage
{
    public class Manage_VacancyPreviewPage : Manage_HeaderSectionBasePage
    {
        protected override string PageTitle => raadataHelper.VacancyTitle;

        protected override By PageHeader => By.CssSelector("#vacancy-title");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ApproveAndContinue => By.Name("VacancyQAAction");

        public Manage_VacancyPreviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public void ApproveAVacancy()
        {
            formCompletionHelper.Click(ApproveAndContinue);

            SignOut();
        }

        public Manage_EnterBasicVacancyDetailsPage EditOrCommentTitle()
        {
            formCompletionHelper.ClickElement(() => pageInteractionHelper.GetLinkByHref("title"));

            return new Manage_EnterBasicVacancyDetailsPage(_context);
        }

    }
}
