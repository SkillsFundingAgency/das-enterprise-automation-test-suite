using OpenQA.Selenium;
using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages
{
    public abstract class EPAO_BasePage : BasePage
    {
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly EPAODataHelper dataHelper;
        protected readonly EPAOAdminDataHelper ePAOAdminDataHelper;
        protected readonly EPAOConfig ePAOConfig;

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl, .heading-xlarge, .govuk-heading-l, .govuk-panel__title, .govuk-fieldset__heading");

        public EPAO_BasePage(ScenarioContext context) : base(context)
        {
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            dataHelper = context.Get<EPAODataHelper>();
            ePAOAdminDataHelper = context.Get<EPAOAdminDataHelper>();
            ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
        }
    }
}
