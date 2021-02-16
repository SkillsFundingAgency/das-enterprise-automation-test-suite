using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.YourOrganisation_Section1
{
   public  class RailFranchiseOperatorPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Is your organisation a rail franchise operator?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public RailFranchiseOperatorPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public NotEligiblePage SelectNoToFranchiseOperatorAndContinue()
        {
            SelectNoAndContinue();
            return new NotEligiblePage(_context);
        }
    }
}
