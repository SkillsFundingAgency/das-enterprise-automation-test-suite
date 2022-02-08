using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class ConfirmationAmendPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Confirmation";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private By SearchAgainLink => By.LinkText("Search Again");

        #region Helpers and Context

        #endregion

        public ConfirmationAmendPage(ScenarioContext context) : base(context) => VerifyPage();

        public SearchPage ClickSearchAgain()
        {
            formCompletionHelper.Click(SearchAgainLink);
            return new SearchPage(context);
        }
    }
}