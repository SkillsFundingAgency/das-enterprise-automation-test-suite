using OpenQA.Selenium;
using SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RoatpAdmin.UITests.Project.Tests.Pages.GateWay.OverallGatewayOutcome
{
    public class ConfirmGatewayOutcomePage : RoatpGateWayBasePage
    {
        protected override string PageTitle => "Confirm gateway outcome";

        private By FailComments => By.Id("OptionFailedText");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmGatewayOutcomePage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public FinalConfirmationPassPage PassThisApplicationAndContinue()
        {
            SelectRadioOptionByText("Pass this application");
            Continue();
            return new FinalConfirmationPassPage(_context);
        }
        public FinalConfirmationFailPage FailThisApplicationAndContinue()
        {
            SelectRadioOptionByText("Fail this application");
            formCompletionHelper.EnterText(FailComments, "Fail comments");
            Continue();
            return new FinalConfirmationFailPage(_context);
        }
    }
}
