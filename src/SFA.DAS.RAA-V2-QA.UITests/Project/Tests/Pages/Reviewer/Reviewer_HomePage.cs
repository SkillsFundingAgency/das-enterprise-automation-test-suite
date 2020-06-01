using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer
{
    public class Reviewer_HomePage : RAAV2CSSBasePage
    {
        protected override By PageHeader => ReviewVacancyButton;

        protected override string PageTitle => "Review Vacancy";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ReviewVacancyButton => By.CssSelector(".govuk-button[type='submit']");

        private By SearchTerm => By.Id("SearchTerm");

        private By SearchVacancy => By.CssSelector(".search-submit button");

        public Reviewer_HomePage(ScenarioContext context) : base(context) => _context = context;

        public Reviewer_AnyVacancyPreviewPage ReviewNextVacancy()
        {
            formCompletionHelper.Click(ReviewVacancyButton);
            return new Reviewer_AnyVacancyPreviewPage(_context);
        }

        public Reviewer_VacancyPreviewPage ReviewVacancy()
        {
            formCompletionHelper.EnterText(SearchTerm, objectContext.GetVacancyReference());
            formCompletionHelper.Click(SearchVacancy);
            formCompletionHelper.ClickLinkByText("Review");
            return new Reviewer_VacancyPreviewPage(_context);
        }
    }
}
