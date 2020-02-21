using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Roatp.UITests.Project.Helpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpAdmin;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpAdmin
{
    public abstract class RoatpAdminBasePage : RoatpBasePage
    {
        #region Helpers and Context
        protected readonly RoatpAdminDataHelpers admindataHelpers;
        #endregion

        public RoatpAdminBasePage(ScenarioContext context) : base(context)
        {
            admindataHelpers = context.Get<RoatpAdminDataHelpers>();
            VerifyPage();
        }

        protected void Back() => formCompletionHelper.ClickLinkByText("Back");
    }
}
