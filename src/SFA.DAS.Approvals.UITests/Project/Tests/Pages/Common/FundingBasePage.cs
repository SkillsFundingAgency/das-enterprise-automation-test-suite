using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class FundingBasePage : BasePage
    {
        #region Helpers and Context

        #endregion
 
        #region Helpers and Context
        protected readonly FormCompletionHelper formCompletionHelper;
        #endregion

        public FundingBasePage(ScenarioContext context) : base(context)
        {
            formCompletionHelper = context.Get<FormCompletionHelper>();
            
        }
    }
}
