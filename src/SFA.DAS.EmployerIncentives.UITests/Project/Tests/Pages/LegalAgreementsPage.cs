using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class LegalAgreementsPage : EIBasePage
    {
        protected override string PageTitle => "Your organisations and agreements";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        public LegalAgreementsPage(ScenarioContext context) : base(context) => _context = context;
    }
}
