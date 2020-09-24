using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.FAT_V2.UITests.Project.Tests.Pages
{
    public abstract class FATV2BasePage : BasePage
    {
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        protected override By BackLink => By.CssSelector("a.link-back");
        protected By SearchTextField => By.Id("Keyword");
        protected virtual By SearchButton => By.Id("filters-submit");
        protected virtual By FirstResultLink => By.ClassName("das-no-wrap");
        #endregion
        
        protected FATV2BasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
        }
        public void SearchApprenticeship(string searchTerm)
        {
            formCompletionHelper.EnterText(SearchTextField, searchTerm);
            formCompletionHelper.Click(SearchButton);
        }
    }
}
