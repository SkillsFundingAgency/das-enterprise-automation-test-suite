using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public class FindAnApprenticeshipPage : ApprenticeshipBasePage
    {
        protected override string PageTitle => "FIND AN APPRENTICESHIP";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public FindAnApprenticeshipPage(ScenarioContext context) : base(context) => _context = context;

        private By Route => By.CssSelector("#header-route");
        private By Postcode => By.CssSelector("#header-postcode");
        private By Distance => By.CssSelector("#header-distance");

        private By SearchButton => By.CssSelector("#search-apprenticeship");

        public ResultsPage SearchForAnApprenticeship()
        {
            formCompletionHelper.SelectFromDropDownByText(Route, campaignsDataHelper.Route);
            formCompletionHelper.EnterText(Postcode, campaignsDataHelper.Postcode);
            formCompletionHelper.SelectFromDropDownByText(Distance, campaignsDataHelper.Distance);
            formCompletionHelper.ClickElement(SearchButton);
            return new ResultsPage(_context);
        }
    }
}
