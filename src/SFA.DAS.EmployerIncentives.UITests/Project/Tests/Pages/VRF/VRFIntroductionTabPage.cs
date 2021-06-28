using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF
{
    public class VRFIntroductionTabPage : VRFBasePage
    {
        protected override string PageTitle => "Provide organisation information about your banking and payments to DfE";

        #region Locators
        private readonly ScenarioContext _context;
        private By VRFCookieCloseButton => By.Id("close-cookie-message");
        protected override By PageHeader => By.CssSelector("h1");
        #endregion

        public VRFIntroductionTabPage(ScenarioContext context) : base(context, false)
        { 
            _context = context;
            VerifyPage(frameHelper.Iframe);
            frameHelper.SwitchFrameAndAction(() => VerifyPage());
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
