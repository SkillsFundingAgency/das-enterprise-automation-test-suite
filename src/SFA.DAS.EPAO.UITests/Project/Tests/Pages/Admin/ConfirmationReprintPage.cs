using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class ConfirmationReprintPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Reprint certificate";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private By SearchAgainLink => By.LinkText("Search again");

        #region Helpers and Context

        #endregion

        public ConfirmationReprintPage(ScenarioContext context) : base(context) => VerifyPage();

        public SearchPage ClickSearchAgain()
        {
            formCompletionHelper.Click(SearchAgainLink);
            return new SearchPage(context);
        }
    }
}