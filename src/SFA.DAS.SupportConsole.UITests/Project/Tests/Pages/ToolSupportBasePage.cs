using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public abstract class ToolSupportBasePage : BasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        protected readonly ObjectContext objectContext;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly SupportConsoleConfig config;
        protected readonly RegexHelper regexHelper;
        protected readonly TableRowHelper tableRowHelper;
        #endregion

        public ToolSupportBasePage(ScenarioContext context, bool verifyPage = true) : base(context)
        {
            _context = context;
            objectContext = context.Get<ObjectContext>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
            tableRowHelper = context.Get<TableRowHelper>();
            regexHelper = context.Get<RegexHelper>();
            if (verifyPage) VerifyPage();

        }


    }
}
