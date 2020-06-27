using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages
{
    public class ApprenticeConfirmationPage : ApprenticeRedundancyBasePage
    {
        protected override string PageTitle => "We've received your information";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        public ApprenticeConfirmationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
