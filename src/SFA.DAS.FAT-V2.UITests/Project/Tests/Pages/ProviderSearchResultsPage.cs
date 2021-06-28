using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public class ProviderSearchResultsPage : FATV2BasePage
    {
        protected override string PageTitle => "Training providers for";

        protected override By PageHeader => By.ClassName("govuk-caption-xl");

        private readonly ScenarioContext _context;

        #region Locators
        private By SpecifiedProvider(string provider) => By.Id($"provider-{provider}");
        private By BackToCourseSummaryPage => By.Id("course-detail-breadcrumb");
        private By AddToShortlist => By.CssSelector("button[id^='add-to-shortlist-']");
        private By RemoveLocation => By.LinkText("Clear");
        #endregion

        public ProviderSearchResultsPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderSummaryPage SelectFirstProviderInTheList()
        {
            var firstProviderLinkText = pageInteractionHelper.GetText(FirstProviderResultLink);
            objectContext.SetProviderName(firstProviderLinkText);
            formCompletionHelper.ClickLinkByText(firstProviderLinkText);
            return new ProviderSummaryPage(_context);
        }
        public TrainingCourseSummaryPage NavigateBackFromTrainingProvidersPage()
        {
            NavigateBackToTrainingProviders();
            return new TrainingCourseSummaryPage(_context);
        }
        public TrainingCourseSummaryPage NavigateBackToTrainingProviders()
        {
            formCompletionHelper.Click(BackToCourseSummaryPage);
            return new TrainingCourseSummaryPage(_context);
        }
        public ProviderSearchResultsPage ShortlistAProviderFromProviderList()
        {
            formCompletionHelper.Click(AddToShortlist);
            return new ProviderSearchResultsPage(_context);
        }
        public ProviderSearchResultsPage RemoveLocationOnProviderListPage()
        {
            formCompletionHelper.Click(RemoveLocation);
            return new ProviderSearchResultsPage(_context);
        }
        public ProviderShortlistPage NavigateToProviderShortlistPage()
        {
            NavigateToShortlistPage();
            return new ProviderShortlistPage(_context);
        }
        public void ClickSpecifiedProvider(string provider) => formCompletionHelper.Click(SpecifiedProvider(provider));
    }
}
