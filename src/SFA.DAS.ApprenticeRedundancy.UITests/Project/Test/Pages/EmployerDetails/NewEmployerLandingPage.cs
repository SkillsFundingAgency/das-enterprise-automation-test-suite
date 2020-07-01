using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.EmployerDetails
{
    public class NewEmployerLandingPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "Find apprentices who have been made redundant";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public NewEmployerLandingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public EmployerDetailsPage SelectEmployerStartnow()
        {
            Continue();
            return new EmployerDetailsPage(_context);
        }
    }
}
