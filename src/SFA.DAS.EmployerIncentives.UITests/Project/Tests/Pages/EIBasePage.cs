using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public abstract class EIBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly TabHelper tabHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly PageInteractionHelper pageInteractionHelper;
        #endregion

        protected EIBasePage(ScenarioContext context) : base(context)
        {
            tabHelper = context.Get<TabHelper>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
        }
    }
}
