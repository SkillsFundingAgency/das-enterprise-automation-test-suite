using SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using System;
//using SFA.DAS.UI.EmployerFrontDoor.UITests.Project.Tests.Pages;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
   public abstract class EmployerFrontDoorBasePage : BasePage
    {
        #region Helpers and Context
        protected readonly ObjectContext objectContext;
        protected readonly PageInteractionHelper pageInteractionHelper;
        protected readonly FormCompletionHelper formCompletionHelper;
        protected readonly EmployerFrontDoorDataHelper employerFrontDoorDataHelper;
        protected readonly TabHelper tabHelper;
        #endregion

        public EmployerFrontDoorBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            objectContext = context.Get<ObjectContext>();
            formCompletionHelper = context.Get<FormCompletionHelper>();
            pageInteractionHelper = context.Get<PageInteractionHelper>();
            employerFrontDoorDataHelper = context.Get<EmployerFrontDoorDataHelper>();
            tabHelper = context.Get<TabHelper>();
            if (verifypage) { VerifyPage(); }
        }
    }
}
