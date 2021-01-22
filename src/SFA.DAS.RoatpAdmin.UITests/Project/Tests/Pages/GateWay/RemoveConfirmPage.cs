using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay
{
    public class RemoveConfirmPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Are you sure you want to remove this application?";

        private By InternalComments => By.Id("OptionYesText");
        private By ExternalComments => By.Id("OptionYesTextExternal");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        public RemoveConfirmPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public RemoveOutcomePage YesSureWithdrawThisApplication()
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(InternalComments, "Withdraw Application Internal Comments");
            formCompletionHelper.EnterText(ExternalComments, "Remove Application External Comments");
            Continue();
            return new RemoveOutcomePage(_context);
        }
    }
}
