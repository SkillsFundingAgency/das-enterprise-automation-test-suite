using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public abstract class Navigate : BasePage
    {
        #region Helpers and Context
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly ProjectConfig config;
        #endregion

        protected By GlobalNavLink => By.CssSelector("#global-nav-links li a");

        protected abstract string Linktext { get; }

        protected bool navigate;

        public Navigate(ScenarioContext context) : base(context)
        {
            config = context.GetProjectConfig<ProjectConfig>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            bool func() => navigate ? VerifyPage(NavigateTo) : VerifyPage();
            func();
        }
        protected void NavigateTo()
        {
            var link = pageInteractionHelper.GetLink(GlobalNavLink, Linktext);
            formCompletionHelper.ClickElement(link);
        }
    }
}