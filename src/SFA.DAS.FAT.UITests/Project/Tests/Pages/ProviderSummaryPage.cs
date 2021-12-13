using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public class ProviderSummaryPage : FATBasePage
    {
        protected override string PageTitle => objectContext.GetProviderName();

        public ProviderSummaryPage(ScenarioContext context) : base(context) => VerifyPage();

        public ProviderSearchResultsPage NavigateBackFromProviderSummaryPage()
        {
            NavigateBack();
            return new ProviderSearchResultsPage(_context);
        }

        public FindATrainingProviderByNamePage NavigateBackFromProviderSummaryPageForProviderOnlySearch()
        {
            NavigateBack();
            return new FindATrainingProviderByNamePage(_context);
        }
    }
}
