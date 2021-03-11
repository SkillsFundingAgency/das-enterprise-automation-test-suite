using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.FindEPAO.UITests.Project.Tests.Pages
{
    public abstract class FindEPAOBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        protected override By BackLink => By.CssSelector("a.link-back");
        protected By SearchTextField => By.Id("SelectedCourseId");
        protected virtual By SearchButton => By.ClassName("govuk-button");
        protected virtual By FirstResultLink => By.ClassName("das-search-results__link");
        #endregion

        protected FindEPAOBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            VerifyPage();
        }
        public void SearchApprenticeshipStandard(string searchTerm)
        {
            formCompletionHelper.EnterText(SearchTextField, searchTerm);
            formCompletionHelper.Click(SearchButton);
        }
    }
}
