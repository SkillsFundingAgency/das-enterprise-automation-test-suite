using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class SimplifiedPaymentsPilotPage : AddAndEditApprenticeDetailsBasePage
    {
        protected override string PageTitle => "Will this apprentice be part of the Simplified Payments pilot?";

        public SimplifiedPaymentsPilotPage(ScenarioContext context) : base(context) { }

        public SelectStandardPage MakeSimplifiedPaymentsPilotSelection (bool OptIn)
        {
            if (OptIn) SelectRadioOptionByForAttribute("confirm-Pilot");
            else SelectRadioOptionByForAttribute("confirm-NonPilot");

            Continue();

            return new SelectStandardPage(context);
        }
    }
}
