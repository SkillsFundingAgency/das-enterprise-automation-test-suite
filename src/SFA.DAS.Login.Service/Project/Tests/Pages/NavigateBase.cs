using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Login.Service.Project.Tests.Pages
{
    public abstract class NavigateBase : BasePage
    {
        #region Helpers and Context
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly TableRowHelper tableRowHelper;
        protected readonly TabHelper tabHelper;
        #endregion

        protected NavigateBase(ScenarioContext context, string url) : base(context)
        {
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            tableRowHelper = context.Get<TableRowHelper>();
            tabHelper = context.Get<TabHelper>();

            if (!(string.IsNullOrEmpty(url))) { tabHelper.GoToUrl(url); }
        }
    }
}