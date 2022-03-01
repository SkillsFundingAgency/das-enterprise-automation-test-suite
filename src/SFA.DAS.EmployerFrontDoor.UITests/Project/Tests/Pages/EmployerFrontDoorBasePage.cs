using SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Tests.Pages
{
   public abstract class EmployerFrontDoorBasePage : VerifyBasePage
    {
        #region Helpers and Context
        protected readonly EmployerFrontDoorDataHelper employerFrontDoorDataHelper;
        #endregion

        public EmployerFrontDoorBasePage(ScenarioContext context, bool verifypage = true) : base(context)
        {
            employerFrontDoorDataHelper = context.Get<EmployerFrontDoorDataHelper>();
            if (verifypage) { VerifyPage(); }
        }
    }
}
