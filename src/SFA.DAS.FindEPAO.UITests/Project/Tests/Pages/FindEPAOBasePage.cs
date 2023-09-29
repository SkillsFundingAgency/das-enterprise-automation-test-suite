using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public abstract class FindEPAOBasePage : VerifyBasePage
    {
        #region Locators
        protected override By BackLink => By.CssSelector("a.link-back");
        protected static By SearchTextField => By.Id("SelectedCourseId");
        protected virtual By SearchButton => By.ClassName("govuk-button");
        protected virtual By FirstResultLink => By.ClassName("das-search-results__link");
        #endregion

        protected FindEPAOBasePage(ScenarioContext context) : base(context) => VerifyPage();

        public void SearchApprenticeshipStandard(string searchTerm)
        {
            formCompletionHelper.EnterText(SearchTextField, searchTerm);
            formCompletionHelper.Click(SearchButton);
        }
    }
}
