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
        #endregion

        #region Locators
        protected By SearchTextField => By.Id("keywords");
        protected virtual By SearchButton => By.Id("submit-keywords");
        #endregion

        protected FATBasePage(ScenarioContext context) : base(context)
        {
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
    }
}
