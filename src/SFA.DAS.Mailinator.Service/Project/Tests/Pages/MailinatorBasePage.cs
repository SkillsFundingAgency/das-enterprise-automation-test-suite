using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Mailinator.Service.Project.Tests.Pages
{
    public abstract class MailinatorBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly IFrameHelper frameHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly JavaScriptHelper javaScriptHelper;
        #endregion

        protected MailinatorBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
        {
            frameHelper = context.Get<IFrameHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            javaScriptHelper = context.Get<JavaScriptHelper>();
            if (verifyPage) VerifyPage();
        }
    }
}
