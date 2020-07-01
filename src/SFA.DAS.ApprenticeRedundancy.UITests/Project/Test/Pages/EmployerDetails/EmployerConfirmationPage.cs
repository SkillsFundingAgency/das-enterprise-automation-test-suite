using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.EmployerDetails
{
    public class EmployerConfirmationPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "We've received your information";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        public EmployerConfirmationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}