using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public abstract class RoatpBasePage : BasePage
    {
        protected override By PageHeader => By.TagName("h1");

        #region Helpers and Context
        protected readonly ObjectContext objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly RoatpApplyUkprnDataHelpers roatpUkprnDataHelpers;
        protected readonly RoatpConfig roatpConfig;
        #endregion

        public RoatpBasePage(ScenarioContext context) : base(context)
        {
            objectContext = context.Get<ObjectContext>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            roatpUkprnDataHelpers = context.Get<RoatpApplyUkprnDataHelpers>();
            roatpConfig = context.GetRoatpConfig<RoatpConfig>();
        }
    }
}
