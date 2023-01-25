using OpenQA.Selenium;
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
        protected override By PageHeader => By.CssSelector("form h1");
        protected override By ContinueButton => By.XPath("//button[contains(text(),'Continue')]");

        public SimplifiedPaymentsPilotPage(ScenarioContext context) : base(context) { }

        public SelectStandardPage MakePaymentsPilotSelectionAndContinueToSelectStandardPage (bool OptIn)
        {
            if (OptIn) SelectRadioOptionByForAttribute("confirm-Pilot");
            else SelectRadioOptionByForAttribute("confirm-NonPilot");

            formCompletionHelper.Click(ContinueButton);

            return new SelectStandardPage(context);
        }

        public ProviderEditApprenticeDetailsPage MakePaymentsPilotSelectionAndContinueToEditApprenticeDetailsPage(bool OptIn)
        {
            if (OptIn) SelectRadioOptionByForAttribute("confirm-Pilot");
            else SelectRadioOptionByForAttribute("confirm-NonPilot");

            formCompletionHelper.Click(ContinueButton);

            return new ProviderEditApprenticeDetailsPage(context, OptIn);
        }
    }
}
