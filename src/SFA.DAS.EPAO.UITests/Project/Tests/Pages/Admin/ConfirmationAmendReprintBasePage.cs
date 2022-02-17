using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public abstract class ConfirmationAmendReprintBasePage : EPAOAdmin_BasePage
    {
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        private By SearchAgainLink => By.PartialLinkText("Search");

        public ConfirmationAmendReprintBasePage(ScenarioContext context) : base(context) => VerifyPage();

        public SearchPage ClickSearchAgain()
        {
            formCompletionHelper.Click(SearchAgainLink);
            return new SearchPage(context);
        }
    }
}