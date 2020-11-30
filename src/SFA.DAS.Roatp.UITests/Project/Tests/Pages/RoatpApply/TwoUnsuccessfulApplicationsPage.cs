using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class TwoUnsuccessfulApplicationsPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Have you had 2 unsuccessful applications in the last 12 months?";

        private readonly ScenarioContext _context;

        public TwoUnsuccessfulApplicationsPage (ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();   
        }
        public EnterUkprnPage SelectNoFor2ApplicaitonsAndContinue()
        {
            SelectNoAndContinue();
            return new EnterUkprnPage(_context);
        }
    }
}
