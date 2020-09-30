using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class FindAnApprenticeshipPage : ApprenticeBasePage
    {
        protected override string PageTitle => "Browse apprenticeships before you apply";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By Route => By.CssSelector("#header-route");
        private By Postcode => By.CssSelector("#header-postcode");
        private By Distance => By.CssSelector("#header-distance");
        private By SearchButton => By.CssSelector("#search-apprenticeship");

        public FindAnApprenticeshipPage(ScenarioContext context) : base(context){}

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
