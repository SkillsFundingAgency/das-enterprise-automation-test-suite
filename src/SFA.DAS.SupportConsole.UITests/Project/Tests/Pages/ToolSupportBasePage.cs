using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public abstract class ToolSupportBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly SupportConsoleConfig config;
        #endregion

        public ToolSupportBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
        {
            config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
            if (verifyPage) VerifyPage();
        }
    }
}
