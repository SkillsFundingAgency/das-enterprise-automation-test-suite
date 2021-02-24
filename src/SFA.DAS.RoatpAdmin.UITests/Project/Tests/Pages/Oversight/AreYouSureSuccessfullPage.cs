using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.Oversight
{
    public class AreYouSureSuccessfullPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Are you sure you want to mark this application as successful?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        public AreYouSureSuccessfullPage(ScenarioContext context) : base(context) => _context = context;
        public OversightAssessmentCompletePage SelectYesAskAndContinueOutcomePage()
        {
            SelectRadioOptionByForAttribute("Yes"); 
            return new OversightAssessmentCompletePage(_context);
        }
    }
}
