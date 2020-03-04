using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class SummaryOfThisApprenticeshipPage : EmployerBasePage
    {
        protected override string PageTitle => "SUMMARY OF THIS APPRENTICESHIP";

        protected override By PageHeader => By.CssSelector(".main-content .heading-l");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Postcode => By.CssSelector("#Postcode");

        private By ProviderSearchButton => By.CssSelector("#employer-provider-search");

        public SummaryOfThisApprenticeshipPage(ScenarioContext context) : base(context) => _context = context;


        public TrainingProviderResultPage SearchProvider()
        {
            formCompletionHelper.EnterText(Postcode, campaignsDataHelper.ProviderPostcode);
            formCompletionHelper.ClickElement(ProviderSearchButton);
            return new TrainingProviderResultPage(_context);
        }
    }
}

