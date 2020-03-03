using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class ResultsPage : ApprenticeshipBasePage
    {
        protected override string PageTitle => "RESULTS...";

        protected override By PageHeader => By.CssSelector("h1.heading-l");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By PostCodeBox => By.CssSelector("#Postcode");

        private By UpdateResults => By.CssSelector("#button-faa-update-results");


        public ResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public YourResultsPage VerifySearchResults()
        {
            foreach (var postcode in campaignsDataHelper.Postcodes)
            {
                if (pageInteractionHelper.GetText(PageHeader).Contains("YOUR RESULTS..."))
                {
                    return new YourResultsPage(_context);
                }
                else
                {
                    formCompletionHelper.EnterText(PostCodeBox, postcode);
                    formCompletionHelper.ClickElement(UpdateResults);
                }
            }
            throw new System.Exception("NO MATCHING RESULTS...");
        }

    }
}
