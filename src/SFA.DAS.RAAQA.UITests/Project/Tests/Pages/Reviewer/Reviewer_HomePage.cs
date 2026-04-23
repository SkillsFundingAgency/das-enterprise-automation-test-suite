using OpenQA.Selenium;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;
using SFA.DAS.RAA.DataGenerator.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAQA.UITests.Project.Tests.Pages.Reviewer
{
    public class Reviewer_HomePage(ScenarioContext context) : RAAQABasePage(context)
    {
        protected override By PageHeader => ReviewVacancyButton;

        protected override string PageTitle => DfeAfterSignIdentifiers.Reviewer_HomePageTitle;

        private static By ReviewVacancyButton => By.CssSelector(DfeAfterSignIdentifiers.Reviewer_HomePageIdentifierCss);

        private static By SearchTerm => By.Id("SearchTerm");

        private static By SearchVacancy => By.CssSelector(".search-submit button");

        private static By ReviewLink => By.LinkText("Review");

        public Reviewer_AnyVacancyPreviewPage ReviewNextVacancy()
        {
            formCompletionHelper.Click(ReviewVacancyButton);
            return new Reviewer_AnyVacancyPreviewPage(context);
        }

        public Reviewer_VacancyPreviewPage ReviewVacancy()
        {
            var reviewLocatorPresent =
                (pageInteractionHelper.FindElements(ReviewLink).Count > 0
                && pageInteractionHelper.IsElementDisplayed(ReviewLink)
                && pageInteractionHelper.IsElementPresent(ReviewLink));

            if (!reviewLocatorPresent)
            {
                int attempts = 0;
                const int maxAttempts = 15;
                do
                {
                    formCompletionHelper.EnterText(SearchTerm, objectContext.GetVacancyReference());
                    formCompletionHelper.Click(SearchVacancy);
                    attempts++;
                } while (((pageInteractionHelper.FindElements(ReviewLink).Count) == 0 
                || !(pageInteractionHelper.IsElementDisplayed(ReviewLink) 
                && pageInteractionHelper.IsElementPresent(ReviewLink))) 
                && attempts < maxAttempts);
            }

            formCompletionHelper.Click(ReviewLink);
            return new Reviewer_VacancyPreviewPage(context);
        }
    }
}
