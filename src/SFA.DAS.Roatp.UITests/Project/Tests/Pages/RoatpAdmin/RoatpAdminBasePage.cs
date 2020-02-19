using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public abstract class RoatpAdminBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly ObjectContext objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly RoatpUkprnDataHelpers roatpUkprnDataHelpers;
        protected readonly RoatpConfig roatpConfig;

        #endregion

        public RoatpAdminBasePage(ScenarioContext context) : base(context)
        {
            objectContext = context.Get<ObjectContext>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            roatpUkprnDataHelpers = context.Get<RoatpUkprnDataHelpers>();
            roatpConfig = context.GetRoatpConfig<RoatpConfig>();
        }
    }
}
