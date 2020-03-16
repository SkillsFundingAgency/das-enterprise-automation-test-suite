using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AnnualApprenticeshipReturnPage : BasePage
    {
        protected override string PageTitle => "Annual apprenticeship return";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AnnualApprenticeshipReturnPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

    }
}
