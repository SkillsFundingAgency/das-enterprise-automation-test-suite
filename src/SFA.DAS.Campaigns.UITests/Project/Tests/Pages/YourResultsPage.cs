using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class YourResultsPage : ApprenticeshipBasePage
    {
        protected override string PageTitle => "YOUR RESULTS...";

        protected override By PageHeader => By.CssSelector(".heading-l");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabhelper;
        #endregion

        private By SearchResults => By.CssSelector(".link-faa-more-details-title");

        public YourResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _tabhelper = context.Get<TabHelper>();
        }


        public ApprenticeshipSummaryPage SelectFirstSearchResult()
        {
            var firstresult = pageInteractionHelper.FindElement(SearchResults);
            
            objectContext.SetVacancyTitle(firstresult.Text);
            
            _tabhelper.OpenInNewTab(() => formCompletionHelper.ClickElement(SearchResults));

            return new ApprenticeshipSummaryPage(_context);
        }
    }
}
