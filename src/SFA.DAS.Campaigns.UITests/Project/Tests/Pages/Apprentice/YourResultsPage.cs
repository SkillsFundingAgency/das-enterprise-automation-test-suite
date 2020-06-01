using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class YourResultsPage : ApprenticeBasePage
    {
        protected override string PageTitle => "YOUR RESULTS...";

        protected override By PageHeader => By.CssSelector("h1.heading-l");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By SearchResults => By.CssSelector(".link-faa-more-details-title");

        public YourResultsPage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeshipSummaryPage SelectFirstSearchResult()
        {
            var firstresult = pageInteractionHelper.FindElement(SearchResults);

            objectContext.SetVacancyTitle(firstresult.Text);

            tabHelper.OpenInNewTab(() => formCompletionHelper.ClickElement(SearchResults));

            return new ApprenticeshipSummaryPage(_context);
        }
    }
}
