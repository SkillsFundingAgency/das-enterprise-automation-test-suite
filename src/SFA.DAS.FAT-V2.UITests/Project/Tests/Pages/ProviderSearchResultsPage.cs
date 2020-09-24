using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public class ProviderSearchResultsPage : FATV2BasePage
    {
        protected override string PageTitle => "Training providers for";

        protected By TrainingProvidersForHeader => By.ClassName("govuk-caption-xl");

        private readonly ScenarioContext _context;

        public ProviderSearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage(TrainingProvidersForHeader) ;
        }

        public ProviderSummaryPage SelectFirstProviderInTheList()
        {
            var firstProviderLinkText = pageInteractionHelper.GetText(FirstProviderResultLink);
            objectContext.SetProviderName(firstProviderLinkText);
            formCompletionHelper.ClickLinkByText(firstProviderLinkText);
            return new ProviderSummaryPage(_context);
        }
    }
}
