using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.AllowList
{
    public class ConfirmationPage : RoatpNewAdminBasePage
    {
        protected override string PageTitle => "Removed from allow list";


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}