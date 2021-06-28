using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public class ProviderSummaryPage : FATV2BasePage
    {
        protected override string PageTitle => objectContext.GetProviderName();
        private readonly ScenarioContext _context;

        #region Locators
        private By LocationTextBox => By.Id("search-location");
        private By ViewOtherTrainingProvidersButton => By.Id("btn-view-providers");
        private By BackToTrainingProviders => By.Id("providers-breadcrumb");
        private By NoProviderAtLocationErrorText => By.Id("course_provider_not_available");
        #endregion

        public ProviderSummaryPage(ScenarioContext context) : base(context) => _context = context;
        
        public bool VerifyNoTrainingProviderAtLocationErrorText() => pageInteractionHelper.IsElementDisplayed(NoProviderAtLocationErrorText);

        public ProviderSummaryPage EnterPostCodeAndSearch(string location)
        {
            formCompletionHelper.EnterText(LocationTextBox, location);
            formCompletionHelper.SendKeys(LocationTextBox, Keys.Enter);
            return new ProviderSummaryPage(_context);
        }
        public ProviderSearchResultsPage SelectViewOtherTrainingProviders()
        {
            formCompletionHelper.Click(ViewOtherTrainingProvidersButton);
            return new ProviderSearchResultsPage(_context);
        }
        public ProviderSearchResultsPage NavigateBackFromProviderSummaryPage()
        {
            NavigateBackToTrainingProviders();
            return new ProviderSearchResultsPage(_context);
        }
        public ProviderSearchResultsPage NavigateBackToTrainingProviders()
        {
            formCompletionHelper.Click(BackToTrainingProviders);
            return new ProviderSearchResultsPage(_context);
        }
    }
}