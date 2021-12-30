using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage
{
    public class PauseReservationMessagePage : ApprovalsBasePage
    {
        protected override string PageTitle => "Reserving government funding for apprenticeship training and assessment is currently paused.";

        public PauseReservationMessagePage(ScenarioContext context) : base(context) { }
    }
}


