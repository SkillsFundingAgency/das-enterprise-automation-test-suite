using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class ConfirmYourIdentityPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Confirm your identity";
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmYourIdentityPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
