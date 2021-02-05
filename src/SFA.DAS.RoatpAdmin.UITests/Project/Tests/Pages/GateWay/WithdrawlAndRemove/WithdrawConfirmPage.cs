using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.WithdrawlAndRemove
{
    public class WithdrawConfirmPage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Are you sure the applicant wants to withdraw their application?";

        private By InternalComments => By.Id("OptionYesText");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion
        public WithdrawConfirmPage (ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public WithDrawOutcomePage YesSureWithdrawThisApplication()
        {
            SelectRadioOptionByText("Yes");
            formCompletionHelper.EnterText(InternalComments, "Withdraw Application Comments");
            Continue();
            return new WithDrawOutcomePage(_context);
        }
    }
}
