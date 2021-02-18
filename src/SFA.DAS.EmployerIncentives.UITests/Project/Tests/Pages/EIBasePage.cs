using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public abstract class EIBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly IFrameHelper frameHelper;
        protected readonly EIDataHelper eIDataHelper;
        protected readonly EIConfig eIConfig;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly ObjectContext objectContext;
        #endregion

        protected override By PageHeader => By.CssSelector("h1");

        protected override By ContinueButton => By.XPath("//button[contains(text(), 'Continue')]");
        protected By ReturnToAccountHomeCTA => By.LinkText("Return to account home");

        protected EIBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            frameHelper = context.Get<IFrameHelper>();
            eIConfig = context.GetEIConfig<EIConfig>();
            eIDataHelper = context.Get<EIDataHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            objectContext = context.Get<ObjectContext>();
            if (verifypage) { VerifyPage(); }
        }
    }
}
