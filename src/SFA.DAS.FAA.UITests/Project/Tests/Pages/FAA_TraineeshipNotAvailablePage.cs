using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_TraineeshipNotAvailablePage : BasePage
    {
        protected override string PageTitle => "Traineeship no longer available";
        public FAA_TraineeshipNotAvailablePage(ScenarioContext context) : base(context)
        {
            VerifyPage();
        }
    }
}
