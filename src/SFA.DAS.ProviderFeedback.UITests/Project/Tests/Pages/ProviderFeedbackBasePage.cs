using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages
{
    public abstract class ProviderFeedbackBasePage : BasePage
    {
        protected override By PageHeader => By.CssSelector(".heading-xlarge");

        protected By Labels => By.CssSelector("label");

        #region Helpers and Context
        protected readonly RegexHelper regexHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly TabHelper tabHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        protected readonly ProviderFeedbackConfig providerFeedbackConfig;
        #endregion

        protected ProviderFeedbackBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            providerFeedbackConfig = context.GetProviderFeedbackConfig<ProviderFeedbackConfig>();
            regexHelper = context.Get<RegexHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            tabHelper = context.Get<TabHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            if (verifypage) VerifyPage();
        }
    }
}