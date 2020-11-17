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
        #endregion

        public ProviderSearchResultsPage(ScenarioContext context) : base(context) => _context = context;

        public ProviderSummaryPage SelectFirstProviderInTheList()
        {
            var firstProviderLinkText = pageInteractionHelper.GetText(FirstProviderResultLink);
            objectContext.SetProviderName(firstProviderLinkText);
            formCompletionHelper.ClickLinkByText(firstProviderLinkText);
            return new ProviderSummaryPage(_context);
        }
        public ProviderSummaryPage SelectASpecificProvider(string provider = "10004596")
        {
            ClickSpecifiedProvider(provider);
            return new ProviderSummaryPage(_context);
        }
        private void ClickSpecifiedProvider(string provider) => formCompletionHelper.Click(SpecifiedProvider(provider));

    }
}
