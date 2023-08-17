using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project.Tests.Pages.Reviewer
{
    public class Reviewer_HomePage : RAAV2QABasePage
    {
        protected override By PageHeader => ReviewVacancyButton;

        protected override string PageTitle => "Review Vacancy";

        private static By ReviewVacancyButton => By.CssSelector(".govuk-button[type='submit']");

        private static By SearchTerm => By.Id("SearchTerm");

        private static By SearchVacancy => By.CssSelector(".search-submit button");

        private static By ReviewLink => By.LinkText("Review");

        public Reviewer_HomePage(ScenarioContext context) : base(context) { }

        public Reviewer_AnyVacancyPreviewPage ReviewNextVacancy()
        {
            formCompletionHelper.Click(ReviewVacancyButton);
            return new Reviewer_AnyVacancyPreviewPage(context);
        }

        public Reviewer_VacancyPreviewPage ReviewVacancy()
        {
            formCompletionHelper.EnterText(SearchTerm, objectContext.GetVacancyReference());
            formCompletionHelper.Click(SearchVacancy);
            formCompletionHelper.Click(ReviewLink);
            return new Reviewer_VacancyPreviewPage(context);
        }
    }
}
