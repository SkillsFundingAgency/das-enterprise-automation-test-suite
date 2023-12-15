using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public abstract class FATBasePage : VerifyBasePage
    {

        #region Locators
        protected override By BackLink => By.CssSelector("a.link-back");
        protected static By SearchTextField => By.Id("keywords");
        protected virtual By SearchButton => By.Id("submit-keywords");
        protected virtual By FirstResultLink => By.CssSelector("h2.result-title a");
        #endregion

        protected FATBasePage(ScenarioContext context) : base(context) { }

        public void SearchApprenticeship(string searchTerm)
        {
            formCompletionHelper.EnterText(SearchTextField, searchTerm);
            formCompletionHelper.SendKeys(SearchTextField, Keys.Tab);
            formCompletionHelper.Click(SearchButton);
        }

        public ProviderSummaryPage SelectFirstProviderResult()
        {
            var firstLinkText = pageInteractionHelper.GetText(FirstResultLink);
            objectContext.SetProviderName(firstLinkText);
            formCompletionHelper.ClickLinkByText(firstLinkText);
            return new ProviderSummaryPage(context);
        }
    }
}
