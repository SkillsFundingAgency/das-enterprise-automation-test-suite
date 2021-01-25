using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class ConfirmClarificationPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Are you sure you want to ask for clarification?";


        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        public ConfirmClarificationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ClarificationOutcomePage YesClarificationRequired()
        {
            SelectRadioOptionByText("Yes");
            Continue();
            return new ClarificationOutcomePage(_context);
        }
    }
}
