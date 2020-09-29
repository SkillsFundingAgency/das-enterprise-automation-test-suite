using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public abstract class EIBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly IFrameHelper frameHelper;
        protected readonly EIConfig eIConfig;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        #endregion

        protected override By PageHeader => By.CssSelector("h1");

        protected override By ContinueButton => By.XPath("//button[contains(text(), 'Continue')]");
        protected By ReturnToAccountHomeCTA => By.LinkText("Return to account home");

        protected EIBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            frameHelper = context.Get<IFrameHelper>();
            eIConfig = context.GetEIConfig<EIConfig>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            if (verifypage) { VerifyPage(); }
        }
    }
}
