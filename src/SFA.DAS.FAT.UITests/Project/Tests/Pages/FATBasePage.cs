using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.FAT.UITests.Project.Tests.Pages
{
    public abstract class FATBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        protected readonly FATConfig config;
        private readonly ScenarioContext _context;
        #endregion

        #region Locators
        protected override By BackLink => By.CssSelector("a.link-back");
        protected By SearchTextField => By.Id("keywords");
        protected virtual By SearchButton => By.Id("submit-keywords");
        protected virtual By FirstResultLink => By.CssSelector("h2.result-title a");
        #endregion

        protected FATBasePage(ScenarioContext context) : base(context)
        {
            _context = context;
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            config = context.GetFATConfig<FATConfig>();
        }

        public void SearchApprenticeship(string searchTerm)
        {
            formCompletionHelper.EnterText(SearchTextField, searchTerm);
            formCompletionHelper.Click(SearchButton);
        }

        public ProviderSummaryPage SelectFirstProviderResult()
        {
            var firstLinkText = pageInteractionHelper.GetText(FirstResultLink);
            objectContext.SetProviderName(firstLinkText);
            formCompletionHelper.ClickLinkByText(firstLinkText);
            return new ProviderSummaryPage(_context);
        }
    }
}
