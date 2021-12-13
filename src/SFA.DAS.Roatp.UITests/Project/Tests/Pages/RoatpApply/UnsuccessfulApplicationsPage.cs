using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class UnsuccessfulApplicationsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Have you submitted an application to join the RoATP in the last 12 months?";

        public UnsuccessfulApplicationsPage (ScenarioContext context) : base(context) => VerifyPage();

        public EnterUkprnPage SelectNoFor2ApplicaitonsAndContinue()
        {
            SelectNoAndContinue();
            return new EnterUkprnPage(_context);
        }
    }
}
