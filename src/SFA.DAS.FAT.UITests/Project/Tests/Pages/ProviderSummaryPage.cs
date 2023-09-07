using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public class ProviderSummaryPage : FATBasePage
    {
        protected override string PageTitle => objectContext.GetProviderName();

        protected override string AccessibilityPageTitle => "Provider summary Page";

        public ProviderSummaryPage(ScenarioContext context) : base(context) => VerifyPage();

        public ProviderSearchResultsPage NavigateBackFromProviderSummaryPage()
        {
            NavigateBack();
            return new ProviderSearchResultsPage(context);
        }

        public FindATrainingProviderByNamePage NavigateBackFromProviderSummaryPageForProviderOnlySearch()
        {
            NavigateBack();
            return new FindATrainingProviderByNamePage(context);
        }
    }
}
