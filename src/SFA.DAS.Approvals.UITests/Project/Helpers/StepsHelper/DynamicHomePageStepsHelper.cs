using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class DynamicHomePageStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly MFEmployerStepsHelper _mfEmployerStepsHelper;

        public DynamicHomePageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _loginHelper = new EmployerPortalLoginHelper(_context);
            _mfEmployerStepsHelper = new MFEmployerStepsHelper(_context);
        }

        public void ReserveFundingFromDynamicHomePage()
        {
        }
    }
}
