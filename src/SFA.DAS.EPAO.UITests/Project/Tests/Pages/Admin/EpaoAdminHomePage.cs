using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class EpaoAdminHomePage : EPAO_BasePage
    {
        protected override string PageTitle => "Staff dashboard";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion


        public EpaoAdminHomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
