using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFIntroductionTabPage : VRFBasePage
    {
        protected override string PageTitle => "Provide organisation information about your banking and payments to DfE";

        #region Locators
        
        private By VRFCookieCloseButton => By.Id("close-cookie-message");
        protected override By PageHeader => By.CssSelector("h1");
        #endregion

        public VRFIntroductionTabPage(ScenarioContext context) : base(context, false)
        {  
            MultipleVerifyPage(new List<Func<bool>>
            {
                () => VerifyPage(frameHelper.Iframe),
                () => {frameHelper.SwitchFrameAndAction(() => VerifyPage()); return true; }
            });
        }

        public VRFOrgDetailsTabPage ContinueToVRFOrgDetailsTab2Page()
        {
            if (pageInteractionHelper.IsElementPresent(VRFCookieCloseButton))
                formCompletionHelper.Click(VRFCookieCloseButton);

            frameHelper.SwitchFrameAndAction(() => Continue());
            return new VRFOrgDetailsTabPage(_context);
        }
    }
}
